using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.Components;
using SystemMonitor.HardwareStatic.Model.CustomProperties;
using SystemMonitor.HardwareStatic.Model.CustomProperties.Enum;

[assembly: InternalsVisibleTo("SystemMonitorLibUnitTest")]
namespace SystemMonitor.HardwareStatic.WMI
{
    internal class WMIDataExtractor : IWMIDataExtractor
    {
        public Processor ExtractDataProcessor(ManagementObject managementObjectWin32_Processor, List<ManagementObject> managementObjectWin32_CacheMemory)
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

            processor.Caption = managementObjectWin32_Processor[ConstStringHardwareStatic.PROCESSOR_CAPTION]?.ToString() ?? string.Empty;
            processor.DataWidth = new UnitValue(Unit.BIT, managementObjectWin32_Processor[ConstStringHardwareStatic.PROCESSOR_DATA_WIDTH]?.ToString() ?? string.Empty);
            processor.Description = managementObjectWin32_Processor[ConstStringHardwareStatic.PROCESSOR_DESCRIPTION]?.ToString() ?? string.Empty;
            processor.BusSpeed = new UnitValue(Unit.MHZ, managementObjectWin32_Processor[ConstStringHardwareStatic.PROCESSOR_BUS_SPEED]?.ToString() ?? string.Empty);

            foreach (var cache in managementObjectWin32_CacheMemory)
            {
                processor.Cache.Add(new CpuCacheMemory(
                                            new UnitValue(Unit.MHZ, cache[ConstStringHardwareStatic.PROCESSOR_CACHE_SPEED]?.ToString() ?? string.Empty),
                                            new UnitValue(Unit.KB, cache[ConstStringHardwareStatic.PROCESSOR_CACHE_SIZE]?.ToString() ?? string.Empty),
                                            ((CacheLevelEnum)((ushort)cache[ConstStringHardwareStatic.PROCESSOR_CACHE_LEVEL])).ToString()));
            }

            processor.Manufacturer = managementObjectWin32_Processor[ConstStringHardwareStatic.PROCESSOR_MANUFACTURER]?.ToString() ?? string.Empty;
            processor.MaxClockSpeed = new UnitValue(Unit.MHZ, managementObjectWin32_Processor[ConstStringHardwareStatic.PROCESSOR_MAX_CLOCK_SPEED]?.ToString() ?? string.Empty);
            processor.Name = managementObjectWin32_Processor[ConstStringHardwareStatic.PROCESSOR_NAME]?.ToString() ?? string.Empty;
            processor.NumberOfCores = managementObjectWin32_Processor[ConstStringHardwareStatic.PROCESSOR_NUMBER_OF_CORES]?.ToString() ?? string.Empty;
            processor.NumberOfLogicalProcessors = managementObjectWin32_Processor[ConstStringHardwareStatic.PROCESSOR_NUMBER_OF_LOGICAL_PROCESSORS]?.ToString() ?? string.Empty;
            processor.ProcessorID = managementObjectWin32_Processor[ConstStringHardwareStatic.PROCESSOR_ID]?.ToString() ?? string.Empty;
            //processor.SerialNumber = managementObjectWin32_Processor[ConstStringHardwareStatic.PROCESSOR_SERIAL_NUMBER]?.ToString() ?? string.Empty;
            processor.SocketDesignation = managementObjectWin32_Processor[ConstStringHardwareStatic.PROCESSOR_SOCKET_DESIGNATION]?.ToString() ?? string.Empty;
            processor.Stepping = managementObjectWin32_Processor[ConstStringHardwareStatic.PROCESSOR_STEPPING]?.ToString() ?? string.Empty;
            //processor.ThreadCount = managementObjectWin32_Processor[ConstStringHardwareStatic.PROCESSOR_THREAD_COUNT]?.ToString() ?? string.Empty;
            processor.UniqueId = managementObjectWin32_Processor[ConstStringHardwareStatic.PROCESSOR_UNIQUE_ID]?.ToString() ?? string.Empty;
            return processor;
        }

