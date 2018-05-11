using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Language.Intellisense;
using SystemManagament.Client.WPF.Extensions;
using SystemManagament.Client.WPF.WorkstationMonitorServiceReference;

namespace SystemManagament.Client.WPF.ViewModel.Wcf
{
    public class WcfClient : IWcfClient
    {
        public WorkstationMonitorServiceClient WorkstationMonitorServiceClient { get; set; }
            = new WorkstationMonitorServiceClient("NetTcpBinding_IWorkstationMonitorService");

        public async Task<WindowsProcess[]> ReadWindowsProcessDynamicDataAsync(BulkObservableCollection<WindowsProcess> windowsProcessDynamicObservableCollection)
        {
            var result = await this.WorkstationMonitorServiceClient.ReadWindowsProcessDynamicDataAsync();
            windowsProcessDynamicObservableCollection.BeginBulkOperation();
            windowsProcessDynamicObservableCollection.Clear();
            windowsProcessDynamicObservableCollection.AddRange(result);
            windowsProcessDynamicObservableCollection.EndBulkOperation();

            return result;
        }

        public async Task<HardwareStaticData> ReadHardwareStaticDataAsync()
        {
            return await this.WorkstationMonitorServiceClient.ReadHardwareStaticDataAsync();
        }

        public async Task<ProcessorDynamic[]> ReadProcessorDynamicDataAsync(ExtendedObservableCollection<ProcessorDynamic> processorDynamicObservableCollection)
        {
            var result = await this.WorkstationMonitorServiceClient.ReadProcessorDynamicDataAsync();
            processorDynamicObservableCollection.RefreshRange(result);

            return result;
        }

        public async Task<SoftwareStaticData> ReadSoftwareStaticDataAsync()
        {
            return await this.WorkstationMonitorServiceClient.ReadSoftwareStaticDataAsync();
        }
    }
}
