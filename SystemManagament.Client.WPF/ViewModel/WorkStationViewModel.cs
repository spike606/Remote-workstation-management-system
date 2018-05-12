using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using Microsoft.VisualStudio.Language.Intellisense;
using SystemManagament.Client.WPF.Extensions;
using SystemManagament.Client.WPF.Factories;
using SystemManagament.Client.WPF.ViewModel.Commands.Abstract;
using SystemManagament.Client.WPF.ViewModel.Wcf;
using SystemManagament.Client.WPF.WorkstationMonitorServiceReference;

namespace SystemManagament.Client.WPF.ViewModel
{
    public class WorkStationViewModel : ViewModelBase
    {
        private IWcfClient wcfClient;
        private ICommandFactory commandFactory;

        private WpfObservableRangeCollection<WindowsProcess> windowsProcess = new WpfObservableRangeCollection<WindowsProcess>();
        private WpfObservableRangeCollection<Memory> memoryItems = new WpfObservableRangeCollection<Memory>();
        private WpfObservableRangeCollection<ProcessorDynamic> processorItems = new WpfObservableRangeCollection<ProcessorDynamic>();

        private WpfObservableRangeCollection<CurrentUser> currentUser = new WpfObservableRangeCollection<CurrentUser>();
        private WpfObservableRangeCollection<ClaimDuplicate> currentUserClaims = new WpfObservableRangeCollection<ClaimDuplicate>();
        private WpfObservableRangeCollection<GroupDuplicate> currentUserGroups = new WpfObservableRangeCollection<GroupDuplicate>();

        private WpfObservableRangeCollection<OS> operatingSystem = new WpfObservableRangeCollection<OS>();
        private WpfObservableRangeCollection<Bios> bios = new WpfObservableRangeCollection<Bios>();
        private WpfObservableRangeCollection<InstalledProgram> installedProgram = new WpfObservableRangeCollection<InstalledProgram>();
        private WpfObservableRangeCollection<MicrosoftWindowsUpdate> microsoftWindowsUpdate = new WpfObservableRangeCollection<MicrosoftWindowsUpdate>();
        private WpfObservableRangeCollection<StartupCommand> startupCommand = new WpfObservableRangeCollection<StartupCommand>();
        private WpfObservableRangeCollection<LocalUser> localUser = new WpfObservableRangeCollection<LocalUser>();

        public WorkStationViewModel(IWcfClient wcfClient, ICommandFactory commandFactory)
        {
            this.wcfClient = wcfClient;
            this.commandFactory = commandFactory;

            this.InitializeCommands();
        }

        public IAsyncCommand LoadWindowsProcessDynamicDataCommand { get; private set; }

        public IAsyncCommand LoadHardwareStaticDataCommand { get; private set; }

        public IAsyncCommand LoadProcessorDynamicDataCommand { get; private set; }

        public IAsyncCommand LoadSoftwareStaticDataCommand { get; private set; }

        public ICommand ClearDataCommand { get; private set; }

        public WpfObservableRangeCollection<WindowsProcess> WindowsProcess
        {
            get
            {
                return this.windowsProcess;
            }

            private set
            {
                this.Set(() => this.WindowsProcess, ref this.windowsProcess, value);
            }
        }

        public WpfObservableRangeCollection<Memory> MemoryItems
        {
            get
            {
                return this.memoryItems;
            }

            private set
            {
                this.Set(() => this.MemoryItems, ref this.memoryItems, value);
            }
        }

        public WpfObservableRangeCollection<ProcessorDynamic> ProcessorItems
        {
            get
            {
                return this.processorItems;
            }

            private set
            {
                this.Set(() => this.ProcessorItems, ref this.processorItems, value);
            }
        }

        public WpfObservableRangeCollection<CurrentUser> CurrentUser
        {
            get
            {
                return this.currentUser;
            }

            private set
            {
                this.Set(() => this.CurrentUser, ref this.currentUser, value);
            }
        }

        public WpfObservableRangeCollection<ClaimDuplicate> CurrentUserClaims
        {
            get
            {
                return this.currentUserClaims;
            }

            private set
            {
                this.Set(() => this.CurrentUserClaims, ref this.currentUserClaims, value);
            }
        }

        public WpfObservableRangeCollection<GroupDuplicate> CurrentUserGroups
        {
            get
            {
                return this.currentUserGroups;
            }

            private set
            {
                this.Set(() => this.CurrentUserGroups, ref this.currentUserGroups, value);
            }
        }

        public WpfObservableRangeCollection<OS> OperatingSystem
        {
            get
            {
                return this.operatingSystem;
            }

            private set
            {
                this.Set(() => this.OperatingSystem, ref this.operatingSystem, value);
            }
        }

        public WpfObservableRangeCollection<Bios> Bios
        {
            get
            {
                return this.bios;
            }

            private set
            {
                this.Set(() => this.Bios, ref this.bios, value);
            }
        }

        public WpfObservableRangeCollection<InstalledProgram> InstalledProgram
        {
            get
            {
                return this.installedProgram;
            }

            private set
            {
                this.Set(() => this.InstalledProgram, ref this.installedProgram, value);
            }
        }

        public WpfObservableRangeCollection<MicrosoftWindowsUpdate> MicrosoftWindowsUpdate
        {
            get
            {
                return this.microsoftWindowsUpdate;
            }

            private set
            {
                this.Set(() => this.MicrosoftWindowsUpdate, ref this.microsoftWindowsUpdate, value);
            }
        }

        public WpfObservableRangeCollection<StartupCommand> StartupCommand
        {
            get
            {
                return this.startupCommand;
            }

            private set
            {
                this.Set(() => this.StartupCommand, ref this.startupCommand, value);
            }
        }

        public WpfObservableRangeCollection<LocalUser> LocalUser
        {
            get
            {
                return this.localUser;
            }

            private set
            {
                this.Set(() => this.LocalUser, ref this.localUser, value);
            }
        }

        private void InitializeCommands()
        {
            this.ClearDataCommand = this.commandFactory.CreateClearDataCommand(this.ClearData);
            this.LoadWindowsProcessDynamicDataCommand = this.commandFactory.CreateWindowsProcessDynamicDataCommand(this.WindowsProcess);
            this.LoadHardwareStaticDataCommand = this.commandFactory.CreateHardwareStaticDataCommand(this.MemoryItems);
            this.LoadProcessorDynamicDataCommand = this.commandFactory.CreateProcessorDynamicDataCommand(this.ProcessorItems);
            this.LoadSoftwareStaticDataCommand = this.commandFactory.CreateSoftwareStaticDataCommand(
                this.CurrentUser,
                this.CurrentUserClaims,
                this.CurrentUserGroups,
                this.OperatingSystem,
                this.Bios,
                this.InstalledProgram,
                this.MicrosoftWindowsUpdate,
                this.StartupCommand,
                this.LocalUser);
        }

        private void ClearData()
        {
            //this.windowsProcess.ClearAllItems();
            //this.memoryItems.ClearAllItems();
        }
    }
}