        public Memory ExtractDataMemory(ManagementObject managementObjectWin32_PhysicalMemory)
        {
            Memory memory = new Memory();
            memory.BankLabel = managementObjectWin32_PhysicalMemory[ConstStringHardwareStatic.MEMORY_BANK_LABEL]?.ToString() ?? string.Empty;
            memory.Capacity = new UnitValue(Unit.B, managementObjectWin32_PhysicalMemory[ConstStringHardwareStatic.MEMORY_CAPACITY]?.ToString() ?? string.Empty);
            memory.Caption = managementObjectWin32_PhysicalMemory[ConstStringHardwareStatic.MEMORY_CAPTION]?.ToString() ?? string.Empty;
            //memory.ConfiguredClockSpeed = new UnitValue(Unit.MHZ, managementObjectWin32_PhysicalMemory[ConstStringHardwareStatic.MEMORY_CONFIGURED_CLOCK_SPEED]?.ToString() ?? string.Empty);
            //memory.ConfiguredVoltage = new UnitValue(Unit.MV, managementObjectWin32_PhysicalMemory[ConstStringHardwareStatic.MEMORY_CONFIGURED_VOLTAGE]?.ToString() ?? string.Empty);
            memory.DataWidth = new UnitValue(Unit.BIT, managementObjectWin32_PhysicalMemory[ConstStringHardwareStatic.MEMORY_DATA_WIDTH]?.ToString() ?? string.Empty);
            memory.Description = managementObjectWin32_PhysicalMemory[ConstStringHardwareStatic.MEMORY_DESCRIPTION]?.ToString() ?? string.Empty;
            memory.DeviceLocator = managementObjectWin32_PhysicalMemory[ConstStringHardwareStatic.MEMORY_DEVICE_LOCATOR]?.ToString() ?? string.Empty;
            memory.Manufacturer = managementObjectWin32_PhysicalMemory[ConstStringHardwareStatic.MEMORY_MANUFACTURER]?.ToString() ?? string.Empty;
            //memory.MaxVoltage = new UnitValue(Unit.MV, managementObjectWin32_PhysicalMemory[ConstStringHardwareStatic.MEMORY_MAX_VOLTAGE]?.ToString() ?? string.Empty);

            if (managementObjectWin32_PhysicalMemory[ConstStringHardwareStatic.MEMORY_MEMORY_TYPE] != null)
            {
                memory.MemoryType = ((MemoryTypeEnum)((ushort)managementObjectWin32_PhysicalMemory[ConstStringHardwareStatic.MEMORY_MEMORY_TYPE])).ToString();
            }
            else
            {
                memory.MemoryType = string.Empty;
            }

            //memory.MinVoltage = new UnitValue(Unit.MV, managementObjectWin32_PhysicalMemory[ConstStringHardwareStatic.MEMORY_MIN_VOLTAGE]?.ToString() ?? string.Empty);
            memory.Name = managementObjectWin32_PhysicalMemory[ConstStringHardwareStatic.MEMORY_NAME]?.ToString() ?? string.Empty;
            memory.PartNumber = managementObjectWin32_PhysicalMemory[ConstStringHardwareStatic.MEMORY_PART_NUMBER]?.ToString() ?? string.Empty;
            memory.SerialNumber = managementObjectWin32_PhysicalMemory[ConstStringHardwareStatic.MEMORY_SERIAL_NUMBER]?.ToString() ?? string.Empty;
            memory.TotalWidth = new UnitValue(Unit.BIT, managementObjectWin32_PhysicalMemory[ConstStringHardwareStatic.MEMORY_TOTAL_WIDTH]?.ToString() ?? string.Empty);

            return memory;
        }

