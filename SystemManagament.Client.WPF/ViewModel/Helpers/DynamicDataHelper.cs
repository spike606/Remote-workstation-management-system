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
    public class DynamicDataHelper : IDynamicDataHelper
    {
        public void DrawDynamicChartForHardwareSensor(
            WpfObservableRangeCollection<DynamicChartViewModel> dynamicChartViewModel,
            Sensor sensor,
            string hardwareName)
        {
            DynamicChartViewModel chartViewModel = this.GetOrCreateNewChartIfNotExists(dynamicChartViewModel, sensor, hardwareName);

            this.AddNewValuesToDynamicViewLabels(chartViewModel, sensor);

            this.AddNewLineSeriesIfNotExists(sensor, chartViewModel);

            this.AdjustChartValuesRange(sensor, chartViewModel);

            this.AddNewValuesToLineSeries(sensor, chartViewModel);

            chartViewModel.SetAxisLimits(DateTime.Now);
        }

        private void AddNewValuesToDynamicViewLabels(DynamicChartViewModel chartViewModel, Sensor sensor)
        {
            DynamicDataLabel dynamiDataLabel = chartViewModel.DynamicData
                .Where(ddl => ddl.Name == sensor.SensorName)
                .SingleOrDefault();

            if (dynamiDataLabel == null)
            {
                chartViewModel.DynamicData.Add(new DynamicDataLabel()
                {
                    Name = sensor.SensorName,
                    Value = sensor.Value,
                    Unit = sensor.Unit
                });
            }
            else
            {
                dynamiDataLabel.Value = sensor.Value;
            }
        }

        private DynamicChartViewModel GetOrCreateNewChartIfNotExists(
            WpfObservableRangeCollection<DynamicChartViewModel> dynamicChartViewModel,
            Sensor sensor,
            string hardwareName)
        {
            DynamicChartViewModel chartViewModel = dynamicChartViewModel
                    .Where(x => x.ChartName == sensor.SensorType && x.HardwareName == hardwareName)
                    .SingleOrDefault();

            if (chartViewModel == null)
            {
                chartViewModel = new DynamicChartViewModel(sensor.SensorType, hardwareName);
                this.InvokeInUIThread((Action)(() => dynamicChartViewModel.Add(chartViewModel)));
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
                case "Power":
                    chartViewModel.AxisYMax = double.Parse(sensor.MaxValue) > chartViewModel.AxisYMax ?
                        double.Parse(sensor.MaxValue) : chartViewModel.AxisYMax + 2; //2 is a bufor for better readibility
                    chartViewModel.AxisYMin = 0;
                    chartViewModel.AxisXTitle = "Time";
                    chartViewModel.AxisYTitle = "Power";
                    break;
                case "Temperature":
                    chartViewModel.AxisYMax = double.Parse(sensor.MaxValue) > chartViewModel.AxisYMax ?
                        double.Parse(sensor.MaxValue) : chartViewModel.AxisYMax + 5; //5 is a bufor for better readibility
                    chartViewModel.AxisYMin = 0;
                    chartViewModel.AxisXTitle = "Time";
                    chartViewModel.AxisYTitle = "Temperature";
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
