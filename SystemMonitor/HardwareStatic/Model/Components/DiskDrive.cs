using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.Components.Abstract;
using SystemMonitor.HardwareStatic.Model.CustomProperties;
using SystemMonitor.HardwareStatic.WMI;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class DiskDrive : HardwareComponent
    {
        // based on docs: https://msdn.microsoft.com/en-us/library/aa394132(v=vs.85).aspx
        public UnitValue BytesPerSector { get; private set; }

        public string DeviceID { get; private set; }

        public string FirmwareRevision { get; private set; }

        public string InterfaceType { get; private set; }

        public string Index { get; private set; }

        public string MediaType { get; private set; }

        public string Model { get; private set; }

        // Total number of partitions - extended partitions does not count
        public string Partitions { get; private set; }

        public string SerialNumber { get; private set; }

        public string Signature { get; private set; }

        public UnitValue Size { get; private set; }

        public string TotalCylinders { get; private set; }

        public string TotalHeads { get; private set; }

        public string TotalSectors { get; private set; }

        public string TotalTracks { get; private set; }

        public string TracksPerCylinder { get; private set; }

        public override HardwareComponent ExtractData(ManagementObject managementObject)
        {
            DiskDrive diskDrive = new DiskDrive();
            diskDrive.BytesPerSector = new UnitValue(Unit.B, managementObject[ConstStringHardwareStatic.DISK_DRIVE_BYTES_PER_SECTOR]?.ToString() ?? string.Empty);
            diskDrive.Caption = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_CAPTION]?.ToString() ?? string.Empty;
            diskDrive.Description = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_DESCRIPTION]?.ToString() ?? string.Empty;
            diskDrive.DeviceID = managementObject[ConstStringHardwareStatic.DISK_DRIVE_DEVICE_ID]?.ToString() ?? string.Empty;
            diskDrive.FirmwareRevision = managementObject[ConstStringHardwareStatic.DISK_DRIVE_FIRMWARE_REVISION]?.ToString() ?? string.Empty;
            diskDrive.InterfaceType = managementObject[ConstStringHardwareStatic.DISK_DRIVE_INTERFACE_TYPE]?.ToString() ?? string.Empty;
            diskDrive.Index = managementObject[ConstStringHardwareStatic.DISK_DRIVE_INDEX]?.ToString() ?? string.Empty;
            diskDrive.MediaType = managementObject[ConstStringHardwareStatic.DISK_DRIVE_MEDIA_TYPE]?.ToString() ?? string.Empty;
            diskDrive.Model = managementObject[ConstStringHardwareStatic.DISK_DRIVE_MODEL]?.ToString() ?? string.Empty;
            diskDrive.Name = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_NAME]?.ToString() ?? string.Empty;
            diskDrive.Partitions = managementObject[ConstStringHardwareStatic.DISK_DRIVE_PARTITIONS]?.ToString() ?? string.Empty;
            diskDrive.SerialNumber = managementObject[ConstStringHardwareStatic.DISK_DRIVE_SERIAL_NUMBER]?.ToString() ?? string.Empty;
            diskDrive.Signature = managementObject[ConstStringHardwareStatic.DISK_DRIVE_SIGNATURE]?.ToString() ?? string.Empty;
            diskDrive.Size = new UnitValue(Unit.B, managementObject[ConstStringHardwareStatic.DISK_DRIVE_SIZE]?.ToString() ?? string.Empty);
            diskDrive.Status = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_STATUS]?.ToString() ?? string.Empty;
            diskDrive.TotalCylinders = managementObject[ConstStringHardwareStatic.DISK_DRIVE_TOTAL_CYLINDERS]?.ToString() ?? string.Empty;
            diskDrive.TotalHeads = managementObject[ConstStringHardwareStatic.DISK_DRIVE_TOTAL_HEADS]?.ToString() ?? string.Empty;
            diskDrive.TotalSectors = managementObject[ConstStringHardwareStatic.DISK_DRIVE_TOTAL_SECTORS]?.ToString() ?? string.Empty;
            diskDrive.TotalTracks = managementObject[ConstStringHardwareStatic.DISK_DRIVE_TOTAL_TRACKS]?.ToString() ?? string.Empty;
            diskDrive.TracksPerCylinder = managementObject[ConstStringHardwareStatic.DISK_DRIVE_TRACKS_PER_CYLINDER]?.ToString() ?? string.Empty;

            return diskDrive;
        }

        public override List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstStringHardwareStatic.WMI_NAMESPACE_ROOT_CIMV2, ConstStringHardwareStatic.WMI_QUERY_DISK_DRIVE);
        }
    }
}