        public DiskDrive ExtractDataDiskDrive(ManagementObject managementObjectWin32_DiskDrive)
        {
            DiskDrive diskDrive = new DiskDrive();
            diskDrive.BytesPerSector = new UnitValue(Unit.B, managementObjectWin32_DiskDrive[ConstStringHardwareStatic.DISK_DRIVE_BYTES_PER_SECTOR]?.ToString() ?? string.Empty);
            diskDrive.Caption = managementObjectWin32_DiskDrive[ConstStringHardwareStatic.DISK_DRIVE_CAPTION]?.ToString() ?? string.Empty;
            diskDrive.Description = managementObjectWin32_DiskDrive[ConstStringHardwareStatic.DISK_DRIVE_DESCRIPTION]?.ToString() ?? string.Empty;
            diskDrive.DeviceID = managementObjectWin32_DiskDrive[ConstStringHardwareStatic.DISK_DRIVE_DEVICE_ID]?.ToString() ?? string.Empty;
            diskDrive.FirmwareRevision = managementObjectWin32_DiskDrive[ConstStringHardwareStatic.DISK_DRIVE_FIRMWARE_REVISION]?.ToString() ?? string.Empty;
            diskDrive.InterfaceType = managementObjectWin32_DiskDrive[ConstStringHardwareStatic.DISK_DRIVE_INTERFACE_TYPE]?.ToString() ?? string.Empty;
            diskDrive.MediaType = managementObjectWin32_DiskDrive[ConstStringHardwareStatic.DISK_DRIVE_MEDIA_TYPE]?.ToString() ?? string.Empty;
            diskDrive.Model = managementObjectWin32_DiskDrive[ConstStringHardwareStatic.DISK_DRIVE_MODEL]?.ToString() ?? string.Empty;
            diskDrive.Name = managementObjectWin32_DiskDrive[ConstStringHardwareStatic.DISK_DRIVE_NAME]?.ToString() ?? string.Empty;
            diskDrive.Partitions = managementObjectWin32_DiskDrive[ConstStringHardwareStatic.DISK_DRIVE_PARTITIONS]?.ToString() ?? string.Empty;
            diskDrive.SerialNumber = managementObjectWin32_DiskDrive[ConstStringHardwareStatic.DISK_DRIVE_SERIAL_NUMBER]?.ToString() ?? string.Empty;
            diskDrive.Signature = managementObjectWin32_DiskDrive[ConstStringHardwareStatic.DISK_DRIVE_SIGNATURE]?.ToString() ?? string.Empty;
            diskDrive.Size = new UnitValue(Unit.B, managementObjectWin32_DiskDrive[ConstStringHardwareStatic.DISK_DRIVE_SIZE]?.ToString() ?? string.Empty);
            diskDrive.TotalCylinders = managementObjectWin32_DiskDrive[ConstStringHardwareStatic.DISK_DRIVE_TOTAL_CYLINDERS]?.ToString() ?? string.Empty;
            diskDrive.TotalHeads = managementObjectWin32_DiskDrive[ConstStringHardwareStatic.DISK_DRIVE_TOTAL_HEADS]?.ToString() ?? string.Empty;
            diskDrive.TotalSectors = managementObjectWin32_DiskDrive[ConstStringHardwareStatic.DISK_DRIVE_TOTAL_SECTORS]?.ToString() ?? string.Empty;
            diskDrive.TotalTracks = managementObjectWin32_DiskDrive[ConstStringHardwareStatic.DISK_DRIVE_TOTAL_TRACKS]?.ToString() ?? string.Empty;
            diskDrive.TracksPerCylinder = managementObjectWin32_DiskDrive[ConstStringHardwareStatic.DISK_DRIVE_TRACKS_PER_CYLINDER]?.ToString() ?? string.Empty;

            return diskDrive;
        }

