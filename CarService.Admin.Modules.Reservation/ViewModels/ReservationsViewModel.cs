using CarService.Admin.Infrastructure.Events;
using CarService.Admin.Infrastructure.Prism;
using CarService.Admin.Infrastructure.Services;
using CarService.DTO;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace CarService.Admin.Modules.Reservation.ViewModels
{
    /// <summary>
    /// Reservations page ViewModel
    /// </summary>
    public class ReservationsViewModel : BindableBase, IRegionMemberLifetime, INavigationAware
    {
        #region Fields

        /// <summary>
        /// Navigation field
        /// </summary>
        private readonly INavigation _navigation;

        /// <summary>
        /// Mechanic Service
        /// </summary>
        private readonly IMechanicService _mechanicService;

        /// <summary>
        /// The user data
        /// </summary>
        private UserDTO _user;

        /// <summary>
        /// Collection of the mechanic's reservations
        /// </summary>
        private ObservableCollection<ReservationDTO> _mechanicReservations;

        /// <summary>
        /// Error message
        /// </summary>
        private string _errorMessage;

        /// <summary>
        /// Success message
        /// </summary>
        private string _successMessage;

        /// <summary>
        /// Indicates whether the page is loading or not
        /// </summary>
        private bool _isLoading;        

        #endregion

        #region Default Constructor

        public ReservationsViewModel(INavigation navigation, IMechanicService mechanicService)
        {
            _navigation = navigation;
            _mechanicService = mechanicService;                        
            _mechanicReservations = new ObservableCollection<ReservationDTO>();
            this.ToAddWorksheetCommand = new DelegateCommand<ReservationDTO>((reservation) => ToAddWorksheet(reservation));
            _navigation.EventAggregator.GetEvent<WorksheetCreatedSuccessfullyEvent>().Subscribe(message => this.SuccessMessage = message);
            _navigation.EventAggregator.GetEvent<UnexpectedErrorEvent>().Subscribe(message => this.ErrorMessage = message);
        }        

        #endregion

        #region Public Properties

        /// <summary>
        /// User data
        /// </summary>
        public UserDTO User
        {
            get { return this._user; }
            set { SetProperty(ref _user, value); }
        }        

        /// <summary>
        /// Collection of the mechanic's reservations
        /// </summary>
        public ObservableCollection<ReservationDTO> MechanicReservations
        {
            get { return this._mechanicReservations; }
            set { SetProperty(ref _mechanicReservations, value); }
        }

        /// <summary>
        /// Error message property
        /// </summary>
        public string ErrorMessage
        {
            get { return this._errorMessage; }
            set { SetProperty(ref _errorMessage, value); }
        }

        /// <summary>
        /// Success message property
        /// </summary>
        public string SuccessMessage
        {
            get { return this._successMessage; }
            set { SetProperty(ref _successMessage, value); }
        }

        /// <summary>
        /// Command which navigates to the AddWorksheet page
        /// </summary>
        public DelegateCommand<ReservationDTO> ToAddWorksheetCommand { get; set; }
        
        /// <summary>
        /// Property that indicates whether the page is loading or not
        /// </summary>
        public bool IsLoading
        {
            get { return this._isLoading; }
            set { SetProperty(ref _isLoading, value); }
        }       

        /// <summary>
        /// Indicates whether the VM object should be destroyed
        /// after it reaches from activated to deactivated state
        /// </summary>
        public bool KeepAlive => true;

        #endregion

        #region Methods

        /// <summary>
        /// Navigates to the AddWorksheet page
        /// with regarding data
        /// </summary>
        private void ToAddWorksheet(ReservationDTO reservation)
        {
            NavigationParameters navigationParameters = new NavigationParameters
            {
                {
                    "NewWorksheet", true
                },
                {
                    "User", _user
                },
                {
                    "Reservation", reservation
                }
            };

            _navigation.NavigateTo("AddWorksheet", navigationParameters);
        }

        #endregion

        #region INavigationAware Methods

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            this.ErrorMessage = this.SuccessMessage = string.Empty;
        }

        // getting user data
        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            try
            {

                if(navigationContext.Parameters["UserDataChanged"] != null)
                {
                    this.IsLoading = true;

                    // checking if the authenticated user's data has changed
                    if(navigationContext.Parameters["User"] != null)
                    {
                        _user = new UserDTO();
                        this.User = (UserDTO)navigationContext.Parameters["User"];                        
                    }

                    _mechanicReservations.Clear();
                    UserDTO userData =
                        await _mechanicService.GetMechanicAsync(_user.Id, _user.Token);
                    this.User.Username = userData.Username;
                    this.User.FullName = userData.FullName;
                    if(userData.MechanicWorksheets.Count > 0)
                        this.User.MechanicWorksheets = userData.MechanicWorksheets;
                    if (userData.MechanicReservations.Count > 0)
                    {
                        this.User.MechanicReservations = userData.MechanicReservations
                            .Where(res => res.Worksheet.Id == 0)
                            .ToList<ReservationDTO>();
                        foreach (ReservationDTO reservation in this.User.MechanicReservations)
                            _mechanicReservations.Add(reservation);
                    }

                    // passing data to the user profile bar if the user data has changed                       
                    NavigationParameters navigationParameters = new NavigationParameters
                    {
                        {
                            "User", this.User
                        }
                    };
                    this._navigation.NavigateToWithinProfileRegion("UserProfile", navigationParameters);
                }
                
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message;
            }
            finally
            {
                this.IsLoading = false;
            }
        }

        #endregion       
    }
}
