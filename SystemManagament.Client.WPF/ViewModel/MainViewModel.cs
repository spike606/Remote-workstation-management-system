using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SystemManagament.Client.WPF.Extensions;
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

        private IWcfClient wcfClient;


        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IWcfClient wcfClient)
        {
            //this.LoadDataCommand = new RelayCommand(LoadData);
            this.ClearDataCommand = new RelayCommand(ClearData);
            this.items = new ExtendedObservableCollection<WindowsProcess>();
            this.memoryItems = new ExtendedObservableCollection<Memory>();
            this.wcfClient = wcfClient;

            LoadWindowsProcessDynamicDataCommand = new AsyncCommand<WindowsProcess[]>(async (cancellationToken) =>
            {
                var result = await wcfClient.ReadWindowsProcessDynamicDataAsync();
                this.Items.RefreshRange(result);

                return result;
            });

            LoadHardwareStaticDataCommand = new AsyncCommand<HardwareStaticData>(async (cancellationToken) =>
            {
                // CANCEL EXAMPLE
                //await Task.Delay(TimeSpan.FromSeconds(3), cancellationToken).ConfigureAwait(false);
                //var client = new HttpClient();
                //using (var response = await client.GetAsync("www.google.com", cancellationToken).ConfigureAwait(false))
                //{
                //    var data = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);

                //}

                var result = await wcfClient.ReadHardwareStaticDataAsync();
                this.MemoryItems.RefreshRange(result.Memory);

                return new HardwareStaticData();
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

        public ExtendedObservableCollection<WindowsProcess> Items
        {
            get
            {
                return items;
            }
            private set
            {
                Set(() => Items, ref items, value);
            }
        }

        public ExtendedObservableCollection<Memory> MemoryItems
        {
            get
            {
                return memoryItems;
            }
            private set
            {
                Set(() => MemoryItems, ref memoryItems, value);
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