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
        private ExtendedObservableCollection<WindowsProcess> items = null;
        private ExtendedObservableCollection<Memory> memoryItems = null;
        private ExtendedObservableCollection<ProcessorDynamic> processorItems = null;

        private IWcfClient wcfClient;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IWcfClient wcfClient)
        {
            //this.LoadDataCommand = new RelayCommand(LoadData);
            this.ClearDataCommand = new RelayCommand(this.ClearData);
            this.items = new ExtendedObservableCollection<WindowsProcess>();
            this.memoryItems = new ExtendedObservableCollection<Memory>();
            this.processorItems = new ExtendedObservableCollection<ProcessorDynamic>();
            this.wcfClient = wcfClient;

            this.LoadWindowsProcessDynamicDataCommand = new AsyncCommand<WindowsProcess[]>(async (cancellationToken) =>
            {
                return await Task.Run(async () =>
                 {
                     var result = await wcfClient.ReadWindowsProcessDynamicDataAsync()
                     .WithCancellation(cancellationToken)
                     // Following statements will be processed in the same thread, won't use caught context (UI)
                     .ConfigureAwait(false);

                     this.Items.RefreshRange(result);
                     return result;
                 });

            });

            this.LoadHardwareStaticDataCommand = new AsyncCommand<HardwareStaticData>(async (cancellationToken) =>
            {
                // CANCEL EXAMPLE
                //await Task.Delay(TimeSpan.FromSeconds(3), cancellationToken).ConfigureAwait(false);
                //var client = new HttpClient();
                //using (var response = await client.GetAsync("www.google.com", cancellationToken).ConfigureAwait(false))
                //{
                //    var data = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);

                //}
                var result = await wcfClient.ReadHardwareStaticDataAsync()
                .WithCancellation(cancellationToken)
                // Following statements will be processed in the same thread, won't use caught context (UI)
                .ConfigureAwait(false);

                this.MemoryItems.RefreshRange(result.Memory);

                return result;
            });

            this.LoadProcessorDynamicDataCommand = new AsyncCommand<bool>(async (cancellationToken) =>
            {
                return await Task.Run(async () =>
                {
                    // Set the task.
                    var neverEndingTask = new TPLFactory().CreateNeverEndingTask(
                        (now, ct) => wcfClient.ReadProcessorDynamicDataAsync(this.ProcessorItems).WithCancellation(ct),
                        cancellationToken);

                    // Start the task.  Post the time.
                    var result = neverEndingTask.Post(DateTimeOffset.Now);

                    // if cancel was not requested task is still ongoing
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        await Task.Delay(1000);
                    }

                    return result;
                });

            });
        }

        ////if (IsInDesignMode)
        ////{
        ////    // Code runs in Blend --> create design time data.
        ////}
        ////else
        ////{
        ////    // Code runs "for real"
        ////}

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

        private void ClearData()
        {
            this.items.ClearAllItems();
            this.memoryItems.ClearAllItems();
        }
    }
}