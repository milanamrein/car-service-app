using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService.Admin.Infrastructure.Prism
{
    /// <summary>
    /// Base abstract class for implementing all the application modules
    /// Responsible for registering, resolving types and injecting views
    /// </summary>
    public abstract class ModuleBase : IModule
    {
        protected IUnityContainer Container { get; private set; }
        protected IRegionManager RegionManager { get; private set; }

        public ModuleBase(IUnityContainer container, IRegionManager regionManager)
        {
            Container = container;
            RegionManager = regionManager;
        }

        public void Initialize()
        {
            this.Register();
            this.Resolve();
        }

        // methods for registering and resolving types
        protected abstract void Register();
        protected abstract void Resolve();
    }
}
