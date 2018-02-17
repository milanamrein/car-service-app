using CarService.Admin.Infrastructure.Prism;
using CarService.DTO;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Admin.Modules.Worksheet.ViewModels
{
    /// <summary>
    /// Worksheets page ViewModel
    /// </summary>
    public class WorksheetsViewModel : BindableBase, IRegionMemberLifetime, INavigationAware
    {
        #region Fields

        /// <summary>
        /// Navigation field
        /// </summary>
        private readonly INavigation _navigation;

        /// <summary>
        /// The authenticated user
        /// </summary>
        private UserDTO _user;

        /// <summary>
        /// Collection of the mechanic's worksheets
        /// </summary>
        private ObservableCollection<WorksheetDTO> _mechanicWorksheets;

        /// <summary>
        /// Error message field
        /// </summary>
        private string _errorMessage;

        /// <summary>
        /// Indicates whether the page is loading or not
        /// </summary>
        private bool _isLoading;

        #endregion

        #region Default Constructor

        public WorksheetsViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _user = new UserDTO();
            _mechanicWorksheets = new ObservableCollection<WorksheetDTO>();
            this.ToWorksheetCommand = new DelegateCommand<WorksheetDTO>((worksheet) => ToWorksheet(worksheet));
        }        

        #endregion

        #region Public Properties                

        /// <summary>
        /// Command which navigates to the
        /// Worksheet page with relevant data
        /// </summary>
        public DelegateCommand<WorksheetDTO> ToWorksheetCommand { get; set; }

        /// <summary>
        /// Property of the authenticated user
        /// </summary>
        public UserDTO User
        {
            get { return this._user; }
            set { SetProperty(ref _user, value); }
        }

        /// <summary>
        /// Collection of the mechanic's worksheets
        /// </summary>
        public ObservableCollection<WorksheetDTO> MechanicWorksheets
        {
            get { return this._mechanicWorksheets; }
            set { SetProperty(ref _mechanicWorksheets, value); }
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
        /// Property which indicates whether
        /// the page is loading or not
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
        public bool KeepAlive => false;

        #endregion

        #region Methods

        /// <summary>
        /// Navigates to the Worksheet page
        /// with relevant worksheet data
        /// </summary>
        /// <param name="worksheet">The worksheet to show on Worksheet page</param>
        private void ToWorksheet(WorksheetDTO worksheet)
        {
            NavigationParameters navigationParameters = new NavigationParameters
            {
                {
                    "User", this.User
                },
                {
                    "Worksheet", worksheet
                }
            };
            _navigation.NavigateTo("Worksheet", navigationParameters);
        }

        #endregion

        #region INavigationAware Methods

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            try
            {

                this.IsLoading = true;

                // getting the user's data
                _mechanicWorksheets.Clear();
                _user = (UserDTO)navigationContext.Parameters["User"];
                if(_user.MechanicWorksheets != null)
                    foreach (WorksheetDTO worksheet in _user.MechanicWorksheets)                
                        _mechanicWorksheets.Add(worksheet);                

            } catch(Exception ex)
            {
                this.ErrorMessage = ex.Message;
            } finally
            {
                this.IsLoading = false;
            }            
        }

        #endregion
    }
}
