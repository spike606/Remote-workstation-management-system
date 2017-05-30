using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.Components;
using SystemMonitor.HardwareStatic.WMI;

namespace SystemMonitor.HardwareStatic.Builder
{
    internal class HardwareStaticBuilder : IHardwareStaticBuilder
    {
        public HardwareStaticBuilder(IWMIClient wmiClient, IWMIDataExtractor wmiDataExtractor)
        {
            this.WMIClient = wmiClient;
            this.WMIDataExtractor = wmiDataExtractor;
        }

        private IWMIClient WMIClient { get; set; }

        private IWMIDataExtractor WMIDataExtractor { get; set; }

        public Processor GetProcessorStaticData()
        {
            // In case of multiprocessor computer many instances of Win32_Processor classes exists - do not covered
            ManagementObject managementObjectWin32_Processor = this.WMIClient.RetriveObjectByExecutingWMIQuery(ConstStringHardwareStatic.WMI_QUERY_PROCESSOR);
            List<ManagementObject> managementObjectWin32_CacheMemory = this.WMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstStringHardwareStatic.WMI_NAMESPACE_ROOT_CIMV2, ConstStringHardwareStatic.WMI_QUERY_CACHE_MEMORY);

            return this.WMIDataExtractor.ExtractDataProcessor(managementObjectWin32_Processor, managementObjectWin32_CacheMemory);
        }

        public List<Memory> GetMemoryStaticData()
        {
            List<ManagementObject> managementObjectWin32_PhysicalMemory = this.WMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstStringHardwareStatic.WMI_NAMESPACE_ROOT_CIMV2, ConstStringHardwareStatic.WMI_QUERY_MEMORY);

            List<Memory> memoryStaticData = new List<Memory>();

            foreach (var memoryObject in managementObjectWin32_PhysicalMemory)
            {
                memoryStaticData.Add(this.WMIDataExtractor.ExtractDataMemory(memoryObject));
            }

