using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.Components;
using SystemMonitor.HardwareStatic.Model.CustomProperties;
using SystemMonitor.HardwareStatic.Model.CustomProperties.Enum;

namespace SystemMonitor.HardwareStatic.WMI
{
    internal class WMIDataExtractor : IWMIDataExtractor
    {
        public Processor ExtractDataProcessor(ManagementObject managementObjectWin32_Processor, ManagementObject managementObjectWin32_CacheMemory)
        {
            Processor processor = new Processor();
            processor.AddressWidth = new UnitValue(Unit.BIT, managementObjectWin32_Processor[ConstStringHardwareStatic.PROCESSOR_ADDRESS_WIDTH]?.ToString() ?? string.Empty);

            if (managementObjectWin32_Processor[ConstStringHardwareStatic.PROCESSOR_ARCHITECTURE] != null)
            {
                processor.Architecture = ((ArchitectureEnum)((ushort)managementObjectWin32_Processor[ConstStringHardwareStatic.PROCESSOR_ARCHITECTURE])).ToString();
            }
            else
            {
                processor.Architecture = string.Empty;
            }

            processor.Caption = (string)managementObjectWin32_Processor[ConstStringHardwareStatic.PROCESSOR_CAPTION];
            processor.DataWidth = new UnitValue(Unit.BIT, managementObjectWin32_Processor[ConstStringHardwareStatic.PROCESSOR_DATA_WIDTH]?.ToString() ?? string.Empty);
            processor.Description = (string)managementObjectWin32_Processor[ConstStringHardwareStatic.PROCESSOR_DESCRIPTION];
            processor.BusSpeed = new UnitValue(Unit.MHZ, managementObjectWin32_Processor[ConstStringHardwareStatic.PROCESSOR_BUS_SPEED]?.ToString() ?? string.Empty);
            processor.L1CacheSize = new UnitValue(Unit.KB, managementObjectWin32_CacheMemory[ConstStringHardwareStatic.PROCESSOR_L1_CACHE_SIZE]?.ToString() ?? string.Empty);
            processor.L1CacheSpeed = new UnitValue(Unit.MHZ, managementObjectWin32_CacheMemory[ConstStringHardwareStatic.PROCESSOR_L1_CACHE_SPEED]?.ToString() ?? string.Empty);
            processor.L2CacheSize = new UnitValue(Unit.KB, managementObjectWin32_Processor[ConstStringHardwareStatic.PROCESSOR_L2_CACHE_SIZE]?.ToString() ?? string.Empty);
            processor.L2CacheSpeed = new UnitValue(Unit.MHZ, managementObjectWin32_Processor[ConstStringHardwareStatic.PROCESSOR_L2_CACHE_SPEED]?.ToString() ?? string.Empty);
            processor.L3CacheSize = new UnitValue(Unit.KB, managementObjectWin32_Processor[ConstStringHardwareStatic.PROCESSOR_L3_CACHE_SIZE]?.ToString() ?? string.Empty);
            processor.L3CacheSpeed = new UnitValue(Unit.MHZ, managementObjectWin32_Processor[ConstStringHardwareStatic.PROCESSOR_L3_CACHE_SPEED]?.ToString() ?? string.Empty);
            processor.Manufacturer = (string)managementObjectWin32_Processor[ConstStringHardwareStatic.PROCESSOR_MANUFACTURER];
            processor.MaxClockSpeed = new UnitValue(Unit.MHZ, managementObjectWin32_Processor[ConstStringHardwareStatic.PROCESSOR_MAX_CLOCK_SPEED]?.ToString() ?? string.Empty);
            processor.Name = (string)managementObjectWin32_Processor[ConstStringHardwareStatic.PROCESSOR_NAME];
            processor.NumberOfCores = managementObjectWin32_Processor[ConstStringHardwareStatic.PROCESSOR_NUMBER_OF_CORES]?.ToString() ?? string.Empty;
            processor.NumberOfLogicalProcessors = managementObjectWin32_Processor[ConstStringHardwareStatic.PROCESSOR_NUMBER_OF_LOGICAL_PROCESSORS]?.ToString() ?? string.Empty;
            processor.ProcessorID = (string)managementObjectWin32_Processor[ConstStringHardwareStatic.PROCESSOR_ID];
            processor.SocketDesignation = (string)managementObjectWin32_Processor[ConstStringHardwareStatic.PROCESSOR_SOCKET_DESIGNATION];
            processor.Stepping = (string)managementObjectWin32_Processor[ConstStringHardwareStatic.PROCESSOR_STEPPING];
            processor.ThreadCount = managementObjectWin32_Processor[ConstStringHardwareStatic.PROCESSOR_THREAD_COUNT]?.ToString() ?? string.Empty;
            processor.UniqueId = (string)managementObjectWin32_Processor[ConstStringHardwareStatic.PROCESSOR_UNIQUE_ID];

            return processor;
        }
    }
}
