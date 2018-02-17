using Prism.Mvvm;
using System;
using CarService.Admin.Infrastructure.Prism;
using Prism.Commands;
using System.Collections.ObjectModel;
using CarService.DTO;
using Prism.Regions;
using CarService.Admin.Infrastructure.Services;
using CarService.Admin.Infrastructure.Helpers;
using System.Threading.Tasks;
using CarService.Admin.Infrastructure.Events;

namespace CarService.Admin.Modules.Auth.ViewModels
{
    /// <summary>
    /// Register page ViewModel
    /// </summary>
    public class RegisterViewModel : BindableBase, IRegionMemberLifetime
    {
        #region Fields

        /// <summary>
        /// Persistence Service for registration
        /// </summary>
        private IAuthService _authService;

        /// <summary>
        /// Navigation field
        /// </summary>
        private readonly INavigation _navigation;

        /// <summary>
        /// The Register Form field
        /// </summary>
        private RegisterUserDTO _newUser;        

        /// <summary>
        /// Gets the registration messages
        /// </summary>
        private ObservableCollection<string> _messages;

        /// <summary>
        /// Indicates whether the button should be disabled
        /// or not during async methods
        /// </summary>
        private bool _isButtonEnabled;

        #endregion

        #region Default Constructor

        public RegisterViewModel(IAuthService authService, INavigation navigation)
        {
            _authService = authService;
            _navigation = navigation;
            _newUser = new RegisterUserDTO
            {
                FirstName = string.Empty,
                LastName = string.Empty,
                Username = string.Empty,
                Password = string.Empty,
                ConfirmPassword = string.Empty
            };
            _isButtonEnabled = true;
            _messages = new ObservableCollection<string>();
            this.RegisterCommand = new DelegateCommand(async () => await this.RegisterAsync());
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Register Form Property
        /// </summary>
        public RegisterUserDTO NewUser
        {
            get { return this._newUser; }
            set { SetProperty(ref _newUser, value); }
        }

        /// <summary>
        /// Navigation command
        /// </summary>
        public DelegateCommand<string> NavigateCommand => _navigation.NavigateCommand;

        /// <summary>
        /// Registration command
        /// </summary>
        public DelegateCommand RegisterCommand { get; set; }                

        /// <summary>
        /// Gets the registration messages
        /// </summary>
        public ObservableCollection<string> Messages => _messages;

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
        /// The process of registration
        /// </summary>
        private async Task RegisterAsync()
        {
            try
            {

                this.IsButtonEnabled = false;
                if(_messages.Count > 0)
                    _messages.Clear();

                // get the result  
                this.NewUser.Role = "Mechanic";
                RegistrationResult result = await _authService.RegisterAsync(this.NewUser);

                // if the registration wasn't successful, show error messages
                if (!result.RegistrationWasSuccessful)
                {
                    foreach (string message in result.Messages)                    
                        _messages.Add(message);                    
                }
                else
                {
                     // if it was successful, redirect to the login page with success message
                    _navigation.NavigateTo("Login", new NavigationParameters());
                    _navigation.EventAggregator.GetEvent<RegistrationSuccessfulEvent>()
                        .Publish("Registration was successful! You can sign in now!");
                }

            }
            catch (Exception ex)
            {
                _messages.Add($"An unexpected error has occurred: {ex.Message}");
            }
            finally
            {
                this.IsButtonEnabled = true;
            }
        }

        #endregion
    }
}
