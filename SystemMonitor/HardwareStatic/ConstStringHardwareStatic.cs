using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("SystemMonitorLibUnitTest")]
namespace SystemMonitor.HardwareStatic
{
    internal class ConstStringHardwareStatic
    {
        internal const string WMI_QUERY_PROCESSOR = "select * from Win32_Processor";
        internal const string WMI_QUERY_CACHE_MEMORY = "select CacheSpeed, MaxCacheSize from Win32_CacheMemory where Purpose =\"L1 Cache\"";
        internal const string PROCESSOR_ADDRESS_WIDTH = "AddressWidth";
        internal const string PROCESSOR_ARCHITECTURE = "Architecture";
        internal const string PROCESSOR_CAPTION = "Caption";
        internal const string PROCESSOR_DATA_WIDTH = "DataWidth";
        internal const string PROCESSOR_DESCRIPTION = "Description";
        internal const string PROCESSOR_BUS_SPEED = "ExtClock";
        internal const string PROCESSOR_L1_CACHE_SIZE = "MaxCacheSize";
        internal const string PROCESSOR_L1_CACHE_SPEED = "CacheSpeed";
        internal const string PROCESSOR_L2_CACHE_SIZE = "L2CacheSize";
        internal const string PROCESSOR_L2_CACHE_SPEED = "L2CacheSpeed";
        internal const string PROCESSOR_L3_CACHE_SIZE = "L3CacheSize";
        internal const string PROCESSOR_L3_CACHE_SPEED = "L3CacheSpeed";
        internal const string PROCESSOR_MANUFACTURER = "Manufacturer";
        internal const string PROCESSOR_MAX_CLOCK_SPEED = "MaxClockSpeed";
        internal const string PROCESSOR_NAME = "name";
        internal const string PROCESSOR_NUMBER_OF_CORES = "NumberOfCores";
        internal const string PROCESSOR_NUMBER_OF_LOGICAL_PROCESSORS = "NumberOfLogicalProcessors";
        internal const string PROCESSOR_ID = "ProcessorId";
        internal const string PROCESSOR_SERIAL_NUMBER = "SerialNumber";
        internal const string PROCESSOR_SOCKET_DESIGNATION = "SocketDesignation";
        internal const string PROCESSOR_STEPPING = "Stepping";
        internal const string PROCESSOR_THREAD_COUNT = "ThreadCount";
        internal const string PROCESSOR_UNIQUE_ID = "UniqueId";
        internal const string WMI_QUERY_MEMORY = "select * from Win32_PhysicalMemory";

        internal const string MEMORY_BANK_LABEL = "BankLabel";
        internal const string MEMORY_CAPACITY = "Capacity";
        internal const string MEMORY_CAPTION = "Caption";
        internal const string MEMORY_CONFIGURED_CLOCK_SPEED = "ConfiguredClockSpeed";
        internal const string MEMORY_CONFIGURED_VOLTAGE = "ConfiguredVoltage";
        internal const string MEMORY_DATA_WIDTH = "DataWidth";
        internal const string MEMORY_DESCRIPTION = "Description";
        internal const string MEMORY_DEVICE_LOCATOR = "DeviceLocator";
        internal const string MEMORY_MANUFACTURER = "Manufacturer";
        internal const string MEMORY_MAX_VOLTAGE = "MaxVoltage";
        internal const string MEMORY_MEMORY_TYPE = "MemoryType";
        internal const string MEMORY_MIN_VOLTAGE = "MinVoltage";
        internal const string MEMORY_NAME = "Name";
        internal const string MEMORY_PART_NUMBER = "PartNumber";
        internal const string MEMORY_SERIAL_NUMBER = "SerialNumber";
        internal const string MEMORY_TOTAL_WIDTH = "TotalWidth";
    }
}
