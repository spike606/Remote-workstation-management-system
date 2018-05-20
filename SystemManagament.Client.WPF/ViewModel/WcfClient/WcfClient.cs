using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                    //hardwareDynamicObservableCollection.ReplaceRange(result, new WindowsServiceComparer());

                    //foreach (var processor in result.Processor)
                    //{
                    //    foreach (var clock in processor.Clock)
                    //    {
                    var clock = result.Processor.First().Load.First();
                            if (!dynamicChartViewModelProcessorClock
                                .Any(x => x.ChartName == clock.SensorName))
                            {
                        App.Current.Dispatcher.Invoke(DispatcherPriority.DataBind, (Action)(() => dynamicChartViewModelProcessorClock.Add(
                            new DynamicChartViewModel(clock.SensorName, clock.SensorName))));

                    }

                            var chart = dynamicChartViewModelProcessorClock.Single(x => x.ChartName == clock.SensorName);
                            chart.Collection.Add(new MeasureModel()
                            {
                                Value = double.Parse(clock.Value),
                                DateTime = DateTime.Now
                            });

                            chart.SetAxisLimits(DateTime.Now);
                    //    }
                    //}
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
