using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Ioc;
using SystemManagament.Client.WPF.Settings;

namespace SystemManagament.Client.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //SimpleIoc.Default.Register<IConfigProvider, ConfigProvider>();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            IConfigProvider configProvider = SimpleIoc.Default.GetInstance<IConfigProvider>();
            configProvider.TestSetting = "new value " + new Random().NextDouble();
            configProvider.Save();
        }
    }
}
