using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using System.Windows;
using Weather.UI.Support;

namespace Weather.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            GlobalExceptionHandlerRegistration();

            // register dependencies
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddWpfDependencies();

            // pull mainwindow and launch
            var services = serviceCollection.BuildServiceProvider();
            var mainWindow = services.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        #region private methods
        private void GlobalExceptionHandlerRegistration()
        {   
            DispatcherUnhandledException += (sender, e) =>
            {
                e.Handled = true;
                HandleException(e.Exception);
            };
            this.Dispatcher.UnhandledException += (sender , e ) =>
            {
                e.Handled = true;
                HandleException(e.Exception);
            };

            TaskScheduler.UnobservedTaskException += (sender, e) =>
            {
                HandleException(e.Exception);
            };
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                HandleException(e.ExceptionObject as Exception);
            };

        }
       
        private void HandleException(Exception exp)
        {
            MessageBox.Show(exp.Message);
        }
        #endregion

    }
}
