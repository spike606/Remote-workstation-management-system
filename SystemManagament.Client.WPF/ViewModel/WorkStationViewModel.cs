using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using LiveCharts;
using LiveCharts.Wpf;
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
        private WpfObservableRangeCollection<WindowsService> windowsService = new WpfObservableRangeCollection<WindowsService>();
        private WpfObservableRangeCollection<WindowsLog> windowsLog = new WpfObservableRangeCollection<WindowsLog>();

        private WpfObservableRangeCollection<HardwareDynamicData> hardwareDynamic = new WpfObservableRangeCollection<HardwareDynamicData>();
        private WpfObservableRangeCollection<DynamicChartViewModel> dynamicChartViewModelProcessorClock = new WpfObservableRangeCollection<DynamicChartViewModel>();

        private WpfObservableRangeCollection<ProcessorStatic> processorStatic = new WpfObservableRangeCollection<ProcessorStatic>();
        private WpfObservableRangeCollection<ProcessorCache> processorCache = new WpfObservableRangeCollection<ProcessorCache>();
        private WpfObservableRangeCollection<Memory> memory = new WpfObservableRangeCollection<Memory>();
        private WpfObservableRangeCollection<BaseBoard> baseBoard = new WpfObservableRangeCollection<BaseBoard>();
        private WpfObservableRangeCollection<VideoController> videoController = new WpfObservableRangeCollection<VideoController>();
        private WpfObservableRangeCollection<NetworkAdapter> networkAdapter = new WpfObservableRangeCollection<NetworkAdapter>();
        private WpfObservableRangeCollection<PnPEntity> pnPEntity = new WpfObservableRangeCollection<PnPEntity>();
        private WpfObservableRangeCollection<CDROMDrive> cDROMDrive = new WpfObservableRangeCollection<CDROMDrive>();
        private WpfObservableRangeCollection<Fan> fan = new WpfObservableRangeCollection<Fan>();
        private WpfObservableRangeCollection<Battery> battery = new WpfObservableRangeCollection<Battery>();
        private WpfObservableRangeCollection<Printer> printer = new WpfObservableRangeCollection<Printer>();
        private WpfObservableRangeCollection<Storage> storage = new WpfObservableRangeCollection<Storage>();

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

        public IAsyncCommand LoadWindowsServiceDynamicDataCommand { get; private set; }

        public IAsyncCommand LoadWindowsLogDynamicDataCommand { get; private set; }

        public IAsyncCommand LoadHardwareDynamicDataCommand { get; private set; }

        public IAsyncCommand LoadHardwareStaticDataCommand { get; private set; }

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

        public WpfObservableRangeCollection<WindowsService> WindowsService
        {
            get
            {
                return this.windowsService;
            }

            private set
            {
                this.Set(() => this.WindowsService, ref this.windowsService, value);
            }
        }

        public WpfObservableRangeCollection<WindowsLog> WindowsLog
        {
            get
            {
                return this.windowsLog;
            }

            private set
            {
                this.Set(() => this.WindowsLog, ref this.windowsLog, value);
            }
        }

        public WpfObservableRangeCollection<HardwareDynamicData> HardwareDynamic
        {
            get
            {
                return this.hardwareDynamic;
            }

            private set
            {
                this.Set(() => this.HardwareDynamic, ref this.hardwareDynamic, value);
            }
        }

        public WpfObservableRangeCollection<DynamicChartViewModel> DynamicChartViewModelProcessorClock
        {
            get
            {
                return this.dynamicChartViewModelProcessorClock;
            }

            private set
            {
                this.Set(() => this.DynamicChartViewModelProcessorClock, ref this.dynamicChartViewModelProcessorClock, value);
            }
        }

        public WpfObservableRangeCollection<ProcessorStatic> ProcessorStatic
        {
            get
            {
                return this.processorStatic;
            }

            private set
            {
                this.Set(() => this.ProcessorStatic, ref this.processorStatic, value);
            }
        }

        public WpfObservableRangeCollection<ProcessorCache> ProcessorCache
        {
            get
            {
                return this.processorCache;
            }

            private set
            {
                this.Set(() => this.ProcessorCache, ref this.processorCache, value);
            }
        }

        public WpfObservableRangeCollection<Memory> Memory
        {
            get
            {
                return this.memory;
            }

            private set
            {
                this.Set(() => this.Memory, ref this.memory, value);
            }
        }

        public WpfObservableRangeCollection<BaseBoard> BaseBoard
        {
            get
            {
                return this.baseBoard;
            }

            private set
            {
                this.Set(() => this.BaseBoard, ref this.baseBoard, value);
            }
        }

        public WpfObservableRangeCollection<VideoController> VideoController
        {
            get
            {
                return this.videoController;
            }

            private set
            {
                this.Set(() => this.VideoController, ref this.videoController, value);
            }
        }

        public WpfObservableRangeCollection<NetworkAdapter> NetworkAdapter
        {
            get
            {
                return this.networkAdapter;
            }

            private set
            {
                this.Set(() => this.NetworkAdapter, ref this.networkAdapter, value);
            }
        }

        public WpfObservableRangeCollection<PnPEntity> PnPEntity
        {
            get
            {
                return this.pnPEntity;
            }

            private set
            {
                this.Set(() => this.PnPEntity, ref this.pnPEntity, value);
            }
        }

        public WpfObservableRangeCollection<CDROMDrive> CDROMDrive
        {
            get
            {
                return this.cDROMDrive;
            }

            private set
            {
                this.Set(() => this.CDROMDrive, ref this.cDROMDrive, value);
            }
        }

        public WpfObservableRangeCollection<Fan> Fan
        {
            get
            {
                return this.fan;
            }

            private set
            {
                this.Set(() => this.Fan, ref this.fan, value);
            }
        }

        public WpfObservableRangeCollection<Printer> Printer
        {
            get
            {
                return this.printer;
            }

            private set
            {
                this.Set(() => this.Printer, ref this.printer, value);
            }
        }

        public WpfObservableRangeCollection<Battery> Battery
        {
            get
            {
                return this.battery;
            }

            private set
            {
                this.Set(() => this.Battery, ref this.battery, value);
            }
        }

        public WpfObservableRangeCollection<Storage> Storage
        {
            get
            {
                return this.storage;
            }

            private set
            {
                this.Set(() => this.Storage, ref this.storage, value);
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
            this.LoadWindowsServiceDynamicDataCommand = this.commandFactory.CreateWindowsServiceDynamicDataCommand(this.WindowsService);
            this.LoadWindowsLogDynamicDataCommand = this.commandFactory.CreateWindowsLogDynamicDataCommand(this.WindowsLog);
            this.LoadHardwareDynamicDataCommand = this.commandFactory.CreateHardwareDynamicDataCommand(
                this.HardwareDynamic,
                this.DynamicChartViewModelProcessorClock);
            this.LoadHardwareStaticDataCommand = this.commandFactory.CreateHardwareStaticDataCommand(
                this.ProcessorStatic,
                this.ProcessorCache,
                this.Memory,
                this.BaseBoard,
                this.VideoController,
                this.NetworkAdapter,
                this.PnPEntity,
                this.CDROMDrive,
                this.Fan,
                this.Printer,
                this.Battery,
                this.Storage);

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
