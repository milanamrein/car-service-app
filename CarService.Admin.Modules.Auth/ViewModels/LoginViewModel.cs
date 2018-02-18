using CarService.Admin.Infrastructure.Events;
using CarService.Admin.Infrastructure.Helpers;
using CarService.Admin.Infrastructure.Prism;
using CarService.Admin.Infrastructure.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Threading.Tasks;

namespace CarService.Admin.Modules.Auth.ViewModels
{
    /// <summary>
    /// Login page ViewModel
    /// </summary>
    public class LoginViewModel : BindableBase, IRegionMemberLifetime
    {
        #region Fields

        /// <summary>
        /// Authentication Service
        /// </summary>
        private IAuthService _authService;

        /// <summary>
        /// Navigation field
        /// </summary>
        private readonly INavigation _navigation;

        /// <summary>
        /// User's username
        /// </summary>
        private string _username;

        /// <summary>
        /// An error message regarding to authentication
        /// </summary>
        private string _errorMessage;

        /// <summary>
        /// A success message regarding to authentication
        /// </summary>
        private string _successMessage;

        /// <summary>
        /// Indicates whether the button should be disabled
        /// or not during async methods
        /// </summary>
        private bool _isButtonEnabled;

        #endregion

        #region Default Constructor

        public LoginViewModel(IAuthService authService, INavigation navigation)
        {
            _authService = authService;
            _navigation = navigation;
            _isButtonEnabled = true;
            this.LoginCommand = new DelegateCommand<IHavePassword>(async (control) => await LoginAsync(control), 
                (control) => !string.IsNullOrWhiteSpace(this.Username))
                .ObservesProperty(() => this.Username);

            // subscribing to the successful registration event to get the message
            _navigation.EventAggregator.GetEvent<RegistrationSuccessfulEvent>().Subscribe((message) => this.SuccessMessage = message);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Navigation command
        /// </summary>
        public DelegateCommand<string> NavigateCommand => _navigation.NavigateCommand;

        /// <summary>
        /// Login command
        /// </summary>
        public DelegateCommand<IHavePassword> LoginCommand { get; set; }

        /// <summary>
        /// User's username
        /// </summary>
        public string Username
        {
            get { return this._username; }
            set { SetProperty(ref _username, value); }
        }

        /// <summary>
        /// An error message regarding to authentication
        /// </summary>
        public string ErrorMessage
        {
            get { return this._errorMessage; }
            set { SetProperty(ref _errorMessage, value); }
        }

        /// <summary>
        /// A success message regarding to authentication
        /// </summary>
        public string SuccessMessage
        {
            get { return this._successMessage; }
            set { SetProperty(ref _successMessage, value); }
        }

        /// <summary>
        /// Indicates whether the VM object should be destroyed
        /// after it reaches from activated to deactivated state
        /// </summary>
        public bool KeepAlive => false;

        /// <summary>
        /// Indicates whether the button is enabled
        /// or not during async methods
        /// </summary>
        public bool IsButtonEnabled
        {
            get { return this._isButtonEnabled; }
            set { SetProperty(ref _isButtonEnabled, value); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The process of login
        /// </summary>
        private async Task LoginAsync(IHavePassword control)
        {
            try
            {

                this.IsButtonEnabled = false;
                if (this.SuccessMessage != null)
                    this.SuccessMessage = null;

                // create UserDTO navigation parameter
                NavigationParameters navigationParameters = new NavigationParameters
                {
                    {
                        "UserDataChanged", true
                    },
                    {
                        "User",
                        await _authService.LoginAsync("Mechanic", this.Username, control.Password)
                    }
                };

                // navigate to home page
                this._navigation.NavigateTo("Reservations", navigationParameters);                    
                this._navigation.NavigateToWithinNavbarRegion("Navbar");                

            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.Message;
            }
            finally
            {
                IsButtonEnabled = true;
            }
        }

        #endregion
    }
}
