using System;
using System.Windows;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace HYBAP
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");

#if (DEBUG)
            RunInDebugMode();
#else
            RunInReleaseMode();
#endif

#if (VM)
            try
            {
                VM_LicenseChecker.VM_CheckLicense();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Environment.Exit(1);
            }
#endif

            this.ShutdownMode = ShutdownMode.OnMainWindowClose;
        }

        private static void RunInDebugMode()
        {
            HYBAPBootstrapper bootstrapper = new HYBAPBootstrapper();
            bootstrapper.Run();
        }

        private static void RunInReleaseMode()
        {
            AppDomain.CurrentDomain.UnhandledException += AppDomainUnhandledException;
            try
            {
                HYBAPBootstrapper bootstrapper = new HYBAPBootstrapper();
                bootstrapper.Run();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private static void AppDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            HandleException(e.ExceptionObject as Exception);
        }

        private static void HandleException(Exception ex)
        {
            if (ex == null)
            {
                return;
            }
            ExceptionPolicy.HandleException(ex, "Default Policy");
            MessageBox.Show(HYBAP.Properties.Resources.UnhandledException);
            Environment.Exit(1);
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            HYBAP.Properties.Settings.Default.Upgrade();
            HYBAP.Properties.Settings.Default.Save();
        }
    }
}
