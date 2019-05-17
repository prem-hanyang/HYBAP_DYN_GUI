using System;
using System.ComponentModel.Composition.Hosting;
using System.Windows;
using Prism.Unity;
using Prism.Modularity;
using Microsoft.Practices.Unity;

namespace HYBAP
{
    public partial class HYBAPBootstrapper : UnityBootstrapper
    {
        protected override void ConfigureModuleCatalog()
        {
            var catalog = (ModuleCatalog)ModuleCatalog;
            catalog.AddModule(typeof(Module.Module));
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            SplashScreeen start = new SplashScreeen();
            start.ShowInTaskbar = false;
            start.ShowDialog();

            App.Current.MainWindow = (Window)this.Shell;
            App.Current.MainWindow.Show();
        }

        protected override DependencyObject CreateShell()
        {
            try
            {
                return Container.Resolve<Shell>();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Assert(false);
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
                return null;
            }
        }
    }
}