        public LogicalDisk ExtractDataLogicalDisk(ManagementObject managementObjectWin32_LogicalDisk)
        {
            LogicalDisk logicalDisk = new LogicalDisk();
            logicalDisk.BlockSize = new UnitValue(Unit.B, managementObjectWin32_LogicalDisk[ConstStringHardwareStatic.LOGICAL_DISK_BLOCK_SIZE]?.ToString() ?? string.Empty);
            logicalDisk.Caption = managementObjectWin32_LogicalDisk[ConstStringHardwareStatic.LOGICAL_DISK_CAPTION]?.ToString() ?? string.Empty;
            logicalDisk.Description = managementObjectWin32_LogicalDisk[ConstStringHardwareStatic.LOGICAL_DISK_DESCRIPTION]?.ToString() ?? string.Empty;
            logicalDisk.DeviceID = managementObjectWin32_LogicalDisk[ConstStringHardwareStatic.LOGICAL_DISK_DEVICE_ID]?.ToString() ?? string.Empty;
            logicalDisk.FileSystem = managementObjectWin32_LogicalDisk[ConstStringHardwareStatic.LOGICAL_DISK_FILE_SYSTEM]?.ToString() ?? string.Empty;
            logicalDisk.FreeSpace = new UnitValue(Unit.B, managementObjectWin32_LogicalDisk[ConstStringHardwareStatic.LOGICAL_DISK_BLOCK_SIZE]?.ToString() ?? string.Empty);
            logicalDisk.Name = managementObjectWin32_LogicalDisk[ConstStringHardwareStatic.LOGICAL_DISK_NAME]?.ToString() ?? string.Empty;
            logicalDisk.ProviderName = managementObjectWin32_LogicalDisk[ConstStringHardwareStatic.LOGICAL_DISK_PROVIDER_NAME]?.ToString() ?? string.Empty;
            logicalDisk.Size = new UnitValue(Unit.B, managementObjectWin32_LogicalDisk[ConstStringHardwareStatic.LOGICAL_DISK_SIZE]?.ToString() ?? string.Empty);
            logicalDisk.VolumeName = managementObjectWin32_LogicalDisk[ConstStringHardwareStatic.LOGICAL_DISK_VOLUME_NAME]?.ToString() ?? string.Empty;
            logicalDisk.VolumeSerialNumber = managementObjectWin32_LogicalDisk[ConstStringHardwareStatic.LOGICAL_DISK_VOLUME_SERIAL_NUMBER]?.ToString() ?? string.Empty;

            return logicalDisk;
        }

        public CDROMDrive ExtractDataCDROMDriveDisk(ManagementObject managementObjectWin32_CDROMDrive)
        {
            CDROMDrive cdROMDrive = new CDROMDrive();
            cdROMDrive.Caption = managementObjectWin32_CDROMDrive[ConstStringHardwareStatic.CDROM_DRIVE_CAPTION]?.ToString() ?? string.Empty;
            cdROMDrive.Description = managementObjectWin32_CDROMDrive[ConstStringHardwareStatic.CDROM_DRIVE_DESCRIPTION]?.ToString() ?? string.Empty;
            cdROMDrive.DeviceID = managementObjectWin32_CDROMDrive[ConstStringHardwareStatic.CDROM_DRIVE_DEVICE_ID]?.ToString() ?? string.Empty;
            cdROMDrive.Drive = managementObjectWin32_CDROMDrive[ConstStringHardwareStatic.CDROM_DRIVE_DRIVE]?.ToString() ?? string.Empty;
            cdROMDrive.MediaType = managementObjectWin32_CDROMDrive[ConstStringHardwareStatic.CDROM_DRIVE_MEDIA_TYPE]?.ToString() ?? string.Empty;
            cdROMDrive.Name = managementObjectWin32_CDROMDrive[ConstStringHardwareStatic.CDROM_DRIVE_NAME]?.ToString() ?? string.Empty;

            return cdROMDrive;
        }

        public BaseBoard ExtractDataBaseBoard(ManagementObject managementObjectWin32_BaseBoard)
        {
            BaseBoard baseBoard = new BaseBoard();
            baseBoard.Caption = managementObjectWin32_BaseBoard[ConstStringHardwareStatic.BASE_BOARD_CAPTION]?.ToString() ?? string.Empty;
            baseBoard.Description = managementObjectWin32_BaseBoard[ConstStringHardwareStatic.BASE_BOARD_DESCRIPTION]?.ToString() ?? string.Empty;
            baseBoard.Manufacturer = managementObjectWin32_BaseBoard[ConstStringHardwareStatic.BASE_BOARD_MANUFACTURER]?.ToString() ?? string.Empty;
            baseBoard.Model = managementObjectWin32_BaseBoard[ConstStringHardwareStatic.BASE_BOARD_MODEL]?.ToString() ?? string.Empty;
            baseBoard.Name = managementObjectWin32_BaseBoard[ConstStringHardwareStatic.BASE_BOARD_NAME]?.ToString() ?? string.Empty;
            baseBoard.PartNumber = managementObjectWin32_BaseBoard[ConstStringHardwareStatic.BASE_BOARD_PART_NUMBER]?.ToString() ?? string.Empty;
            baseBoard.Product = managementObjectWin32_BaseBoard[ConstStringHardwareStatic.BASE_BOARD_PRODUCT]?.ToString() ?? string.Empty;
            baseBoard.SerialNumber = managementObjectWin32_BaseBoard[ConstStringHardwareStatic.BASE_BOARD_SERIAL_NUMBER]?.ToString() ?? string.Empty;
            baseBoard.Version = managementObjectWin32_BaseBoard[ConstStringHardwareStatic.BASE_BOARD_VERSION]?.ToString() ?? string.Empty;

            return baseBoard;
        }

