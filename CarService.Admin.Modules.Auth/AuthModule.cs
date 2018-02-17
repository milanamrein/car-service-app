using CarService.Admin.Infrastructure;
using CarService.Admin.Infrastructure.Prism;
using CarService.Admin.Modules.Auth.Views;
using Microsoft.Practices.Unity;
using Prism.Regions;
using Prism.Unity;

namespace CarService.Admin.Modules.Auth
{
    /// <summary>
    /// Authentication module which derives from the ModuleBase
    /// </summary>
    public class AuthModule : ModuleBase
    {

        // Passing dependencies to base class
        public AuthModule(IUnityContainer container, IRegionManager regionManager) 
            : base(container, regionManager)
        {
        }

        // Registering views for navigation
        protected override void Register()
        {
            Container.RegisterTypeForNavigation<Logo>();
            Container.RegisterTypeForNavigation<AuthNavigation>();
            Container.RegisterTypeForNavigation<Login>();
            Container.RegisterTypeForNavigation<Register>();
        }

        // Resolving all views, and adding them to the specified regions to show them at startup
        protected override void Resolve()
        {
            this.RegionManager.AddToRegion(RegionNames.PROFILE_REGION, Container.Resolve<Logo>());
            this.RegionManager.AddToRegion(RegionNames.CONTENT_REGION, Container.Resolve<Login>());
            this.RegionManager.AddToRegion(RegionNames.CONTENT_REGION, Container.Resolve<Register>());
            this.RegionManager.AddToRegion(RegionNames.NAVBAR_REGION, Container.Resolve<AuthNavigation>());
        }
    }
}
