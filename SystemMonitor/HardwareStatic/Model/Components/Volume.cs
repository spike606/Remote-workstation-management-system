using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model;
using SystemMonitor.HardwareStatic.Model.Components.Abstract;
using SystemMonitor.HardwareStatic.Model.CustomProperties;
using SystemMonitor.HardwareStatic.Model.CustomProperties.Attributes;
using SystemMonitor.HardwareStatic.Model.CustomProperties.Enums;
using SystemMonitor.HardwareStatic.WMI;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class Volume : HardwareComponent
    {
        // based on docs: https://msdn.microsoft.com/en-us/library/windows/desktop/hh830604(v=vs.85).aspx
        public string DedupMode { get; private set; }

        public string DriveLetter { get; private set; }

        public string DriveType { get; private set; }

        public string FileSystem { get; private set; }

        public string FileSystemLabel { get; private set; }

        public string HealthStatus { get; private set; }

        public string ObjectId { get; private set; }

        public string Path { get; private set; }

        public UnitValue Size { get; private set; }

        public UnitValue SizeRemaining { get; private set; }

        public string UniqueId { get; private set; }

        public override HardwareComponent ExtractData(ManagementObject managementObject)
        {
            Volume volume = new Volume();
            volume.Caption = string.Empty;
            if (managementObject[ConstStringHardwareStatic.VOLUME_DRIVE_TYPE] != null)
            {
                volume.DedupMode = ((DedupModeEnum)((uint)managementObject[ConstStringHardwareStatic.VOLUME_DEDUP_MODE])).GetEnumDescription();
            }
            else
            {
                volume.DedupMode = string.Empty;
            }

            volume.Description = string.Empty;
            volume.DriveLetter = managementObject[ConstStringHardwareStatic.VOLUME_DRIVE_LETTER]?.ToString() ?? string.Empty;

            if (managementObject[ConstStringHardwareStatic.VOLUME_DRIVE_TYPE] != null)
            {
                volume.DriveType = ((DriveTypeEnum)((uint)managementObject[ConstStringHardwareStatic.VOLUME_DRIVE_TYPE])).GetEnumDescription();
            }
            else
            {
                volume.DriveType = string.Empty;
            }

            volume.FileSystem = managementObject[ConstStringHardwareStatic.VOLUME_FILE_SYSTEM]?.ToString() ?? string.Empty;
            volume.FileSystemLabel = managementObject[ConstStringHardwareStatic.VOLUME_FILE_SYTEM_LABEL]?.ToString() ?? string.Empty;

            if (managementObject[ConstStringHardwareStatic.VOLUME_DRIVE_TYPE] != null)
            {
                volume.HealthStatus = ((HealthStatusVolumeEnum)((ushort)managementObject[ConstStringHardwareStatic.VOLUME_HEALTH_STATUS])).GetEnumDescription();
            }
            else
            {
                volume.HealthStatus = string.Empty;
            }

            volume.Name = string.Empty;
            volume.ObjectId = managementObject[ConstStringHardwareStatic.VOLUME_OBJECT_ID]?.ToString() ?? string.Empty;
            volume.Path = managementObject[ConstStringHardwareStatic.VOLUME_PATH]?.ToString() ?? string.Empty;
            volume.Size = new UnitValue(Unit.B, managementObject[ConstStringHardwareStatic.VOLUME_SIZE]?.ToString() ?? string.Empty);
            volume.SizeRemaining = new UnitValue(Unit.B, managementObject[ConstStringHardwareStatic.VOLUME_SIZE_REMAINING]?.ToString() ?? string.Empty);
            volume.Status = string.Empty;
            volume.UniqueId = managementObject[ConstStringHardwareStatic.VOLUME_UNIQUE_ID]?.ToString() ?? string.Empty;

            return volume;
        }

        public override List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstStringHardwareStatic.WMI_NAMESPACE_ROOT_MICROSOFT_WINDOWS_STORAGE, ConstStringHardwareStatic.WMI_QUERY_VOLUME);
        }
    }
}
