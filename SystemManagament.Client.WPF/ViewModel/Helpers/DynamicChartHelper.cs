using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using LiveCharts;
using LiveCharts.Wpf;
using SystemManagament.Client.WPF.Extensions;
using SystemManagament.Client.WPF.WorkstationMonitorServiceReference;

namespace SystemManagament.Client.WPF.ViewModel.Helpers
{
    public class DynamicChartHelper : IDynamicChartHelper
    {
        public void DrawDynamicChartForSensor(WpfObservableRangeCollection<DynamicChartViewModel> dynamicChartViewModel, Sensor sensor)
        {
            DynamicChartViewModel chartViewModel;
            if (!dynamicChartViewModel
                .Any(x => x.ChartName == sensor.SensorType))
            {
                chartViewModel = new DynamicChartViewModel(sensor.SensorType, sensor.SensorType);
                this.InvokeInUIThread((Action)(() => dynamicChartViewModel.Add(chartViewModel)));
            }

            chartViewModel = dynamicChartViewModel
                .Single(x => x.ChartName == sensor.SensorType);

            LineSeries lineSeries = null;

            this.InvokeInUIThread((Action)(() =>
            {
                if (!chartViewModel.SeriesCollection.Any(x => x.Title == sensor.SensorName))
                {
                    lineSeries = new LineSeries();
                    lineSeries.Title = sensor.SensorName;
                    chartViewModel.ChartValuesDictionary.Add(sensor.SensorName, new ChartValues<MeasureModel>());
                    lineSeries.Values = chartViewModel.ChartValuesDictionary[sensor.SensorName];
                    chartViewModel.SeriesCollection.Add(lineSeries);
                }
            }));

            chartViewModel.ChartValuesDictionary[sensor.SensorName].Add(new MeasureModel()
            {
                Value = double.Parse(sensor.Value),
                DateTime = DateTime.Now
            });

            chartViewModel.SetAxisLimits(DateTime.Now);
        }

        private void InvokeInUIThread(Action action)
        {
            App.Current.Dispatcher.Invoke(DispatcherPriority.DataBind, action);
        }
    }
}
