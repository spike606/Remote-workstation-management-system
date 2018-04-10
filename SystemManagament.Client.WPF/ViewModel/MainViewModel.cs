using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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
        private ObservableCollection<string> items = null;


        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            this.LoadDataCommand = new RelayCommand(LoadData);
            this.ClearDataCommand = new RelayCommand(ClearData);
            this.items = new ObservableCollection<string>();
        }

            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}

        public ObservableCollection<string> Items
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

        public ICommand LoadDataCommand
        {
            get;
            private set;
        }

        public ICommand ClearDataCommand
        {
            get;
            private set;
        }

        private async void LoadData()
        {
            var client = new WorkstationMonitorServiceClient("NetTcpBinding_IWorkstationMonitorService");
            var processes = await client.ReadWindowsProcessDynamicDataAsync();
            for (int i = 1; i <= 10; ++i)
            {
                // only insertion/deletion/moving fires up OnPropertyChanged from INotifyPropertyChanged interface
                this.items.Add(processes[i].Name);
            };
        }

        private void ClearData()
        {
            this.items.Clear();
        }
    }
}