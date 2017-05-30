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
        internal const string WMI_NAMESPACE_ROOT_CIMV2 = "root\\CIMV2";
        internal const string WMI_NAMESPACE_ROOT_STANDARD_CIMV2 = "root\\StandardCimv2";

        internal const string WMI_QUERY_PROCESSOR = "select * from Win32_Processor";
        internal const string WMI_QUERY_CACHE_MEMORY = "select CacheSpeed, MaxCacheSize, Level from Win32_CacheMemory";
        internal const string PROCESSOR_ADDRESS_WIDTH = "AddressWidth";
        internal const string PROCESSOR_ARCHITECTURE = "Architecture";
        internal const string PROCESSOR_CAPTION = "Caption";
        internal const string PROCESSOR_DATA_WIDTH = "DataWidth";
        internal const string PROCESSOR_DESCRIPTION = "Description";
        internal const string PROCESSOR_BUS_SPEED = "ExtClock";
        internal const string PROCESSOR_CACHE_SIZE = "MaxCacheSize";
        internal const string PROCESSOR_CACHE_SPEED = "CacheSpeed";
        internal const string PROCESSOR_CACHE_LEVEL = "Level";
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

        internal const string WMI_QUERY_DISK_DRIVE = "select * from Win32_DiskDrive";
        internal const string DISK_DRIVE_BYTES_PER_SECTOR = "BytesPerSector";
        internal const string DISK_DRIVE_CAPTION = "Caption";
        internal const string DISK_DRIVE_DESCRIPTION = "Description";
        internal const string DISK_DRIVE_DEVICE_ID = "DeviceID";
        internal const string DISK_DRIVE_FIRMWARE_REVISION = "FirmwareRevision";
        internal const string DISK_DRIVE_INTERFACE_TYPE = "InterfaceType";
        internal const string DISK_DRIVE_MEDIA_TYPE = "MediaType";
        internal const string DISK_DRIVE_MODEL = "Model";
        internal const string DISK_DRIVE_NAME = "Name";
        internal const string DISK_DRIVE_PARTITIONS = "Partitions";
        internal const string DISK_DRIVE_SERIAL_NUMBER = "SerialNumber";
        internal const string DISK_DRIVE_SIGNATURE = "Signature";
        internal const string DISK_DRIVE_SIZE = "Size";
        internal const string DISK_DRIVE_TOTAL_CYLINDERS = "TotalCylinders";
        internal const string DISK_DRIVE_TOTAL_HEADS = "TotalHeads";
        internal const string DISK_DRIVE_TOTAL_SECTORS = "TotalSectors";
        internal const string DISK_DRIVE_TOTAL_TRACKS = "TotalTracks";
        internal const string DISK_DRIVE_TRACKS_PER_CYLINDER = "TracksPerCylinder";

        internal const string WMI_QUERY_LOGICAL_DISK = "select * from Win32_LogicalDisk";
        internal const string LOGICAL_DISK_BLOCK_SIZE = "BlockSize";
        internal const string LOGICAL_DISK_CAPTION = "Caption";
        internal const string LOGICAL_DISK_DESCRIPTION = "Description";
        internal const string LOGICAL_DISK_DEVICE_ID = "DeviceID";
        internal const string LOGICAL_DISK_FILE_SYSTEM = "FileSystem";
        internal const string LOGICAL_DISK_FREE_SPACE = "FreeSpace";
        internal const string LOGICAL_DISK_NAME = "Name";
        internal const string LOGICAL_DISK_PROVIDER_NAME = "ProviderName";
        internal const string LOGICAL_DISK_SIZE = "Size";
        internal const string LOGICAL_DISK_VOLUME_NAME = "VolumeName";
        internal const string LOGICAL_DISK_VOLUME_SERIAL_NUMBER = "VolumeSerialNumber";

        internal const string WMI_QUERY_CDROM_DRIVE = "select * from Win32_CDROMDrive";
        internal const string CDROM_DRIVE_CAPTION = "Caption";
        internal const string CDROM_DRIVE_DESCRIPTION = "Description";
        internal const string CDROM_DRIVE_DEVICE_ID = "DeviceID";
        internal const string CDROM_DRIVE_DRIVE = "Drive";
        internal const string CDROM_DRIVE_MEDIA_TYPE = "MediaType";
        internal const string CDROM_DRIVE_NAME = "Name";

        internal const string WMI_QUERY_BASE_BOARD = "select * from Win32_BaseBoard";
        internal const string BASE_BOARD_CAPTION = "Caption";
        internal const string BASE_BOARD_DESCRIPTION = "Description";
        internal const string BASE_BOARD_MANUFACTURER = "Manufacturer";
        internal const string BASE_BOARD_MODEL = "Model";
        internal const string BASE_BOARD_NAME = "Name";
        internal const string BASE_BOARD_PART_NUMBER = "PartNumber";
        internal const string BASE_BOARD_PRODUCT = "Product";
        internal const string BASE_BOARD_SERIAL_NUMBER = "SerialNumber";
        internal const string BASE_BOARD_VERSION = "Version";

        internal const string WMI_QUERY_FAN = "select * from Win32_Fan";
        internal const string FAN_CAPTION = "Caption";
        internal const string FAN_DESCRIPTION = "Description";
        internal const string FAN_NAME = "Name";

        internal const string WMI_QUERY_BATTERY = "select * from Win32_Battery";
        internal const string BATTERY_BATTERY_STATUS = "BatteryStatus";
        internal const string BATTERY_CAPTION = "Caption";
        internal const string BATTERY_DESCRIPTION = "Description";
        internal const string BATTERY_DESIGN_CAPACITY = "DesignCapacity";
        internal const string BATTERY_DEVICE_ID = "DeviceID";
        internal const string BATTERY_FULLY_CHARGE_CAPACITY = "FullChargeCapacity";
        internal const string BATTERY_NAME = "Name";

        internal const string WMI_QUERY_NETWORK_ADAPTER = "select * from MSFT_NetAdapter";
        internal const string NETWORK_ADAPTER_MAXIMUM_MTU = "ActiveMaximumTransmissionUnit";
        internal const string NETWORK_ADAPTER_CAPTION = "Caption";
        internal const string NETWORK_ADAPTER_DESCRIPTION = "Description";
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
        internal const string NETWORK_ADAPTER_NAME = "Name";
        internal const string NETWORK_ADAPTER_NDIS_MEDIUM = "NdisMedium";
        internal const string NETWORK_ADAPTER_NDIS_PHYSICAL_MEDIUM = "NdisPhysicalMedium";
        internal const string NETWORK_ADAPTER_PERMANENT_ADDRESS = "PermanentAddress";
        internal const string NETWORK_ADAPTER_VIRTUAL = "Virtual";

        internal const string WMI_QUERY_PRINTER = "select * from Win32_Printer";
        internal const string PRINTER_AVG_PAGES_PER_MINUTE = "AveragePagesPerMinute";
        internal const string PRINTER_CAPTION = "Caption";
        internal const string PRINTER_DEFAULT = "Default";
        internal const string PRINTER_DESCRIPTION = "Description";
        internal const string PRINTER_DEVICE_ID = "DeviceID";
        internal const string PRINTER_NAME = "Name";
        internal const string PRINTER_PORT_NAME = "PortName";
        internal const string PRINTER_PRINT_PROCESSOR = "PrintProcessor";

        internal const string WMI_QUERY_VIDEO_CONTROLLER = "select * from Win32_VideoController";
        internal const string VIDEO_CONTROLLER_ADAPTER_COMPATIBILITY = "AdapterCompatibility";
        internal const string VIDEO_CONTROLLER_ADAPTER_DAC_TYPE = "AdapterDACType";
        internal const string VIDEO_CONTROLLER_ADAPTER_RAM = "AdapterRAM";
        internal const string VIDEO_CONTROLLER_CAPTION = "Caption";
        internal const string VIDEO_CONTROLLER_CURRENT_BITS_PER_PIXEL = "CurrentBitsPerPixel";
        internal const string VIDEO_CONTROLLER_CURRENT_HORIZONTAL_RESOLUTION = "CurrentHorizontalResolution";
        internal const string VIDEO_CONTROLLER_CURRENT_NUMBER_OF_COLORS = "CurrentNumberOfColors";
        internal const string VIDEO_CONTROLLER_CURRENT_REFRESH_RATE = "CurrentRefreshRate";
        internal const string VIDEO_CONTROLLER_CURRENT_VERTICAL_RESOLUTION = "CurrentVerticalResolution";
        internal const string VIDEO_CONTROLLER_DESCRIPTION = "Description";
        internal const string VIDEO_CONTROLLER_DEVICE_ID = "DeviceID";
        internal const string VIDEO_CONTROLLER_DRIVER_VERSION = "DriverVersion";
        internal const string VIDEO_CONTROLLER_NAME = "Name";
        internal const string VIDEO_CONTROLLER_VIDEO_MODE_DESCRIPTION = "VideoModeDescription";
        internal const string VIDEO_CONTROLLER_VIDEO_PROCESSOR = "VideoProcessor";

        internal const string WMI_QUERY_PNP_ENTITY = "select * from Win32_PnPEntity";
        internal const string PNP_ENTITY_CAPTION = "Caption";
        internal const string PNP_ENTITY_DESCRIPTION = "Description";
        internal const string PNP_ENTITY_DEVICE_ID = "DeviceID";
        internal const string PNP_ENTITY_MANUFACTURER = "Manufacturer";
        internal const string PNP_ENTITY_NAME = "Name";

        internal const string WMI_QUERY_VOLUME = "select * from Win32_Volume";
        internal const string VOLUME_BLOCK_SIZE = "BlockSize";
        internal const string VOLUME_BOOT_VOLUME = "BootVolume";
        internal const string VOLUME_CAPACITY = "Capacity";
        internal const string VOLUME_CAPTION = "Caption";
        internal const string VOLUME_DESCRIPTION = "Description";
        internal const string VOLUME_DEVICE_ID = "DeviceID";
        internal const string VOLUME_DRIVE_LETTER = "DriveLetter";
        internal const string VOLUME_DRIVE_TYPE = "DriveType";
        internal const string VOLUME_FILE_SYSTEM = "FileSystem";
        internal const string VOLUME_FREE_SPACE = "FreeSpace";
        internal const string VOLUME_LABEL = "Label";
        internal const string VOLUME_NAME = "Name";
        internal const string VOLUME_SERIAL_NUMBER = "SerialNumber";
        internal const string VOLUME_STATUS = "Status";
        internal const string VOLUME_SYSTEM_VOLUME = "SystemVolume";

    }
}
