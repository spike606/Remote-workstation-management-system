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
            DynamicChartViewModel chartViewModel = this.GetOrCreateNewChartIfNotExists(dynamicChartViewModel, sensor);

            this.AddNewLineSeriesIfNotExists(sensor, chartViewModel);

            this.AdjustChartValuesRange(sensor, chartViewModel);

            this.AddNewValuesToLineSeries(sensor, chartViewModel);

            chartViewModel.SetAxisLimits(DateTime.Now);
        }

        private DynamicChartViewModel GetOrCreateNewChartIfNotExists(WpfObservableRangeCollection<DynamicChartViewModel> dynamicChartViewModel, Sensor sensor)
        {
            DynamicChartViewModel chartViewModel = null;
            if (!dynamicChartViewModel
                .Any(x => x.ChartName == sensor.SensorType))
            {
                chartViewModel = new DynamicChartViewModel(sensor.SensorType, sensor.SensorType);
                this.InvokeInUIThread((Action)(() => dynamicChartViewModel.Add(chartViewModel)));
            }
            else
            {
                chartViewModel = dynamicChartViewModel
                    .Single(x => x.ChartName == sensor.SensorType);
            }

            return chartViewModel;
        }

        private void InvokeInUIThread(Action action)
        {
            App.Current.Dispatcher.Invoke(DispatcherPriority.DataBind, action);
        }

        private void AddNewLineSeriesIfNotExists(Sensor sensor, DynamicChartViewModel chartViewModel)
        {
            this.InvokeInUIThread((Action)(() =>
            {
                if (!chartViewModel.SeriesCollection.Any(x => x.Title == sensor.SensorName))
                {
                    LineSeries lineSeries = new LineSeries();
                    lineSeries.Title = sensor.SensorName;
                    lineSeries.PointGeometry = null;
                    chartViewModel.ChartValuesDictionary.Add(sensor.SensorName, new ChartValues<MeasureModel>());
                    lineSeries.Values = chartViewModel.ChartValuesDictionary[sensor.SensorName];
                    chartViewModel.SeriesCollection.Add(lineSeries);
                }
            }));
        }

        private void AdjustChartValuesRange(Sensor sensor, DynamicChartViewModel chartViewModel)
        {
            switch (sensor.SensorType)
            {
                case "Load":
                    chartViewModel.AxisYMax = 100;
                    chartViewModel.AxisYMin = 0;
                    chartViewModel.AxisXTitle = "Time";
                    chartViewModel.AxisYTitle = "Load";
                    break;
                case "Clock":
                    chartViewModel.AxisYMax = 3500;// double.Parse(sensor.MaxValue) + 200;
                    chartViewModel.AxisYMin = 0;
                    break;

                default:
                    break;
            }


        }

        private void AddNewValuesToLineSeries(Sensor sensor, DynamicChartViewModel chartViewModel)
        {
            chartViewModel.ChartValuesDictionary[sensor.SensorName].Add(new MeasureModel()
            {
                Value = double.Parse(sensor.Value),
                DateTime = DateTime.Now
            });
        }
    }
}
