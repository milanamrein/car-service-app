using CarService.Admin.Infrastructure.Prism;
using CarService.Admin.Modules.Reservation.Views;
using Microsoft.Practices.Unity;
using Prism.Regions;
using Prism.Unity;

namespace CarService.Admin.Modules.Reservation
{
    /// <summary>
    /// Reservation module which derives from ModuleBase class
    /// </summary>
    public class ReservationModule : ModuleBase
    {
        public ReservationModule(IUnityContainer container, IRegionManager regionManager) 
            : base(container, regionManager)
        {
        }

        // Registering views for navigation
        protected override void Register()
        {
            Container.RegisterTypeForNavigation<Reservations>();
            Container.RegisterTypeForNavigation<Navbar>();
        }
        
        protected override void Resolve()
        {                      

        }
    }
}
