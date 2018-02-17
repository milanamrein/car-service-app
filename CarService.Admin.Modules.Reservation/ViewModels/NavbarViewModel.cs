using CarService.Admin.Infrastructure.Prism;
using Prism.Commands;
using Prism.Mvvm;
using CarService.Admin.Infrastructure;
using System.Linq;
using Prism.Regions;
using System;
using CarService.Admin.Infrastructure.Events;

namespace CarService.Admin.Modules.Reservation.ViewModels
{
    /// <summary>
    /// Class which navigates between authenticated pages
    /// </summary>
    public class NavbarViewModel : BindableBase
    {
        /// <summary>
        /// Navigation field
        /// </summary>
        private readonly INavigation _navigation;

        public NavbarViewModel(INavigation navigation)
        {
            _navigation = navigation;
            this.LogoutCommand = new DelegateCommand(Logout);
        }

        /// <summary>
        /// Navigation command
        /// </summary>
        public DelegateCommand<string> NavigateCommand => _navigation.NavigateCommand;

        /// <summary>
        /// Command of signing out
        /// </summary>
        public DelegateCommand LogoutCommand { get; set; }

        /// <summary>
        /// Method of signing out
        /// </summary>
        private void Logout()
        {
            try
            {
                
                // Destroying the User profile and reservations list
                // by removing them from region
                _navigation.RemoveFromProfileRegion("UserProfile");
                _navigation.RemoveFromContentRegion("Reservations");

                // Navigate back to the Login page
                _navigation.NavigateToWithinProfileRegion("Logo", new NavigationParameters());
                _navigation.NavigateToWithinNavbarRegion("AuthNavigation");
                _navigation.NavigateTo("Login", new NavigationParameters());

            } catch(Exception ex)
            {
                _navigation.NavigateTo("Reservations", new NavigationParameters());
                _navigation.EventAggregator.GetEvent<UnexpectedErrorEvent>()
                    .Publish($"An unexpected error has occured: {ex.Message}");
            }
        }
    }
}
