using CarService.DTO;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Admin.Modules.Worksheet.ViewModels
{
    /// <summary>
    /// Worksheet page ViewModel
    /// </summary>
    public class WorksheetViewModel : BindableBase, IRegionMemberLifetime, INavigationAware
    {
        #region Fields

        /// <summary>
        /// The authenticated user
        /// </summary>
        private UserDTO _user;

        /// <summary>
        /// The worksheet's reservation
        /// </summary>
        private ReservationDTO _reservation;

        /// <summary>
        /// Worksheet's materials
        /// </summary>
        private List<MaterialDTO> _materials;

        /// <summary>
        /// Total price of the materials
        /// </summary>
        private double _totalPrice;

        /// <summary>
        /// Error message
        /// </summary>
        private string _errorMessage;

        #endregion

        #region Default Constructor

        public WorksheetViewModel()
        {
            _user = new UserDTO();
            _reservation = new ReservationDTO();
            _materials = new List<MaterialDTO>();
            _totalPrice = 0;
        }

        #endregion

        #region Public Properties        

        /// <summary>
        /// Authenticated user property
        /// </summary>
        public UserDTO User
        {
            get { return this._user; }
            set { SetProperty(ref _user, value); }
        }        

        /// <summary>
        /// The worksheet's reservation property
        /// </summary>
        public ReservationDTO Reservation
        {
            get { return this._reservation; }
            set { SetProperty(ref _reservation, value); }
        }
        
        /// <summary>
        /// Worksheet's materials property
        /// </summary>
        public List<MaterialDTO> Materials
        {
            get { return this._materials; }
            set { SetProperty(ref _materials, value); }
        }        

        /// <summary>
        /// Total price of the materials
        /// </summary>
        public double TotalPrice
        {
            get { return this._totalPrice; }
            set { SetProperty(ref _totalPrice, value); }
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
        /// Indicates whether the VM object should be destroyed
        /// after it reaches from activated to deactivated state
        /// </summary>
        public bool KeepAlive => false;

        #endregion

        #region INavigationAwareMethods

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
                
                // getting the worksheet data
                _materials.Clear();
                _totalPrice = 0;
                this.User = (UserDTO)navigationContext.Parameters["User"];
                WorksheetDTO worksheet = (WorksheetDTO)navigationContext.Parameters["Worksheet"];
                this.Reservation = worksheet.Reservation;
                this.Reservation.Partner = worksheet.Partner;
                this.Materials = worksheet.Materials.ToList<MaterialDTO>();
                foreach (MaterialDTO material in this.Materials)
                    this.TotalPrice += (material.Price * material.Quantity);

            } catch(Exception ex)
            {
                this.ErrorMessage = ex.Message;
            }
        }

        #endregion
    }
}
