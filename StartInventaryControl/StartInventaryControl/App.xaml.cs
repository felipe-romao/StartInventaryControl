using NLog;
using StartInventaryControl.Views;
using System;
using System.IO;
using System.Reflection;
using System.Windows;

namespace StartInventaryControl
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static Logger LOGGER = LogManager.GetCurrentClassLogger();

        public App()
        {
            this.Dispatcher.UnhandledException += (sender, args) => MessageBox.Show(args.Exception.ToString(), "Start", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static string HOME_DIR
        {
            get;
            private set;
        }

        public void AppStartup(object sender, StartupEventArgs e)
        {
            LOGGER.Info("Starting application.");
            try
            {
                App.HOME_DIR = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                var bootstrapper = new Bootstrapper();
                var applicationController = new ApplicationController(bootstrapper);
                applicationController.Initialize();

                LOGGER.Info("Application successfully started.");
            }
            catch(Exception ex)
            {
                LOGGER.Error($"Error while initialized application: {ex.ToString()}");
                Environment.Exit(1);
            }
        }

        public void AppExit(object sender, ExitEventArgs e)
        {
            LOGGER.Info("Application finished.");
        }
    }
}
