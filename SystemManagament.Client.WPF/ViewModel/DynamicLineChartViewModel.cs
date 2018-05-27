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
    public class DynamicLineChartViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private double axisMax;
        private double axisMin;
        private WpfObservableRangeCollection<DynamicDataLabel> dynamicData = new WpfObservableRangeCollection<DynamicDataLabel>();

        public DynamicLineChartViewModel(string chartName, string hardwareName)
        {
            this.ChartName = chartName;
            this.HardwareName = hardwareName;
            this.SectionName = this.ChartName + " - " + this.HardwareName;
            this.ChartValuesDictionary = new Dictionary<string, ChartValues<MeasureModel>>();
            //the values property will store our values array
            this.SeriesCollection = new SeriesCollection();

            var mapper = Mappers.Xy<MeasureModel>()
                .X(model => model.DateTime.Ticks) //use DateTime.Ticks as X
                .Y(model => model.Value);           //use the value property as Y

            //lets save the mapper globally.
            Charting.For<MeasureModel>(mapper);

            //lets set how to display the X Labels
            this.DateTimeFormatter = value =>
            {
                return new DateTime((long)value).ToString("mm:ss");
            };

            //AxisStep forces the distance between each separator in the X axis
            this.AxisStep = TimeSpan.FromSeconds(5).Ticks;
            //AxisUnit forces lets the axis know that we are plotting seconds
            //this is not always necessary, but it can prevent wrong labeling
            this.AxisUnit = TimeSpan.TicksPerSecond;

            this.SetAxisLimits(DateTime.Now);
        }

        public new event PropertyChangedEventHandler PropertyChanged;

        public string SectionName { get; set; }

        public string ChartName { get; set; }

        public string HardwareName { get; set; }

        public SeriesCollection SeriesCollection { get; set; }

        public Dictionary<string, ChartValues<MeasureModel>> ChartValuesDictionary { get; set; }

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

        public double AxisStep { get; set; }

        public double AxisMax
        {
            get
            {
                return this.axisMax;
            }

            set
            {
                this.axisMax = value;
                this.OnPropertyChanged("AxisMax");
            }
        }

        public double AxisMin
        {
            get
            {
                return this.axisMin;
            }

            set
            {
                this.axisMin = value;
                this.OnPropertyChanged("AxisMin");
            }
        }

        public Func<double, string> DateTimeFormatter { get; set; }

        public double AxisUnit { get; set; }

        public double AxisYMin { get; set; }

        public double AxisYMax { get; set; }

        public string AxisXTitle { get; set; }

        public string AxisYTitle { get; set; }

        public void SetAxisLimits(DateTime now)
        {
            this.AxisMax = now.Ticks + TimeSpan.FromSeconds(5).Ticks; // lets force the axis to be 5 second ahead
            this.AxisMin = now.Ticks - TimeSpan.FromSeconds(50).Ticks; // and 100 seconds behind
        }

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public class MeasureModel
    {
        public DateTime DateTime { get; set; }

        public double Value { get; set; }
    }
}
