using CarService.Admin.Infrastructure.Prism;
using CarService.Admin.Modules.Worksheet.Views;
using Microsoft.Practices.Unity;
using Prism.Regions;
using Prism.Unity;

namespace CarService.Admin.Modules.Worksheet
{
    /// <summary>
    /// Worksheet module which derives from ModuleBase class
    /// </summary>
    public class WorksheetModule : ModuleBase
    {
        public WorksheetModule(IUnityContainer container, IRegionManager regionManager) 
            : base(container, regionManager)
        {
        }

        // Registering views for navigation
        protected override void Register()
        {
            Container.RegisterTypeForNavigation<AddWorksheet>();
            Container.RegisterTypeForNavigation<CreateWorksheet>();            
            Container.RegisterTypeForNavigation<Worksheets>();
            Container.RegisterTypeForNavigation<Views.Worksheet>();
        }

        protected override void Resolve()
        {
            
        }
    }
}
