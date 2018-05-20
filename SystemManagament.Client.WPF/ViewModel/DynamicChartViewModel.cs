using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using GalaSoft.MvvmLight;
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;

namespace SystemManagament.Client.WPF.ViewModel
{
    public class DynamicChartViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private double _axisMax;
        private double _axisMin;

        public string ChartName { get; set; }

        public ChartValues<MeasureModel> Collection { get; set; }

        public double AxisStep { get; set; }

        public double AxisMax
        {
            get { return _axisMax; }
            set
            {
                _axisMax = value;
                OnPropertyChanged("AxisMax");
            }
        }
        public double AxisMin
        {
            get { return _axisMin; }
            set
            {
                _axisMin = value;
                OnPropertyChanged("AxisMin");
            }
        }
        public Func<double, string> DateTimeFormatter { get; set; }
        public double AxisUnit { get; set; }
        public DynamicChartViewModel(string chartName, string chartTitle)
        {
            this.ChartName = chartName;

            //the values property will store our values array
            this.Collection = new ChartValues<MeasureModel>();

            var mapper = Mappers.Xy<MeasureModel>()
                .X(model => model.DateTime.Ticks)   //use DateTime.Ticks as X
                .Y(model => model.Value);           //use the value property as Y

            //lets save the mapper globally.
            Charting.For<MeasureModel>(mapper);


            //lets set how to display the X Labels
            DateTimeFormatter = value => value % 100000000 == 0 ? new DateTime((long)value).ToString("mm:ss") : string.Empty;

            //AxisStep forces the distance between each separator in the X axis
            AxisStep = TimeSpan.FromSeconds(1).Ticks;
            //AxisUnit forces lets the axis know that we are plotting seconds
            //this is not always necessary, but it can prevent wrong labeling
            AxisUnit = TimeSpan.TicksPerSecond;

            SetAxisLimits(DateTime.Now);
        }

        public void SetAxisLimits(DateTime now)
        {
            AxisMax = now.Ticks + TimeSpan.FromSeconds(100).Ticks; // lets force the axis to be 1 second ahead
            AxisMin = now.Ticks - TimeSpan.FromSeconds(100).Ticks; // and 8 seconds behind
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class MeasureModel
    {
        public DateTime DateTime { get; set; }
        public double Value { get; set; }
    }
}
