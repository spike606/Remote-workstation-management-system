using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.CustomProperties;
using SystemMonitor.HardwareStatic.WMI;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class DiskDrive : IHardwareComponent
    {
        public UnitValue BytesPerSector { get; set; }

        public string Caption { get; set; }

        public string Description { get; set; }

        public string DeviceID { get; set; }

        public string FirmwareRevision { get; set; }

        public string InterfaceType { get; set; }

        public string MediaType { get; set; }

        public string Model { get; set; }

        public string Name { get; set; }

        public string Partitions { get; set; }

        public string SerialNumber { get; set; }

        public string Signature { get; set; }

        public UnitValue Size { get; set; }

        public string TotalCylinders { get; set; }

        public string TotalHeads { get; set; }

        public string TotalSectors { get; set; }

        public string TotalTracks { get; set; }

        public string TracksPerCylinder { get; set; }

        public IHardwareComponent ExtractData(ManagementObject managementObject)
        {
            DiskDrive diskDrive = new DiskDrive();
            diskDrive.BytesPerSector = new UnitValue(Unit.B, managementObject[ConstStringHardwareStatic.DISK_DRIVE_BYTES_PER_SECTOR]?.ToString() ?? string.Empty);
            diskDrive.Caption = managementObject[ConstStringHardwareStatic.DISK_DRIVE_CAPTION]?.ToString() ?? string.Empty;
            diskDrive.Description = managementObject[ConstStringHardwareStatic.DISK_DRIVE_DESCRIPTION]?.ToString() ?? string.Empty;
            diskDrive.DeviceID = managementObject[ConstStringHardwareStatic.DISK_DRIVE_DEVICE_ID]?.ToString() ?? string.Empty;
            diskDrive.FirmwareRevision = managementObject[ConstStringHardwareStatic.DISK_DRIVE_FIRMWARE_REVISION]?.ToString() ?? string.Empty;
            diskDrive.InterfaceType = managementObject[ConstStringHardwareStatic.DISK_DRIVE_INTERFACE_TYPE]?.ToString() ?? string.Empty;
            diskDrive.MediaType = managementObject[ConstStringHardwareStatic.DISK_DRIVE_MEDIA_TYPE]?.ToString() ?? string.Empty;
            diskDrive.Model = managementObject[ConstStringHardwareStatic.DISK_DRIVE_MODEL]?.ToString() ?? string.Empty;
            diskDrive.Name = managementObject[ConstStringHardwareStatic.DISK_DRIVE_NAME]?.ToString() ?? string.Empty;
            diskDrive.Partitions = managementObject[ConstStringHardwareStatic.DISK_DRIVE_PARTITIONS]?.ToString() ?? string.Empty;
            diskDrive.SerialNumber = managementObject[ConstStringHardwareStatic.DISK_DRIVE_SERIAL_NUMBER]?.ToString() ?? string.Empty;
            diskDrive.Signature = managementObject[ConstStringHardwareStatic.DISK_DRIVE_SIGNATURE]?.ToString() ?? string.Empty;
            diskDrive.Size = new UnitValue(Unit.B, managementObject[ConstStringHardwareStatic.DISK_DRIVE_SIZE]?.ToString() ?? string.Empty);
            diskDrive.TotalCylinders = managementObject[ConstStringHardwareStatic.DISK_DRIVE_TOTAL_CYLINDERS]?.ToString() ?? string.Empty;
            diskDrive.TotalHeads = managementObject[ConstStringHardwareStatic.DISK_DRIVE_TOTAL_HEADS]?.ToString() ?? string.Empty;
            diskDrive.TotalSectors = managementObject[ConstStringHardwareStatic.DISK_DRIVE_TOTAL_SECTORS]?.ToString() ?? string.Empty;
            diskDrive.TotalTracks = managementObject[ConstStringHardwareStatic.DISK_DRIVE_TOTAL_TRACKS]?.ToString() ?? string.Empty;
            diskDrive.TracksPerCylinder = managementObject[ConstStringHardwareStatic.DISK_DRIVE_TRACKS_PER_CYLINDER]?.ToString() ?? string.Empty;

            return diskDrive;
        }

        public List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstStringHardwareStatic.WMI_NAMESPACE_ROOT_CIMV2, ConstStringHardwareStatic.WMI_QUERY_DISK_DRIVE);
        }
    }
}
