using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using LiveCharts;
using LiveCharts.Wpf;
using Microsoft.VisualStudio.Language.Intellisense;
using SystemManagament.Client.WPF.Comparer;
using SystemManagament.Client.WPF.Extensions;
using SystemManagament.Client.WPF.WorkstationMonitorServiceReference;

namespace SystemManagament.Client.WPF.ViewModel.Wcf
{
    [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1118:ParameterMustNotSpanMultipleLines", Justification = "Reviewed.")]
    public class WcfClient : IWcfClient
    {
        public async Task<HardwareStaticData> ReadHardwareStaticDataAsync()
        {
            using (var client = this.GetNewWorkstationMonitorServiceClient())
            {
                return await client.ReadHardwareStaticDataAsync();
            }
        }

        public async Task<HardwareDynamicData> ReadHardwareDynamicDataAsync(
            WpfObservableRangeCollection<HardwareDynamicData> hardwareDynamicObservableCollection,
            WpfObservableRangeCollection<DynamicChartViewModel> dynamicChartViewModelProcessorClock,
            CancellationToken cancellationToken)
        {
            using (var client = this.GetNewWorkstationMonitorServiceClient())
            {
                var result = await client.ReadHardwareDynamicDataAsync();
                if (!cancellationToken.IsCancellationRequested)
                {
                    foreach (var processor in result.Processor)
                    {
                        foreach (var load in processor.Load)
                        {
                            // Add viewModel if not exists
                            DynamicChartViewModel chartViewModel;
                            //var clock = result.Processor.First().Load.First();
                            if (!dynamicChartViewModelProcessorClock
                                .Any(x => x.ChartName == load.SensorType))
                            {
                                chartViewModel = new DynamicChartViewModel(load.SensorType, load.SensorType);
                                App.Current.Dispatcher.Invoke(
                                    DispatcherPriority.DataBind,
                                    (Action)(() => dynamicChartViewModelProcessorClock.Add(chartViewModel)));
                            }

                            chartViewModel = dynamicChartViewModelProcessorClock
                                .Single(x => x.ChartName == load.SensorType);
                            LineSeries lineSeries = null;

                            App.Current.Dispatcher.Invoke(
                                DispatcherPriority.DataBind,
                                (Action)(() =>
                                {
                                    if (!chartViewModel.SeriesCollection.Any(x => x.Title == load.SensorName))
                                    {
                                        lineSeries = new LineSeries();
                                        lineSeries.Title = load.SensorName;
                                        chartViewModel.ChartValuesDictionary.Add(load.SensorName, new ChartValues<MeasureModel>());
                                        lineSeries.Values = chartViewModel.ChartValuesDictionary[load.SensorName];
                                        chartViewModel.SeriesCollection.Add(lineSeries);
                                    }
                                }));

                            chartViewModel.ChartValuesDictionary[load.SensorName].Add(new MeasureModel()
                            {
                                Value = double.Parse(load.Value),
                                DateTime = DateTime.Now
                            });

                            chartViewModel.SetAxisLimits(DateTime.Now);
                        }
                    }
                }

                return result;
            }
        }

        public async Task<SoftwareStaticData> ReadSoftwareStaticDataAsync()
        {
            using (var client = this.GetNewWorkstationMonitorServiceClient())
            {
                return await client.ReadSoftwareStaticDataAsync();
            }
        }

        public async Task<WindowsProcess[]> ReadWindowsProcessDynamicDataAsync(
            WpfObservableRangeCollection<WindowsProcess> windowsProcessDynamicObservableCollection,
            CancellationToken cancellationToken)
        {
            using (var client = this.GetNewWorkstationMonitorServiceClient())
            {
                var result = await client.ReadWindowsProcessDynamicDataAsync();
                if (!cancellationToken.IsCancellationRequested)
                {
                    windowsProcessDynamicObservableCollection.ReplaceRange(result, new WindowsProcessComparer());
                }

                return result;
            }
        }

        public async Task<WindowsService[]> ReadWindowsServiceDynamicDataAsync(
            WpfObservableRangeCollection<WindowsService> windowsServiceDynamicObservableCollection,
            CancellationToken cancellationToken)
        {
            using (var client = this.GetNewWorkstationMonitorServiceClient())
            {
                var result = await client.ReadWindowsServiceDynamicDataAsync();
                if (!cancellationToken.IsCancellationRequested)
                {
                    windowsServiceDynamicObservableCollection.ReplaceRange(result, new WindowsServiceComparer());
                }

                return result;
            }
        }

        public async Task<WindowsLog[]> ReadWindowsLogDynamicDataAsync()
        {
            using (var client = this.GetNewWorkstationMonitorServiceClient())
            {
                return await client.ReadWindowsLogDynamicDataAsync();
            }
        }

        private WorkstationMonitorServiceClient GetNewWorkstationMonitorServiceClient()
        {
            return new WorkstationMonitorServiceClient("NetTcpBinding_IWorkstationMonitorService");
        }
    }
}
