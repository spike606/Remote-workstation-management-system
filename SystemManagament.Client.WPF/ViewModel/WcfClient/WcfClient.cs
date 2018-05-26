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
using SystemManagament.Client.WPF.ViewModel.Helpers;
using SystemManagament.Client.WPF.WorkstationMonitorServiceReference;

namespace SystemManagament.Client.WPF.ViewModel.Wcf
{
    [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1118:ParameterMustNotSpanMultipleLines", Justification = "Reviewed.")]
    public class WcfClient : IWcfClient
    {
        private IDynamicDataHelper dynamicDataHelper;

        public WcfClient(IDynamicDataHelper dynamicDataHelper)
        {
            this.dynamicDataHelper = dynamicDataHelper;
        }

        public async Task<HardwareStaticData> ReadHardwareStaticDataAsync()
        {
            using (var client = this.GetNewWorkstationMonitorServiceClient())
            {
                return await client.ReadHardwareStaticDataAsync();
            }
        }

        public async Task<HardwareDynamicData> ReadHardwareDynamicDataAsync(
            WpfObservableRangeCollection<HardwareDynamicData> hardwareDynamicObservableCollection,
            WpfObservableRangeCollection<DynamicDataViewModel> dynamicDataViewModelProcessorClock,
            WpfObservableRangeCollection<DynamicChartViewModel> dynamicChartViewModelProcessorPower,
            WpfObservableRangeCollection<DynamicChartViewModel> dynamicChartViewModelProcessorTemp,
            WpfObservableRangeCollection<DynamicChartViewModel> dynamicChartViewModelProcessorLoad,
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
                            this.dynamicDataHelper.DrawDynamicChartForSensor(dynamicChartViewModelProcessorLoad, load);
                        }

                        foreach (var clock in processor.Clock)
                        {
                            this.dynamicDataHelper.DrawDynamicDataForSensor(dynamicDataViewModelProcessorClock, clock);
                        }

                        foreach (var power in processor.Power)
                        {
                            this.dynamicDataHelper.DrawDynamicChartForSensor(dynamicChartViewModelProcessorPower, power);
                        }

                        foreach (var temperature in processor.Temperature)
                        {
                            this.dynamicDataHelper.DrawDynamicChartForSensor(dynamicChartViewModelProcessorTemp, temperature);
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
