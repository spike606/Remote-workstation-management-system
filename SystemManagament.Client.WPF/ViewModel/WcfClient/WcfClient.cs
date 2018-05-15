using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Language.Intellisense;
using SystemManagament.Client.WPF.Comparer;
using SystemManagament.Client.WPF.Extensions;
using SystemManagament.Client.WPF.WorkstationMonitorServiceReference;

namespace SystemManagament.Client.WPF.ViewModel.Wcf
{
    public class WcfClient : IWcfClient
    {
        public WorkstationMonitorServiceClient WorkstationMonitorServiceClient { get; set; }
            = new WorkstationMonitorServiceClient("NetTcpBinding_IWorkstationMonitorService");

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

        public async Task<HardwareStaticData> ReadHardwareStaticDataAsync()
        {
            using (var client = this.GetNewWorkstationMonitorServiceClient())
            {
                return await client.ReadHardwareStaticDataAsync();
            }
        }

        public async Task<ProcessorDynamic[]> ReadProcessorDynamicDataAsync(ObservableRangeCollection<ProcessorDynamic> processorDynamicObservableCollection)
        {
            using (var client = this.GetNewWorkstationMonitorServiceClient())
            {
                var result = await client.ReadProcessorDynamicDataAsync();
                processorDynamicObservableCollection.ReplaceRange(result);

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
