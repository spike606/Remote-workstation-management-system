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

            Messenger.Default.Register<NewMachineMessage>(this, this.NewMachineMessageReceivedHandler);
            Messenger.Default.Register<RemoveMachineMessage>(this, this.RemoveMachineMessageReceivedHandler);
            Messenger.Default.Register<UpdateMachineMessage>(this, this.UpdateMachineMessageReceivedHandler);
        }

        public string TestSetting { get; set; }

        public Dictionary<string, WorkstationSettings> WorkstationsParameters { get; set; }

        public ICommand SendNewMachineMessageCommand { get; private set; }

        public ICommand LoadMachinesCommand { get; private set; }

        public ICommand SaveSettingsCommand { get; private set; }

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
            this.LoadMachinesCommand = new RelayCommand(this.LoadMachines);
            this.SaveSettingsCommand = new RelayCommand(this.SaveSettings);
            this.Exit = new RelayCommand(this.CloseApplication);
        }

        private void LoadUserSettings()
        {
            IConfigProvider configProvider = SimpleIoc.Default.GetInstance<IConfigProvider>();

            configProvider.Load();

            this.WorkstationsParameters = configProvider.WorkstationsParameters;

            // TODO: add global preferences and load them
        }

        private void SendNewMachineMessage()
        {
            Messenger.Default.Send(new NotificationMessage("ShowNewMachineWindow"));
        }

        private void LoadMachines()
        {
            foreach (var entry in this.WorkstationsParameters)
            {
                if (!this.ViewModelTabs.Any(wvm => wvm.ViewModelIdentifier == entry.Key))
                {
                    this.CreateNewTab(entry.Value);
                }
            }
        }

        private void SaveSettings()
        {
            IConfigProvider configProvider = SimpleIoc.Default.GetInstance<IConfigProvider>();
            configProvider.WorkstationsParameters = this.WorkstationsParameters;

            // TODO: save global preferences
            configProvider.Save();
        }

        private void NewMachineMessageReceivedHandler(NewMachineMessage message)
        {
            // TODO: include global preferences when creating views
            var workStationSettings = new WorkstationSettings()
            {
                MachineIdentifier = message.MachineIdentifier,
                MachineName = message.MachineName,
                Uri = message.MachineUri,
                ForceMachineRestartTimeout = 10,
                ForceMachineTurnOffTimeout = 10
            };

            this.WorkstationsParameters[workStationSettings.MachineIdentifier] = workStationSettings;

            this.CreateNewTab(workStationSettings);
        }

        private void UpdateMachineMessageReceivedHandler(UpdateMachineMessage message)
        {
            // TODO: include global preferences when creating views
            var workStationSettings = new WorkstationSettings()
            {
                MachineIdentifier = message.MachineIdentifier,
                MachineName = message.MachineName,
                Uri = message.MachineUri,
                ForceMachineRestartTimeout = 10,
                ForceMachineTurnOffTimeout = 10
            };

            this.WorkstationsParameters[workStationSettings.MachineIdentifier] = workStationSettings;

            var tabToUpdate = this.ViewModelTabs.Where(wvm => wvm.ViewModelIdentifier == message.MachineIdentifier).Single();
            tabToUpdate.LoadSettings(workStationSettings);
        }

        private void RemoveMachineMessageReceivedHandler(RemoveMachineMessage message)
        {
            var tabToRemove = this.ViewModelTabs.Where(wvm => wvm.ViewModelIdentifier == message.MachineIdentifier).Single();
            this.ViewModelTabs.Remove(tabToRemove);

            this.WorkstationsParameters.Remove(message.MachineIdentifier);

            this.SaveSettings();
        }

        private void CreateNewTab(WorkstationSettings workstationSettings)
        {
            IWorkStationViewModelFactory workStationViewModelFactory = SimpleIoc.Default.GetInstance<IWorkStationViewModelFactory>();

            // TODO: include global preferences when creating views
            var workStationViewModel = workStationViewModelFactory.CreateWorkStationViewModel(workstationSettings);

            this.ViewModelTabs.Add(workStationViewModel);
        }

        private void CloseApplication()
        {
            Application.Current.Shutdown();
        }
    }
}