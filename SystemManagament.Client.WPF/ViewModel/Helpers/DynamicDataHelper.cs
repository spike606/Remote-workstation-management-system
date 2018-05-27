using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public void DrawDynamicLineChartForHardwareSensor(
            WpfObservableRangeCollection<DynamicLineChartViewModel> dynamicChartViewModel,
            Sensor sensor,
            string hardwareName)
        {
            // In case of "No Value" returned from SystemManagamentLib do not generate charts
            if (sensor.Value == "No value")
            {
                return;
            }

            DynamicLineChartViewModel chartViewModel = this.GetOrCreateNewLineChartIfNotExists(dynamicChartViewModel, sensor, hardwareName);

            this.AddNewValuesToDynamicViewLabels(chartViewModel, sensor);

            this.AddNewLineSeriesIfNotExists(sensor, chartViewModel);

            this.AdjustChartValuesRange(sensor, chartViewModel);

            this.AddNewValuesToLineSeries(sensor, chartViewModel);

            chartViewModel.SetAxisLimits(DateTime.Now);
        }

        public void DrawDynamicPieChartForHardwareSensor(
            WpfObservableRangeCollection<DynamicPieChartViewModel> dynamicChartViewModel,
            Sensor sensor,
            string hardwareName)
        {
            if (sensor.Value == "No value")
            {
                return;
            }

            DynamicPieChartViewModel chartViewModel = this.GetOrCreateNewPieChartIfNotExists(dynamicChartViewModel, sensor, hardwareName);
            this.AddNewValuesToDynamicViewLabels(chartViewModel, sensor);

            // In case of "SmallData" sensor type, Open Hardware Monitor returns also total amount of data
            // which is not requested by view
            if (sensor.SensorType == "SmallData" && sensor.SensorName.ToLower().Contains("total"))
            {
                return;
            }

            this.AddNewPieChartSliceIfNotExists(sensor, chartViewModel);
            this.RefreshValueInPieSeries(sensor, chartViewModel);

            // Open Hardware Monitor defines load for hard disk as "Used Space" abd does not provide "Free Memoery Space"
            // In order to display it as pie chart we need to define mocked sensor - "Not Used Space"
            // to calculate not used memory part
            if (sensor.SensorType == "Load" && sensor.Unit == "%" && sensor.SensorName == "Used Space")
            {
                Sensor notUsedMemoryMockedSensor = new Sensor()
                {
                    Unit = "%",
                    SensorName = "Not Used Space",
                    SensorType = "Load",
                    Value = (100d - double.Parse(sensor.Value)).ToString(),
                };

                this.AddNewValuesToDynamicViewLabels(chartViewModel, notUsedMemoryMockedSensor);
                this.AddNewPieChartSliceIfNotExists(notUsedMemoryMockedSensor, chartViewModel);
                this.RefreshValueInPieSeries(notUsedMemoryMockedSensor, chartViewModel);
            }
        }

        private DynamicLineChartViewModel GetOrCreateNewLineChartIfNotExists(
            WpfObservableRangeCollection<DynamicLineChartViewModel> dynamicChartViewModel,
            Sensor sensor,
            string hardwareName)
        {
            DynamicLineChartViewModel chartViewModel = dynamicChartViewModel
                    .Where(x => x.ChartName == sensor.SensorType && x.HardwareName == hardwareName)
                    .SingleOrDefault();

            if (chartViewModel == null)
            {
                chartViewModel = new DynamicLineChartViewModel(sensor.SensorType, hardwareName);
                this.InvokeInUIThread((Action)(() => dynamicChartViewModel.Add(chartViewModel)));
            }

            return chartViewModel;
        }

        private DynamicPieChartViewModel GetOrCreateNewPieChartIfNotExists(
            WpfObservableRangeCollection<DynamicPieChartViewModel> dynamicChartViewModel,
            Sensor sensor,
            string hardwareName)
        {
            DynamicPieChartViewModel chartViewModel = dynamicChartViewModel
                    .Where(x => x.ChartName == sensor.SensorType && x.HardwareName == hardwareName)
                    .SingleOrDefault();

            if (chartViewModel == null)
            {
                chartViewModel = new DynamicPieChartViewModel(sensor.SensorType, hardwareName);
                this.InvokeInUIThread((Action)(() => dynamicChartViewModel.Add(chartViewModel)));
            }

            return chartViewModel;
        }

        private void AddNewValuesToDynamicViewLabels(DynamicLineChartViewModel chartViewModel, Sensor sensor)
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

        private void AddNewValuesToDynamicViewLabels(DynamicPieChartViewModel chartViewModel, Sensor sensor)
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

        private void InvokeInUIThread(Action action)
        {
            App.Current.Dispatcher.Invoke(DispatcherPriority.DataBind, action);
        }

        private void AddNewLineSeriesIfNotExists(Sensor sensor, DynamicLineChartViewModel chartViewModel)
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

        private void AddNewPieChartSliceIfNotExists(Sensor sensor, DynamicPieChartViewModel chartViewModel)
        {
            this.InvokeInUIThread((Action)(() =>
            {
                if (!chartViewModel.SeriesCollection.Any(x => x.Title == sensor.SensorName))
                {
                    PieSeries pieSeries = new PieSeries()
                    {
                        Title = sensor.SensorName,
                        LabelPoint = chartViewModel.PointLabel,
                        DataLabels = true
                    };

                    chartViewModel.PieValuesDictionary.Add(sensor.SensorName, new ChartValues<double>());
                    pieSeries.Values = chartViewModel.PieValuesDictionary[sensor.SensorName];
                    chartViewModel.SeriesCollection.Add(pieSeries);
                }
            }));
        }

        private void AdjustChartValuesRange(Sensor sensor, DynamicLineChartViewModel chartViewModel)
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

        private void AddNewValuesToLineSeries(Sensor sensor, DynamicLineChartViewModel chartViewModel)
        {
            chartViewModel.ChartValuesDictionary[sensor.SensorName].Add(new MeasureModel()
            {
                Value = double.Parse(sensor.Value),
                DateTime = DateTime.Now
            });
        }

        private void RefreshValueInPieSeries(Sensor sensor, DynamicPieChartViewModel chartViewModel)
        {
            if (chartViewModel.PieValuesDictionary[sensor.SensorName].Any())
            {
                chartViewModel.PieValuesDictionary[sensor.SensorName].RemoveAt(0);
            }

            chartViewModel.PieValuesDictionary[sensor.SensorName].Insert(0, double.Parse(sensor.Value));
        }
    }
}
