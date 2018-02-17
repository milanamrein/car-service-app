using CarService.Admin.Infrastructure.Prism;
using Prism.Commands;
using Prism.Mvvm;

namespace CarService.Admin.Modules.Auth.ViewModels
{
    /// <summary>
    /// Class which navigates between the Login and Register pages
    /// </summary>
    public class AuthNavigationViewModel : BindableBase
    {
        private readonly INavigation _navigation;

        public AuthNavigationViewModel(INavigation navigation)
        {
            _navigation = navigation;
        }

        public DelegateCommand<string> NavigateCommand => _navigation.NavigateCommand;
    }
}
