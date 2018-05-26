using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;
using GalaSoft.MvvmLight;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;
using SystemManagament.Client.WPF.Extensions;
using SystemManagament.Client.WPF.WorkstationMonitorServiceReference;

namespace SystemManagament.Client.WPF.ViewModel
{
    public class DynamicDataViewModel : ViewModelBase
    {
        private WpfObservableRangeCollection<DynamicDataLabel> dynamicData = new WpfObservableRangeCollection<DynamicDataLabel>();

        public DynamicDataViewModel(string viewName)
        {
            this.ViewName = viewName;
        }

        public string ViewName { get; set; }

        public WpfObservableRangeCollection<DynamicDataLabel> DynamicData
        {
            get
            {
                return this.dynamicData;
            }

            private set
            {
                this.Set(() => this.DynamicData, ref this.dynamicData, value);
            }
        }
    }

    public class DynamicDataLabel : INotifyPropertyChanged
    {
        private string value;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name { get; set; }

        public string Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
                this.OnPropertyChanged("Value");
            }
        }

        public string Unit { get; set; }

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
