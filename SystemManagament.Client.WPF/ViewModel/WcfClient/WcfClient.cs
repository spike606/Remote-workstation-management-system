using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Client.WPF.WorkstationMonitorServiceReference;

namespace SystemManagament.Client.WPF.ViewModel.Wcf
{
    public class WcfClient : IWcfClient
    {
        public WorkstationMonitorServiceClient workstationMonitorServiceClient { get; set; }
            = new WorkstationMonitorServiceClient("NetTcpBinding_IWorkstationMonitorService");

        public async Task<WindowsProcess[]> ReadWindowsProcessDynamicDataAsync()
        {
            return await workstationMonitorServiceClient.ReadWindowsProcessDynamicDataAsync();
        }

        public async Task<HardwareStaticData> ReadHardwareStaticDataAsync()
        {
            return await workstationMonitorServiceClient.ReadHardwareStaticDataAsync();
        }
    }
}