            return memoryStaticData;
        }

        public List<DiskDrive> GetDiskDriveStaticData()
        {
            List<ManagementObject> managementObjectWin32_DiskDrive = this.WMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstStringHardwareStatic.WMI_NAMESPACE_ROOT_CIMV2, ConstStringHardwareStatic.WMI_QUERY_DISK_DRIVE);

            List<DiskDrive> diskDriveStaticData = new List<DiskDrive>();

            foreach (var diskDriveObject in managementObjectWin32_DiskDrive)
            {
                diskDriveStaticData.Add(this.WMIDataExtractor.ExtractDataDiskDrive(diskDriveObject));
            }

            return diskDriveStaticData;
        }

        public List<LogicalDisk> GetLogicalDiskStaticData()
        {
            List<ManagementObject> managementObjectWin32_LogialDisk = this.WMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstStringHardwareStatic.WMI_NAMESPACE_ROOT_CIMV2, ConstStringHardwareStatic.WMI_QUERY_LOGICAL_DISK);

            List<LogicalDisk> logicalDiskStaticData = new List<LogicalDisk>();

            foreach (var logicalDiskObject in managementObjectWin32_LogialDisk)
            {
                logicalDiskStaticData.Add(this.WMIDataExtractor.ExtractDataLogicalDisk(logicalDiskObject));
            }

            return logicalDiskStaticData;
        }

        public List<CDROMDrive> GetCDROMDriveStaticData()
        {
            List<ManagementObject> managementObjectWin32_CDROMDrive = this.WMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstStringHardwareStatic.WMI_NAMESPACE_ROOT_CIMV2, ConstStringHardwareStatic.WMI_QUERY_CDROM_DRIVE);

            List<CDROMDrive> cdROMDriveStaticData = new List<CDROMDrive>();

            foreach (var cdROMDriveObject in managementObjectWin32_CDROMDrive)
            {
                cdROMDriveStaticData.Add(this.WMIDataExtractor.ExtractDataCDROMDriveDisk(cdROMDriveObject));
            }

            return cdROMDriveStaticData;
        }

        public List<BaseBoard> GetBaseBoardStaticData()
        {
            List<ManagementObject> managementObjectWin32_BaseBoard = this.WMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstStringHardwareStatic.WMI_NAMESPACE_ROOT_CIMV2, ConstStringHardwareStatic.WMI_QUERY_BASE_BOARD);

            List<BaseBoard> baseBoardStaticData = new List<BaseBoard>();

            foreach (var baseBoardObject in managementObjectWin32_BaseBoard)
            {
                baseBoardStaticData.Add(this.WMIDataExtractor.ExtractDataBaseBoard(baseBoardObject));
            }

            return baseBoardStaticData;
        }

        public List<Fan> GetFanData()
        {
            List<ManagementObject> managementObjectWin32_Fan = this.WMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstStringHardwareStatic.WMI_NAMESPACE_ROOT_CIMV2, ConstStringHardwareStatic.WMI_QUERY_FAN);

            List<Fan> fanStaticData = new List<Fan>();

            foreach (var fanObject in managementObjectWin32_Fan)
            {
                fanStaticData.Add(this.WMIDataExtractor.ExtractDataFan(fanObject));
            }

            return fanStaticData;
        }

        public List<Battery> GetBatteryData()
        {
            List<ManagementObject> managementObjectWin32_Battery = this.WMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstStringHardwareStatic.WMI_NAMESPACE_ROOT_CIMV2, ConstStringHardwareStatic.WMI_QUERY_BATTERY);

            List<Battery> batteryStaticData = new List<Battery>();

            foreach (var batteryObject in managementObjectWin32_Battery)
            {
                batteryStaticData.Add(this.WMIDataExtractor.ExtractDataBattery(batteryObject));
            }

            return batteryStaticData;
        }

        public List<NetworkAdapter> GetNetworkAdapterData()
        {
            List<ManagementObject> managementObjectMSFT_NetAdapter = this.WMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstStringHardwareStatic.WMI_NAMESPACE_ROOT_STANDARD_CIMV2, ConstStringHardwareStatic.WMI_QUERY_NETWORK_ADAPTER);

            List<NetworkAdapter> networkAdapterStaticData = new List<NetworkAdapter>();

            foreach (var networkAdapterObject in managementObjectMSFT_NetAdapter)
            {
                networkAdapterStaticData.Add(this.WMIDataExtractor.ExtractDataNetworkAdapter(networkAdapterObject));
            }

            return networkAdapterStaticData;
        }

        public List<Printer> GetPrinterData()
        {
            List<ManagementObject> managementObjectWin32_Printer = this.WMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstStringHardwareStatic.WMI_NAMESPACE_ROOT_CIMV2, ConstStringHardwareStatic.WMI_QUERY_PRINTER);

            List<Printer> printerStaticData = new List<Printer>();

            foreach (var printerObject in managementObjectWin32_Printer)
            {
                printerStaticData.Add(this.WMIDataExtractor.ExtractDataPrinter(printerObject));
            }

            return printerStaticData;
        }

        public List<VideoController> GetVideoControllerData()
        {
            List<ManagementObject> managementObjectWin32_VideoController = this.WMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstStringHardwareStatic.WMI_NAMESPACE_ROOT_CIMV2, ConstStringHardwareStatic.WMI_QUERY_VIDEO_CONTROLLER);

            List<VideoController> videoControllerStaticData = new List<VideoController>();

            foreach (var videoControllerObject in managementObjectWin32_VideoController)
            {
                videoControllerStaticData.Add(this.WMIDataExtractor.ExtractDataVideoController(videoControllerObject));
            }

            return videoControllerStaticData;
        }

        public List<PnPEntity> GetPnPEntityData()
        {
            List<ManagementObject> managementObjectWin32_PnPEntity = this.WMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstStringHardwareStatic.WMI_NAMESPACE_ROOT_CIMV2, ConstStringHardwareStatic.WMI_QUERY_PNP_ENTITY);

            List<PnPEntity> pnPEntityStaticData = new List<PnPEntity>();

            foreach (var pnPEntityObject in managementObjectWin32_PnPEntity)
            {
                pnPEntityStaticData.Add(this.WMIDataExtractor.ExtractDataPnPEntity(pnPEntityObject));
            }

            return pnPEntityStaticData;
        }
    }
}