        public Fan ExtractDataFan(ManagementObject managementObjectWin32_Fan)
        {
            Fan fan = new Fan();
            fan.Caption = managementObjectWin32_Fan[ConstStringHardwareStatic.FAN_CAPTION]?.ToString() ?? string.Empty;
            fan.Description = managementObjectWin32_Fan[ConstStringHardwareStatic.FAN_DESCRIPTION]?.ToString() ?? string.Empty;
            fan.Name = managementObjectWin32_Fan[ConstStringHardwareStatic.FAN_NAME]?.ToString() ?? string.Empty;

            return fan;
        }

        public Battery ExtractDataBattery(ManagementObject managementObjectWin32_Battery)
        {
            Battery battery = new Battery();

            if (managementObjectWin32_Battery[ConstStringHardwareStatic.BATTERY_BATTERY_STATUS] != null)
            {
                battery.BatteryStatus = ((BatteryStatus)((ushort)managementObjectWin32_Battery[ConstStringHardwareStatic.BATTERY_BATTERY_STATUS])).ToString();
            }
            else
            {
                battery.BatteryStatus = string.Empty;
            }

            battery.Caption = managementObjectWin32_Battery[ConstStringHardwareStatic.BATTERY_CAPTION]?.ToString() ?? string.Empty;
            battery.Description = managementObjectWin32_Battery[ConstStringHardwareStatic.BATTERY_DESCRIPTION]?.ToString() ?? string.Empty;
            battery.DesignCapacity = new UnitValue(Unit.MWH, managementObjectWin32_Battery[ConstStringHardwareStatic.BATTERY_DESIGN_CAPACITY]?.ToString() ?? string.Empty);
            battery.DeviceID = managementObjectWin32_Battery[ConstStringHardwareStatic.BATTERY_DEVICE_ID]?.ToString() ?? string.Empty;
            battery.FullChargeCapacity = new UnitValue(Unit.MWH, managementObjectWin32_Battery[ConstStringHardwareStatic.BATTERY_FULLY_CHARGE_CAPACITY]?.ToString() ?? string.Empty);
            battery.Name = managementObjectWin32_Battery[ConstStringHardwareStatic.BATTERY_NAME]?.ToString() ?? string.Empty;

            return battery;
        }

