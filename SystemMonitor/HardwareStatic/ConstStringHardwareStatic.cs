﻿using System;
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
        internal const string WMI_NAMESPACE_ROOT_CIMV2 = "root\\CIMV2";
        internal const string WMI_NAMESPACE_ROOT_STANDARD_CIMV2 = "root\\StandardCimv2";
        internal const string WMI_NAMESPACE_ROOT_MICROSOFT_WINDOWS_STORAGE = "root\\Microsoft\\Windows\\Storage";

        internal const string HARDWARE_COMPONENT_CAPTION = "Caption";
        internal const string HARDWARE_COMPONENT_NAME = "Name";
        internal const string HARDWARE_COMPONENT_DESCRIPTION = "Description";
        internal const string HARDWARE_COMPONENT_STATUS = "Status";

        internal const string WMI_QUERY_PROCESSOR = "select * from Win32_Processor";
        internal const string PROCESSOR_ADDRESS_WIDTH = "AddressWidth";
        internal const string PROCESSOR_ARCHITECTURE = "Architecture";
        internal const string PROCESSOR_DATA_WIDTH = "DataWidth";
        internal const string PROCESSOR_BUS_SPEED = "ExtClock";
        internal const string PROCESSOR_MANUFACTURER = "Manufacturer";
        internal const string PROCESSOR_MAX_CLOCK_SPEED = "MaxClockSpeed";
        internal const string PROCESSOR_NUMBER_OF_CORES = "NumberOfCores";
        internal const string PROCESSOR_NUMBER_OF_LOGICAL_PROCESSORS = "NumberOfLogicalProcessors";
        internal const string PROCESSOR_ID = "ProcessorId";
        internal const string PROCESSOR_SERIAL_NUMBER = "SerialNumber";
        internal const string PROCESSOR_SOCKET_DESIGNATION = "SocketDesignation";
        internal const string PROCESSOR_STEPPING = "Stepping";
        internal const string PROCESSOR_THREAD_COUNT = "ThreadCount";
        internal const string PROCESSOR_UNIQUE_ID = "UniqueId";

        internal const string WMI_QUERY_CACHE_MEMORY = "select * from Win32_CacheMemory";
        internal const string PROCESSOR_CACHE_SIZE = "MaxCacheSize";
        internal const string PROCESSOR_CACHE_SPEED = "CacheSpeed";
        internal const string PROCESSOR_CACHE_LEVEL = "Level";

        internal const string WMI_QUERY_MEMORY = "select * from Win32_PhysicalMemory";
        internal const string MEMORY_BANK_LABEL = "BankLabel";
        internal const string MEMORY_CAPACITY = "Capacity";
        internal const string MEMORY_CONFIGURED_CLOCK_SPEED = "ConfiguredClockSpeed";
        internal const string MEMORY_CONFIGURED_VOLTAGE = "ConfiguredVoltage";
        internal const string MEMORY_DATA_WIDTH = "DataWidth";
        internal const string MEMORY_DEVICE_LOCATOR = "DeviceLocator";
        internal const string MEMORY_MANUFACTURER = "Manufacturer";
        internal const string MEMORY_MAX_VOLTAGE = "MaxVoltage";
        internal const string MEMORY_MEMORY_TYPE = "MemoryType";
        internal const string MEMORY_MIN_VOLTAGE = "MinVoltage";
        internal const string MEMORY_PART_NUMBER = "PartNumber";
        internal const string MEMORY_SERIAL_NUMBER = "SerialNumber";
        internal const string MEMORY_TOTAL_WIDTH = "TotalWidth";

        internal const string WMI_QUERY_DISK = "select * from MSFT_Disk";
        internal const string DISK_ALLOCATED_SIZE = "AllocatedSize";
        internal const string DISK_BOOT_FROM_DISK = "BootFromDisk";
        internal const string DISK_BUS_TYPE = "BusType";
        internal const string DISK_FIRMWARE_VERSION = "FirmwareVersion";
        internal const string DISK_FRIENDLY_NAME = "FriendlyName";
        internal const string DISK_HEALTH_STATUS = "HealthStatus";
        internal const string DISK_IS_BOOT = "IsBoot";
        internal const string DISK_IS_CLUSTERED = "IsClustered";
        internal const string DISK_IS_OFFILINE = "IsOffline";
        internal const string DISK_IS_READONLY = "IsReadOnly";
        internal const string DISK_IS_SYSTEM = "IsSystem";
        internal const string DISK_LARGEST_FREE_EXTEND = "LargestFreeExtent";
        internal const string DISK_LOCATION = "Location";
        internal const string DISK_LOGICAL_SECTOR_SIZE = "LogicalSectorSize";
        internal const string DISK_MANUFACTURER = "Manufacturer";
        internal const string DISK_MODEL = "Model";
        internal const string DISK_NUMBER = "Number";
        internal const string DISK_NUMBER_OF_PARTITIONS = "NumberOfPartitions";
        internal const string DISK_OBJECT_ID = "ObjectId";
        internal const string DISK_OFFLINE_REASON = "OfflineReason";
        internal const string DISK_PARTITION_STYLE = "PartitionStyle";
        internal const string DISK_PATH = "Path";
        internal const string DISK_PHYSICAL_SECTOR_SIZE = "PhysicalSectorSize";
        internal const string DISK_SERIAL_NUMBER = "SerialNumber";
        internal const string DISK_SIGNATURE = "Signature";
        internal const string DISK_SIZE = "Size";
        internal const string DISK_UNIQUE_ID = "UniqueId";

        internal const string WMI_QUERY_LOGICAL_DISK = "select * from Win32_LogicalDisk";
        internal const string LOGICAL_DISK_BLOCK_SIZE = "BlockSize";
        internal const string LOGICAL_DISK_DEVICE_ID = "DeviceID";
        internal const string LOGICAL_DISK_FILE_SYSTEM = "FileSystem";
        internal const string LOGICAL_DISK_FREE_SPACE = "FreeSpace";
        internal const string LOGICAL_DISK_PROVIDER_NAME = "ProviderName";
        internal const string LOGICAL_DISK_SIZE = "Size";
        internal const string LOGICAL_DISK_VOLUME_NAME = "VolumeName";
        internal const string LOGICAL_DISK_VOLUME_SERIAL_NUMBER = "VolumeSerialNumber";

        internal const string WMI_QUERY_CDROM_DRIVE = "select * from Win32_CDROMDrive";
        internal const string CDROM_DRIVE_DEVICE_ID = "DeviceID";
        internal const string CDROM_DRIVE_DRIVE = "Drive";
        internal const string CDROM_DRIVE_MEDIA_TYPE = "MediaType";

        internal const string WMI_QUERY_BASE_BOARD = "select * from Win32_BaseBoard";
        internal const string BASE_BOARD_MANUFACTURER = "Manufacturer";
        internal const string BASE_BOARD_MODEL = "Model";
        internal const string BASE_BOARD_PART_NUMBER = "PartNumber";
        internal const string BASE_BOARD_PRODUCT = "Product";
        internal const string BASE_BOARD_SERIAL_NUMBER = "SerialNumber";
        internal const string BASE_BOARD_VERSION = "Version";

        internal const string WMI_QUERY_FAN = "select * from Win32_Fan";

        internal const string WMI_QUERY_BATTERY = "select * from Win32_Battery";
        internal const string BATTERY_BATTERY_STATUS = "BatteryStatus";
        internal const string BATTERY_DESIGN_CAPACITY = "DesignCapacity";
        internal const string BATTERY_DEVICE_ID = "DeviceID";
        internal const string BATTERY_FULLY_CHARGE_CAPACITY = "FullChargeCapacity";

        internal const string WMI_QUERY_NETWORK_ADAPTER = "select * from MSFT_NetAdapter";
        internal const string NETWORK_ADAPTER_MAXIMUM_MTU = "ActiveMaximumTransmissionUnit";
        internal const string NETWORK_ADAPTER_COMPONENT_ID = "ComponentID";
        internal const string NETWORK_ADAPTER_CONNECTOR_PRESENT = "ConnectorPresent";
        internal const string NETWORK_ADAPTER_DEVICE_ID = "DeviceID";
        internal const string NETWORK_ADAPTER_DEVICE_NAME = "DeviceName";
        internal const string NETWORK_ADAPTER_DRIVER_DATE = "DriverDate";
        internal const string NETWORK_ADAPTER_DRIVER_DESCRIPTION = "DriverDescription";
        internal const string NETWORK_ADAPTER_DRIVER_NAME = "DriverName";
        internal const string NETWORK_ADAPTER_DRIVER_PROVIDER = "DriverProvider";
        internal const string NETWORK_ADAPTER_DRIVER_VERSION_STRING = "DriverVersionString";
        internal const string NETWORK_ADAPTER_INTERFACE_DESCRIPTION = "InterfaceDescription";
        internal const string NETWORK_ADAPTER_INTERFACE_NAME = "InterfaceName";
        internal const string NETWORK_ADAPTER_NDIS_MEDIUM = "NdisMedium";
        internal const string NETWORK_ADAPTER_NDIS_PHYSICAL_MEDIUM = "NdisPhysicalMedium";
        internal const string NETWORK_ADAPTER_PERMANENT_ADDRESS = "PermanentAddress";
        internal const string NETWORK_ADAPTER_VIRTUAL = "Virtual";

        internal const string WMI_QUERY_PRINTER = "select * from Win32_Printer";
        internal const string PRINTER_AVG_PAGES_PER_MINUTE = "AveragePagesPerMinute";
        internal const string PRINTER_DEFAULT = "Default";
        internal const string PRINTER_DEVICE_ID = "DeviceID";
        internal const string PRINTER_PORT_NAME = "PortName";
        internal const string PRINTER_PRINT_PROCESSOR = "PrintProcessor";

        internal const string WMI_QUERY_VIDEO_CONTROLLER = "select * from Win32_VideoController";
        internal const string VIDEO_CONTROLLER_ADAPTER_COMPATIBILITY = "AdapterCompatibility";
        internal const string VIDEO_CONTROLLER_ADAPTER_DAC_TYPE = "AdapterDACType";
        internal const string VIDEO_CONTROLLER_ADAPTER_RAM = "AdapterRAM";
        internal const string VIDEO_CONTROLLER_CURRENT_BITS_PER_PIXEL = "CurrentBitsPerPixel";
        internal const string VIDEO_CONTROLLER_CURRENT_HORIZONTAL_RESOLUTION = "CurrentHorizontalResolution";
        internal const string VIDEO_CONTROLLER_CURRENT_NUMBER_OF_COLORS = "CurrentNumberOfColors";
        internal const string VIDEO_CONTROLLER_CURRENT_REFRESH_RATE = "CurrentRefreshRate";
        internal const string VIDEO_CONTROLLER_CURRENT_VERTICAL_RESOLUTION = "CurrentVerticalResolution";
        internal const string VIDEO_CONTROLLER_DEVICE_ID = "DeviceID";
        internal const string VIDEO_CONTROLLER_DRIVER_VERSION = "DriverVersion";
        internal const string VIDEO_CONTROLLER_VIDEO_MODE_DESCRIPTION = "VideoModeDescription";
        internal const string VIDEO_CONTROLLER_VIDEO_PROCESSOR = "VideoProcessor";

        internal const string WMI_QUERY_PNP_ENTITY = "select * from Win32_PnPEntity";
        internal const string PNP_ENTITY_DEVICE_ID = "DeviceID";
        internal const string PNP_ENTITY_MANUFACTURER = "Manufacturer";

        internal const string WMI_QUERY_VOLUME = "select * from MSFT_Volume";
        internal const string VOLUME_DEDUP_MODE = "DedupMode";
        internal const string VOLUME_DRIVE_LETTER = "DriveLetter";
        internal const string VOLUME_DRIVE_TYPE = "DriveType";
        internal const string VOLUME_FILE_SYSTEM = "FileSystem";
        internal const string VOLUME_FILE_SYTEM_LABEL = "FileSystemLabel";
        internal const string VOLUME_HEALTH_STATUS = "HealthStatus";
        internal const string VOLUME_OBJECT_ID = "ObjectId";
        internal const string VOLUME_FREE_SPACE = "Path";
        internal const string VOLUME_SIZE = "Size";
        internal const string VOLUME_SIZE_REMAINING = "SizeRemaining";
        internal const string VOLUME_PATH = "Path";
        internal const string VOLUME_UNIQUE_ID = "UniqueId";

        internal const string WMI_QUERY_DISK_PARTITION = "select * from MSFT_Partition";
        internal const string DISK_PARTITION_DISK_ID = "DiskId";
        internal const string DISK_PARTITION_DISK_NUMBER = "DiskNumber";
        internal const string DISK_PARTITION_DRIVE_LETTER = "DriveLetter";
        internal const string DISK_PARTITION_IS_ACTIVE = "IsActive";
        internal const string DISK_PARTITION_IS_BOOT = "IsBoot";
        internal const string DISK_PARTITION_IS_HIDDEN = "IsHidden";
        internal const string DISK_PARTITION_IS_OFFLINE = "IsOffline";
        internal const string DISK_PARTITION_IS_READ_ONLY = "IsReadOnly";
        internal const string DISK_PARTITION_IS_SHADOW_COPY = "IsShadowCopy";
        internal const string DISK_PARTITION_IS_SYSTEM = "IsSystem";
        internal const string DISK_PARTITION_MRB_TYPE = "MbrType";
        internal const string DISK_PARTITION_NO_DEFAULT_DRIVE_LETTER = "NoDefaultDriveLetter";
        internal const string DISK_PARTITION_OFFSET = "Offset";
        internal const string DISK_PARTITION_PARTITION_NUMBER = "PartitionNumber";
        internal const string DISK_PARTITION_SIZE = "Size";
    }
}
