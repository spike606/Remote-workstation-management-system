using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.Components;

namespace SystemMonitor.HardwareStatic.WMI
{
    public interface IWMIDataExtractor
    {
        Processor ExtractDataProcessor(ManagementObject managementObjectWin32_Processor, List<ManagementObject> managementObjectWin32_CacheMemory);

        Memory ExtractDataMemory(ManagementObject managementObjectWin32_PhysicalMemory);
    }
}
