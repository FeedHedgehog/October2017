using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace October.Modules.SystemManager
{
    public class SystemManagerModule : IModule
    {
        IRegionManager _regionManager;
        IUnityContainer _container;

        public SystemManagerModule(IRegionManager regionManager, IUnityContainer container)
        {
            _regionManager = regionManager;
            _container = container;
        }

        public void Initialize()
        {            
            _container.RegisterTypeForNavigation<PasswordSettings>(SystemManagerParameterNames.PasswordSettings);
            
        }
    }
}
