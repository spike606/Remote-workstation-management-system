using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
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

        private ExtendedObservableCollection<WindowsProcess> items = new ExtendedObservableCollection<WindowsProcess>();
        private ExtendedObservableCollection<Memory> memoryItems = new ExtendedObservableCollection<Memory>();
        private ExtendedObservableCollection<ProcessorDynamic> processorItems = new ExtendedObservableCollection<ProcessorDynamic>();

        private ExtendedObservableCollection<CurrentUser> currentUser = new ExtendedObservableCollection<CurrentUser>();
        private ExtendedObservableCollection<ClaimDuplicate> currentUserClaims = new ExtendedObservableCollection<ClaimDuplicate>();
        private ExtendedObservableCollection<GroupDuplicate> currentUserGroups = new ExtendedObservableCollection<GroupDuplicate>();

        private ExtendedObservableCollection<OS> operatingSystem = new ExtendedObservableCollection<OS>();
        private ExtendedObservableCollection<Bios> bios = new ExtendedObservableCollection<Bios>();


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

        public ExtendedObservableCollection<WindowsProcess> Items
        {
            get
            {
                return this.items;
            }

            private set
            {
                this.Set(() => this.Items, ref this.items, value);
            }
        }

        public ExtendedObservableCollection<Memory> MemoryItems
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

        public ExtendedObservableCollection<ProcessorDynamic> ProcessorItems
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

        public ExtendedObservableCollection<CurrentUser> CurrentUser
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

        public ExtendedObservableCollection<ClaimDuplicate> CurrentUserClaims
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

        public ExtendedObservableCollection<GroupDuplicate> CurrentUserGroups
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

        public ExtendedObservableCollection<OS> OperatingSystem
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

        public ExtendedObservableCollection<Bios> Bios
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

        private void InitializeCommands()
        {
            this.ClearDataCommand = this.commandFactory.CreateClearDataCommand(this.ClearData);
            this.LoadWindowsProcessDynamicDataCommand = this.commandFactory.CreateWindowsProcessDynamicDataCommand(this.Items);
            this.LoadHardwareStaticDataCommand = this.commandFactory.CreateHardwareStaticDataCommand(this.MemoryItems);
            this.LoadProcessorDynamicDataCommand = this.commandFactory.CreateProcessorDynamicDataCommand(this.ProcessorItems);
            this.LoadSoftwareStaticDataCommand = this.commandFactory.CreateSoftwareStaticDataCommand(
                this.CurrentUser,
                this.CurrentUserClaims,
                this.CurrentUserGroups,
                this.OperatingSystem,
                this.Bios);
        }

        private void ClearData()
        {
            this.items.ClearAllItems();
            this.memoryItems.ClearAllItems();
        }
    }
}
