using System;
using System.Collections.Generic;
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
using GalaSoft.MvvmLight.Messaging;
using SystemManagament.Client.WPF.Extensions;
using SystemManagament.Client.WPF.Factories;
using SystemManagament.Client.WPF.Settings;
using SystemManagament.Client.WPF.Validator;
using SystemManagament.Client.WPF.ViewModel.Commands;
using SystemManagament.Client.WPF.ViewModel.Commands.Abstract;
using SystemManagament.Client.WPF.ViewModel.Messages;
using SystemManagament.Client.WPF.ViewModel.Wcf;
using SystemManagament.Client.WPF.WorkstationMonitorService;

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
        private ObservableCollection<WorkStationViewModel> viewModelTabs = new ObservableCollection<WorkStationViewModel>();
        private NewMachineViewModel newMachineViewModel = new NewMachineViewModel();

        public MainViewModel()
        {
            this.InitializeCommands();
            this.LoadUserSettings();

            Messenger.Default.Register<NewMachineMessage>(this, this.CreateNewTabMessageReceived);
        }

        public string TestSetting { get; set; }

        public Dictionary<string, WorkstationSettings> WorkstationsParameters { get; set; }

        public ICommand SendNewMachineMessageCommand { get; private set; }

        public ICommand Exit { get; private set; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
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

        private void InitializeCommands()
        {
            this.SendNewMachineMessageCommand = new RelayCommand(this.SendNewMachineMessage);
            this.Exit = new RelayCommand(this.CloseApplication);
        }

        private void LoadUserSettings()
        {
            IConfigProvider configProvider = SimpleIoc.Default.GetInstance<IConfigProvider>();

            configProvider.Load();

            this.TestSetting = configProvider.TestSetting;
            this.WorkstationsParameters = configProvider.WorkstationsParameters;
        }

        private void SendNewMachineMessage()
        {
            Messenger.Default.Send(new NotificationMessage("ShowNewMachineWindow"));
        }

        private void CreateNewTabMessageReceived(NewMachineMessage newMachineMessage)
        {
            this.WorkstationsParameters[newMachineMessage.MachineName] =
                new WorkstationSettings()
                {
                    Uri = newMachineMessage.MachineUri,
                    ForceMachineRestartTimeout = 10,
                    ForceMachineTurnOffTimeout = 10
                };

            IWorkStationViewModelFactory workStationViewModelFactory = SimpleIoc.Default.GetInstance<IWorkStationViewModelFactory>();

            var workStationViewModel = workStationViewModelFactory.CreateWorkStationViewModel(
                newMachineMessage.MachineName,
                new WorkstationSettings()
                {
                    Uri = newMachineMessage.MachineUri,
                    ForceMachineRestartTimeout = 10,
                    ForceMachineTurnOffTimeout = 10
                });

            this.ViewModelTabs.Add(workStationViewModel);
        }

        private void CloseApplication()
        {
            Application.Current.Shutdown();
        }
    }
}