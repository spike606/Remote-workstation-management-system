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

        DiskDrive ExtractDataDiskDrive(ManagementObject managementObjectWin32_DiskDrive);

        LogicalDisk ExtractDataLogicalDisk(ManagementObject managementObjectWin32_LogicalDisk);

        CDROMDrive ExtractDataCDROMDriveDisk(ManagementObject managementObjectWin32_LogicalDisk);

        BaseBoard ExtractDataBaseBoard(ManagementObject managementObjectWin32_BaseBoard);

        Fan ExtractDataFan(ManagementObject managementObjectWin32_Fan);

        Battery ExtractDataBattery(ManagementObject managementObjectWin32_Battery);

        NetworkAdapter ExtractDataNetworkAdapter(ManagementObject managementObjectMSFT_NetAdapter);

        Printer ExtractDataPrinter(ManagementObject managementObjectWin32_Printer);

        VideoController ExtractDataVideoController(ManagementObject managementObjectWin32_VideoController);
    }
}
