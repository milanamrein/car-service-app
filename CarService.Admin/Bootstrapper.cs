using Prism.Unity;
using Microsoft.Practices.Unity;
using System.Windows;
using Prism.Modularity;
using CarService.Admin.Modules.Auth;
using CarService.Admin.Modules.Reservation;
using CarService.Admin.Modules.User;
using CarService.Admin.Infrastructure.Prism;
using CarService.Admin.Modules.Worksheet;
using CarService.Admin.Infrastructure.Services;
using CarService.Admin.ViewModels;

namespace CarService.Admin
{
    /// <summary>
    /// Bootstrapper of the application
    /// Initializes all the services, modules etc. 
    /// that we are going to be using
    /// </summary>
    public class Bootstrapper : UnityBootstrapper
    {
        /// <summary>
        /// Resolves the Main window of the application
        /// </summary>
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        /// <summary>
        /// Initializes the Main window
        /// </summary>
        protected override void InitializeShell()
        {
            Application.Current.MainWindow = (Window)Shell;
            Application.Current.MainWindow.DataContext = 
                new ShellViewModel(Application.Current.MainWindow);
            Application.Current.MainWindow.Show();
        }

        /// <summary>
        /// Registering global dependencies
        /// </summary>
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            // Registering base Navigation and Services
            Container.RegisterType<INavigation, Navigation>();
            Container.RegisterType<ICarService, CarService.Admin.Infrastructure.Services.CarService>();
            Container.RegisterType<IAuthService, AuthService>();
            Container.RegisterType<IMechanicService, MechanicService>();
            Container.RegisterType<IMaterialService, MaterialService>();
            Container.RegisterType<IWorksheetService, WorksheetService>();
        }

        /// <summary>
        /// Registering modules
        /// </summary>
        protected override void ConfigureModuleCatalog()
        {
            // Registering the AuthModule
            ModuleCatalog.AddModule(new ModuleInfo {
                ModuleName = typeof(AuthModule).Name,
                ModuleType = typeof(AuthModule).AssemblyQualifiedName,
            });

            // Registering the ReservationModule
            ModuleCatalog.AddModule(new ModuleInfo
            {
                ModuleName = typeof(ReservationModule).Name,
                ModuleType = typeof(ReservationModule).AssemblyQualifiedName,
            });

            // Registering the UserModule
            ModuleCatalog.AddModule(new ModuleInfo
            {
                ModuleName = typeof(UserModule).Name,
                ModuleType = typeof(UserModule).AssemblyQualifiedName,
            });

            // Registering the WorksheetModule
            ModuleCatalog.AddModule(new ModuleInfo
            {
                ModuleName = typeof(WorksheetModule).Name,
                ModuleType = typeof(WorksheetModule).AssemblyQualifiedName,
            });
        }
    }
}
