using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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
        private ExtendedObservableCollection<WindowsProcess> items = new ExtendedObservableCollection<WindowsProcess>();
        private ExtendedObservableCollection<Memory> memoryItems = new ExtendedObservableCollection<Memory>();
        private ExtendedObservableCollection<ProcessorDynamic> processorItems = new ExtendedObservableCollection<ProcessorDynamic>();

        private IWcfClient wcfClient;
        private ICommandFactory commandFactory;

        public MainViewModel(IWcfClient wcfClient, ICommandFactory commandFactory)
        {
            this.wcfClient = wcfClient;
            this.commandFactory = commandFactory;

            this.InitializeCommands();
        }

        public IAsyncCommand LoadWindowsProcessDynamicDataCommand { get; private set; }

        public IAsyncCommand LoadHardwareStaticDataCommand { get; private set; }

        public IAsyncCommand LoadProcessorDynamicDataCommand { get; private set; }

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

        public ICommand ClearDataCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>

        private void InitializeCommands()
        {
            this.ClearDataCommand = this.commandFactory.CreateClearDataCommand(this.ClearData);
            this.LoadWindowsProcessDynamicDataCommand = this.commandFactory.CreateWindowsProcessDynamicDataCommand(this.Items);
            this.LoadHardwareStaticDataCommand = this.commandFactory.CreateHardwareStaticDataCommand(this.MemoryItems);
            this.LoadProcessorDynamicDataCommand = this.commandFactory.CreateProcessorDynamicDataCommand(this.ProcessorItems);
        }

        ////if (IsInDesignMode)
        ////{
        ////    // Code runs in Blend --> create design time data.
        ////}
        ////else
        ////{
        ////    // Code runs "for real"
        ////}

        private void ClearData()
        {
            this.items.ClearAllItems();
            this.memoryItems.ClearAllItems();
        }
    }
}