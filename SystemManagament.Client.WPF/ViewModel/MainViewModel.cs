using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using SystemManagament.Client.WPF.Extensions;
using SystemManagament.Client.WPF.Factories;
using SystemManagament.Client.WPF.ViewModel.Commands;
using SystemManagament.Client.WPF.ViewModel.Commands.Abstract;
using SystemManagament.Client.WPF.ViewModel.Wcf;
using SystemManagament.Client.WPF.WorkstationMonitorServiceReference;

namespace SystemManagament.Client.WPF.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<WorkStationViewModel> viewModelTabs = new ObservableCollection<WorkStationViewModel>();

        private IWcfClient wcfClient;
        private ICommandFactory commandFactory;

        public MainViewModel(IWcfClient wcfClient, ICommandFactory commandFactory)
        {
            this.wcfClient = wcfClient;
            this.commandFactory = commandFactory;

            this.InitializeCommands();
        }

        public ICommand NewTab { get; private set; }

        public ICommand Exit { get; private set; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>

        private void InitializeCommands()
        {
            this.NewTab = new RelayCommand(this.CreateNewTab);
            this.Exit = new RelayCommand(this.CloseApplication);

        }

        public ObservableCollection<WorkStationViewModel> ViewModelTabs
        {
            get
            {
                return this.viewModelTabs;
            }

            private set
            {
                this.Set(() => this.ViewModelTabs, ref this.viewModelTabs, value);
            }
        }

        ////if (IsInDesignMode)
        ////{
        ////    // Code runs in Blend --> create design time data.
        ////}
        ////else
        ////{
        ////    // Code runs "for real"
        ////}

        private void CreateNewTab()
        {
            this.ViewModelTabs.Add(
                new WorkStationViewModel(SimpleIoc.Default.GetInstance<IWcfClient>(), SimpleIoc.Default.GetInstance<ICommandFactory>()));
        }

        private void CloseApplication()
        {
            Application.Current.Shutdown();
        }
    }
}