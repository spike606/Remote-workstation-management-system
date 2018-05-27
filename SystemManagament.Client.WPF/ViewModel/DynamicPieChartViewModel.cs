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
    public class DynamicPieChartViewModel : ViewModelBase
    {
        private WpfObservableRangeCollection<DynamicDataLabel> dynamicData = new WpfObservableRangeCollection<DynamicDataLabel>();

        public DynamicPieChartViewModel(string chartName, string hardwareName)
        {
            this.ChartName = chartName;
            this.HardwareName = hardwareName;
            this.SectionName = this.ChartName + " - " + this.HardwareName;
            this.PointLabel = chartPoint =>
                string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            this.SeriesCollection = new SeriesCollection();
            this.PieValuesDictionary = new Dictionary<string, ChartValues<double>>();
        }

        public Dictionary<string, ChartValues<double>> PieValuesDictionary { get; set; }

        public string SectionName { get; set; }

        public string ChartName { get; set; }

        public string HardwareName { get; set; }

        public SeriesCollection SeriesCollection { get; set; }

        public Func<ChartPoint, string> PointLabel { get; set; }

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
}