        public NetworkAdapter ExtractDataNetworkAdapter(ManagementObject managementObjectMSFT_NetAdapter)
        {
            NetworkAdapter networkAdapter = new NetworkAdapter();
            networkAdapter.ActiveMaximumTransmissionUnit = new UnitValue(Unit.B, managementObjectMSFT_NetAdapter[ConstStringHardwareStatic.NETWORK_ADAPTER_MAXIMUM_MTU]?.ToString() ?? string.Empty);
            networkAdapter.Caption = managementObjectMSFT_NetAdapter[ConstStringHardwareStatic.NETWORK_ADAPTER_CAPTION]?.ToString() ?? string.Empty;
            networkAdapter.ComponentID = managementObjectMSFT_NetAdapter[ConstStringHardwareStatic.NETWORK_ADAPTER_COMPONENT_ID]?.ToString() ?? string.Empty;
            networkAdapter.ConnectorPresent = managementObjectMSFT_NetAdapter[ConstStringHardwareStatic.NETWORK_ADAPTER_CONNECTOR_PRESENT]?.ToString() ?? string.Empty;
            networkAdapter.Description = managementObjectMSFT_NetAdapter[ConstStringHardwareStatic.NETWORK_ADAPTER_DESCRIPTION]?.ToString() ?? string.Empty;
            networkAdapter.DeviceID = managementObjectMSFT_NetAdapter[ConstStringHardwareStatic.NETWORK_ADAPTER_DEVICE_ID]?.ToString() ?? string.Empty;
            networkAdapter.DeviceName = managementObjectMSFT_NetAdapter[ConstStringHardwareStatic.NETWORK_ADAPTER_DRIVER_NAME]?.ToString() ?? string.Empty;
            networkAdapter.DriverDate = managementObjectMSFT_NetAdapter[ConstStringHardwareStatic.NETWORK_ADAPTER_DRIVER_DATE]?.ToString() ?? string.Empty;
            networkAdapter.DriverDescription = managementObjectMSFT_NetAdapter[ConstStringHardwareStatic.NETWORK_ADAPTER_DRIVER_DESCRIPTION]?.ToString() ?? string.Empty;
            networkAdapter.DriverName = managementObjectMSFT_NetAdapter[ConstStringHardwareStatic.NETWORK_ADAPTER_DRIVER_NAME]?.ToString() ?? string.Empty;
            networkAdapter.DriverProvider = managementObjectMSFT_NetAdapter[ConstStringHardwareStatic.NETWORK_ADAPTER_DRIVER_PROVIDER]?.ToString() ?? string.Empty;
            networkAdapter.DriverVersionString = managementObjectMSFT_NetAdapter[ConstStringHardwareStatic.NETWORK_ADAPTER_DRIVER_VERSION_STRING]?.ToString() ?? string.Empty;
            networkAdapter.InterfaceDescription = managementObjectMSFT_NetAdapter[ConstStringHardwareStatic.NETWORK_ADAPTER_INTERFACE_DESCRIPTION]?.ToString() ?? string.Empty;
            networkAdapter.InterfaceName = managementObjectMSFT_NetAdapter[ConstStringHardwareStatic.NETWORK_ADAPTER_INTERFACE_NAME]?.ToString() ?? string.Empty;
            networkAdapter.Name = managementObjectMSFT_NetAdapter[ConstStringHardwareStatic.NETWORK_ADAPTER_NAME]?.ToString() ?? string.Empty;

            if (managementObjectMSFT_NetAdapter[ConstStringHardwareStatic.NETWORK_ADAPTER_NDIS_MEDIUM] != null)
            {
                networkAdapter.NdisMedium = ((NdisMediumEnum)((uint)managementObjectMSFT_NetAdapter[ConstStringHardwareStatic.NETWORK_ADAPTER_NDIS_MEDIUM])).ToString();
            }
            else
            {
                networkAdapter.NdisMedium = string.Empty;
            }

            if (managementObjectMSFT_NetAdapter[ConstStringHardwareStatic.NETWORK_ADAPTER_NDIS_PHYSICAL_MEDIUM] != null)
            {
                networkAdapter.NdisPhysicalMedium = ((NdisPhysicalMediumEnum)((uint)managementObjectMSFT_NetAdapter[ConstStringHardwareStatic.NETWORK_ADAPTER_NDIS_PHYSICAL_MEDIUM])).ToString();
            }
            else
            {
                networkAdapter.NdisPhysicalMedium = string.Empty;
            }

            networkAdapter.PermanentAddress = managementObjectMSFT_NetAdapter[ConstStringHardwareStatic.NETWORK_ADAPTER_PERMANENT_ADDRESS]?.ToString() ?? string.Empty;
            networkAdapter.Virtual = managementObjectMSFT_NetAdapter[ConstStringHardwareStatic.NETWORK_ADAPTER_VIRTUAL]?.ToString() ?? string.Empty;

            return networkAdapter;
        }

        public Printer ExtractDataPrinter(ManagementObject managementObjectWin32_Printer)
        {
            Printer printer = new Printer();
            printer.AveragePagesPerMinute = managementObjectWin32_Printer[ConstStringHardwareStatic.PRINTER_AVG_PAGES_PER_MINUTE]?.ToString() ?? string.Empty;
            printer.Caption = managementObjectWin32_Printer[ConstStringHardwareStatic.PRINTER_CAPTION]?.ToString() ?? string.Empty;
            printer.Default = managementObjectWin32_Printer[ConstStringHardwareStatic.PRINTER_DEFAULT]?.ToString() ?? string.Empty;
            printer.Description = managementObjectWin32_Printer[ConstStringHardwareStatic.PRINTER_DESCRIPTION]?.ToString() ?? string.Empty;
            printer.DeviceID = managementObjectWin32_Printer[ConstStringHardwareStatic.PRINTER_DEVICE_ID]?.ToString() ?? string.Empty;
            printer.Name = managementObjectWin32_Printer[ConstStringHardwareStatic.PRINTER_NAME]?.ToString() ?? string.Empty;
            printer.PortName = managementObjectWin32_Printer[ConstStringHardwareStatic.PRINTER_PORT_NAME]?.ToString() ?? string.Empty;
            printer.PrintProcessor = managementObjectWin32_Printer[ConstStringHardwareStatic.PRINTER_PRINT_PROCESSOR]?.ToString() ?? string.Empty;

            return printer;
        }

