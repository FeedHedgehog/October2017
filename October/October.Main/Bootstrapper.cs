using Microsoft.Practices.Unity;
using October.Basic.Contracts;
using October.DataAcess.DataAcessService;
using October.Main;
using October.Main.Views;
using October.Modules.SystemManager;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace October.Main
{
    public class Bootstrapper : UnityBootstrapper
    {

        protected override DependencyObject CreateShell()
        {
            return Container.TryResolve<LoginWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow = (Window)this.Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            var catalog = (ModuleCatalog)ModuleCatalog;
            catalog.AddModule(typeof(SystemManagerModule));
        }

        protected override void ConfigureContainer()
        {
            Container.RegisterType<LoginWindow>();
            Container.RegisterType<MainWindow>();

            Container.RegisterType<IMenu, MenuService>(new ContainerControlledLifetimeManager());
            base.ConfigureContainer();

            
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();
            ViewModelLocationProvider.SetDefaultViewTypeToViewModelTypeResolver(viewType =>
            {
                var viewName = viewType.FullName;
                viewName = viewName.Replace(".Views.", ".ViewModels.");
                var viewAssemblyName = viewType.Assembly.FullName;
                var suffix = viewName.EndsWith("View") ? "Model" : "ViewModel";
                var viewModelName = String.Format(CultureInfo.InvariantCulture, "{0}{1}", viewName, suffix);
                var assembly = viewType.Assembly;
                var type = assembly.GetType(viewModelName, true);
                return type;
            });
        }

    }
}
