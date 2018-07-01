/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:SystemManagament.Client.WPF"
                           x:Key="Locator" />
  </Application.Resources>
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using System;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using SystemManagament.Client.WPF.Factories;
using SystemManagament.Client.WPF.Settings;
using SystemManagament.Client.WPF.Validator;
using SystemManagament.Client.WPF.ViewModel.Helpers;
using SystemManagament.Client.WPF.ViewModel.Wcf;

namespace SystemManagament.Client.WPF.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        private static AppSettings appSettingsInstance;

        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<WorkStationViewModel>();
            SimpleIoc.Default.Register<IWcfClient, WcfClient>();
            SimpleIoc.Default.Register<ICommandFactory, CommandFactory>();
            SimpleIoc.Default.Register<IDynamicDataHelper, DynamicDataHelper>();
            SimpleIoc.Default.Register<IUintValidator, UintValidator>();
            SimpleIoc.Default.Register<IProcessClient, ProcessClient>();
            SimpleIoc.Default.Register<IConfigProvider, ConfigProvider>();
            SimpleIoc.Default.Register<IWorkStationViewModelFactory, WorkStationViewModelFactory>();
        }

        public static AppSettings Instance
        {
            get
            {
                if (appSettingsInstance == null)
                {
                    appSettingsInstance = new AppSettings();
                }

                return appSettingsInstance;
            }
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public WorkStationViewModel WorkStationViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<WorkStationViewModel>();
            }
        }

        public WcfClient WcfClient
        {
            get
            {
                return ServiceLocator.Current.GetInstance<WcfClient>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}