        public VideoController ExtractDataVideoController(ManagementObject managementObjectWin32_VideoController)
        {
            VideoController videoController = new VideoController();
            videoController.AdapterCompatibility = managementObjectWin32_VideoController[ConstStringHardwareStatic.VIDEO_CONTROLLER_ADAPTER_COMPATIBILITY]?.ToString() ?? string.Empty;
            videoController.AdapterDACType = managementObjectWin32_VideoController[ConstStringHardwareStatic.VIDEO_CONTROLLER_ADAPTER_DAC_TYPE]?.ToString() ?? string.Empty;
            videoController.AdapterRAM = new UnitValue(Unit.B, managementObjectWin32_VideoController[ConstStringHardwareStatic.VIDEO_CONTROLLER_ADAPTER_RAM]?.ToString() ?? string.Empty);
            videoController.Caption = managementObjectWin32_VideoController[ConstStringHardwareStatic.VIDEO_CONTROLLER_CAPTION]?.ToString() ?? string.Empty;
            videoController.CurrentBitsPerPixel = new UnitValue(Unit.BIT, managementObjectWin32_VideoController[ConstStringHardwareStatic.VIDEO_CONTROLLER_CURRENT_BITS_PER_PIXEL]?.ToString() ?? string.Empty);
            videoController.CurrentHorizontalResolution = new UnitValue(Unit.PX, managementObjectWin32_VideoController[ConstStringHardwareStatic.VIDEO_CONTROLLER_CURRENT_HORIZONTAL_RESOLUTION]?.ToString() ?? string.Empty);
            videoController.CurrentNumberOfColors = managementObjectWin32_VideoController[ConstStringHardwareStatic.VIDEO_CONTROLLER_CURRENT_NUMBER_OF_COLORS]?.ToString() ?? string.Empty;
            videoController.CurrentRefreshRate = new UnitValue(Unit.HZ, managementObjectWin32_VideoController[ConstStringHardwareStatic.VIDEO_CONTROLLER_CURRENT_REFRESH_RATE]?.ToString() ?? string.Empty);
            videoController.CurrentVerticalResolution = new UnitValue(Unit.PX, managementObjectWin32_VideoController[ConstStringHardwareStatic.VIDEO_CONTROLLER_CURRENT_VERTICAL_RESOLUTION]?.ToString() ?? string.Empty);
            videoController.Description = managementObjectWin32_VideoController[ConstStringHardwareStatic.VIDEO_CONTROLLER_DESCRIPTION]?.ToString() ?? string.Empty;
            videoController.DeviceID = managementObjectWin32_VideoController[ConstStringHardwareStatic.VIDEO_CONTROLLER_DEVICE_ID]?.ToString() ?? string.Empty;
            videoController.DriverVersion = managementObjectWin32_VideoController[ConstStringHardwareStatic.VIDEO_CONTROLLER_DRIVER_VERSION]?.ToString() ?? string.Empty;
            videoController.Name = managementObjectWin32_VideoController[ConstStringHardwareStatic.VIDEO_CONTROLLER_NAME]?.ToString() ?? string.Empty;
            videoController.VideoModeDescription = managementObjectWin32_VideoController[ConstStringHardwareStatic.VIDEO_CONTROLLER_VIDEO_MODE_DESCRIPTION]?.ToString() ?? string.Empty;
            videoController.VideoProcessor = managementObjectWin32_VideoController[ConstStringHardwareStatic.VIDEO_CONTROLLER_VIDEO_PROCESSOR]?.ToString() ?? string.Empty;

            return videoController;
        }
    }
}
