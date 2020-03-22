using System;
using System.Threading.Tasks;
using System.Windows;

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
