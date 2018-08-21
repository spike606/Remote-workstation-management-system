using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        private PreferencesViewModel preferencesViewModel = new PreferencesViewModel();

        public MainViewModel()
        {
            Application.Current.MainWindow.Closing += this.OnWindowClosing;

            this.InitializeCommands();
            this.InitializeMessageHandlers();
            this.LoadUserSettings();
        }

        public Dictionary<string, WorkstationSettings> WorkstationsParameters { get; set; }

        public uint DelayBetweenCalls_WindowsProcess { get; private set; }

        public uint DelayBetweenCalls_WindowsService { get; private set; }

        public uint DelayBetweenCalls_HardwareDynamic { get; private set; }

        public bool DynamicHardwareLogs_Include { get; private set; }

        public string DynamicHardwareLogs_Path { get; private set; }

        public ICommand SendNewMachineMessageCommand { get; private set; }

        public ICommand PreferencesCommand { get; private set; }

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

        public void OnWindowClosing(object sender, CancelEventArgs e)
        {
            this.CloseApplication();
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
            this.PreferencesCommand = new RelayCommand(this.SendShowPreferencesWindowMessage);
            this.LoadMachinesCommand = new RelayCommand(this.LoadMachines);
            this.SaveSettingsCommand = new RelayCommand(this.SaveSettings);
            this.Exit = new RelayCommand(this.CloseApplication);
        }

        private void InitializeMessageHandlers()
        {
            Messenger.Default.Register<NewMachineMessage>(this, this.NewMachineMessageReceivedHandler);
            Messenger.Default.Register<RemoveMachineMessage>(this, this.RemoveMachineMessageReceivedHandler);
            Messenger.Default.Register<UpdateMachineMessage>(this, this.UpdateMachineMessageReceivedHandler);
            Messenger.Default.Register<UpdatePreferencesMessage>(this, this.UpdatePreferencesMessageReceivedHandler);
            Messenger.Default.Register<ErrorMessage>(this, this.ErrorMessageReceivedHandler);
        }

        private void LoadUserSettings()
        {
            IConfigProvider configProvider = SimpleIoc.Default.GetInstance<IConfigProvider>();

            configProvider.Load();

            this.WorkstationsParameters = configProvider.WorkstationsParameters;
            this.DelayBetweenCalls_HardwareDynamic = configProvider.DelayBetweenCalls_HardwareDynamic;
            this.DelayBetweenCalls_WindowsProcess = configProvider.DelayBetweenCalls_WindowsProcess;
            this.DelayBetweenCalls_WindowsService = configProvider.DelayBetweenCalls_WindowsService;
            this.DynamicHardwareLogs_Include = configProvider.DynamicHardwareLogs_Include;
            this.DynamicHardwareLogs_Path = configProvider.DynamicHardwareLogs_Path;
        }

        private void SendNewMachineMessage()
        {
            Messenger.Default.Send(new NotificationMessage("ShowNewMachineWindow"));
        }

        private void SendShowPreferencesWindowMessage()
        {
            Messenger.Default.Send(new ShowPreferencesWindowMessage()
            {
                UpdatePreferencesMessage = new UpdatePreferencesMessage()
                {
                    DelayBetweenCalls_HardwareDynamic = this.DelayBetweenCalls_HardwareDynamic,
                    DelayBetweenCalls_WindowsService = this.DelayBetweenCalls_WindowsService,
                    DelayBetweenCalls_WindowsProcess = this.DelayBetweenCalls_WindowsProcess,
                    DynamicHardwareLogs_Include = this.DynamicHardwareLogs_Include,
                    DynamicHardwareLogs_Path = this.DynamicHardwareLogs_Path,
                }
            });
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

            configProvider.DelayBetweenCalls_HardwareDynamic = this.DelayBetweenCalls_HardwareDynamic;
            configProvider.DelayBetweenCalls_WindowsProcess = this.DelayBetweenCalls_WindowsProcess;
            configProvider.DelayBetweenCalls_WindowsService = this.DelayBetweenCalls_WindowsService;
            configProvider.DynamicHardwareLogs_Path = this.DynamicHardwareLogs_Path;
            configProvider.DynamicHardwareLogs_Include = this.DynamicHardwareLogs_Include;
            configProvider.Save();
        }

        private void CloseApplication()
        {
            foreach (var viewModel in this.ViewModelTabs)
            {
                viewModel.CancelAllCommands();
            }

            Application.Current.Shutdown();
        }

        private void NewMachineMessageReceivedHandler(NewMachineMessage message)
        {
            var workStationSettings = new WorkstationSettings()
            {
                MachineIdentifier = message.MachineIdentifier,
                MachineName = message.MachineName,
                ClientCertificateSubjectName = message.ClientCertificateSubjectName,
                NewMachineCertificateSubjectName = message.NewMachineCertificateSubjectName,
                Uri = message.MachineUri,
                ForceMachineRestartTimeout = 10,
                ForceMachineTurnOffTimeout = 10
            };

            this.WorkstationsParameters[workStationSettings.MachineIdentifier] = workStationSettings;

            this.CreateNewTab(workStationSettings);
        }

        private void RemoveMachineMessageReceivedHandler(RemoveMachineMessage message)
        {
            var tabToRemove = this.ViewModelTabs.Where(wvm => wvm.ViewModelIdentifier == message.MachineIdentifier).Single();
            this.ViewModelTabs.Remove(tabToRemove);

            this.WorkstationsParameters.Remove(message.MachineIdentifier);

            this.SaveSettings();
        }

        private void UpdateMachineMessageReceivedHandler(UpdateMachineMessage message)
        {
            var workStationSettings = new WorkstationSettings()
            {
                MachineIdentifier = message.MachineIdentifier,
                MachineName = message.MachineName,
                ClientCertificateSubjectName = message.ClientCertificateSubjectName,
                NewMachineCertificateSubjectName = message.NewMachineCertificateSubjectName,
                Uri = message.MachineUri,
                ForceMachineRestartTimeout = 10,
                ForceMachineTurnOffTimeout = 10
            };

            this.WorkstationsParameters[workStationSettings.MachineIdentifier] = workStationSettings;
            this.SaveSettings();
            var tabToUpdate = this.ViewModelTabs.Where(wvm => wvm.ViewModelIdentifier == message.MachineIdentifier).Single();
            tabToUpdate.LoadSettings(workStationSettings);
        }

        private void UpdatePreferencesMessageReceivedHandler(UpdatePreferencesMessage message)
        {
            this.DelayBetweenCalls_HardwareDynamic = message.DelayBetweenCalls_HardwareDynamic;
            this.DelayBetweenCalls_WindowsProcess = message.DelayBetweenCalls_WindowsProcess;
            this.DelayBetweenCalls_WindowsService = message.DelayBetweenCalls_WindowsService;
            this.DynamicHardwareLogs_Include = message.DynamicHardwareLogs_Include;
            this.DynamicHardwareLogs_Path = message.DynamicHardwareLogs_Path;

            this.SaveSettings();
        }

        private void ErrorMessageReceivedHandler(ErrorMessage errorMessage)
        {
            MessageBox.Show(
                errorMessage.Message,
                "Connection Error",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }

        private void CreateNewTab(WorkstationSettings workstationSettings)
        {
            IWorkStationViewModelFactory workStationViewModelFactory = SimpleIoc.Default.GetInstance<IWorkStationViewModelFactory>(Guid.NewGuid().ToString());

            var workStationViewModel = workStationViewModelFactory.CreateWorkStationViewModel(workstationSettings);

            this.ViewModelTabs.Add(workStationViewModel);
        }
    }
}