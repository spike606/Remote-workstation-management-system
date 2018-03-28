using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.HardwareStatic.Model.Components.Abstract;
using SystemManagament.Monitor.HardwareStatic.Model.Components.Interface;
using SystemManagament.Monitor.HardwareStatic.Model.CustomProperties;
using SystemManagament.Monitor.HardwareStatic.Model.CustomProperties.Attributes;
using SystemManagament.Monitor.HardwareStatic.Model.CustomProperties.Enums;
using SystemManagament.Shared.WMI;

namespace SystemManagament.Monitor.HardwareStatic.Model.Components
{
    [DataContract]
    public class Volume : HardwareStaticComponent, IHardwareStaticComponent<Volume>
    {
        // based on docs: https://msdn.microsoft.com/en-us/library/windows/desktop/hh830604(v=vs.85).aspx
        [DataMember]
        public string DedupMode { get; set; }

        [DataMember]
        public string DriveLetter { get; set; }

        [DataMember]
        public string DriveType { get; set; }

        [DataMember]
        public string FileSystem { get; set; }

        [DataMember]
        public string FileSystemLabel { get; set; }

        [DataMember]
        public string HealthStatus { get; set; }

        [DataMember]
        public string ObjectId { get; set; }

        [DataMember]
        public string Path { get; set; }

        [DataMember]
        public UnitValue Size { get; set; }

        [DataMember]
        public UnitValue SizeRemaining { get; set; }

        [DataMember]
        public string UniqueId { get; set; }

        public List<Volume> ExtractData(List<ManagementObject> managementObjectList)
        {
            List<Volume> staticData = new List<Volume>();

            foreach (var managementObject in managementObjectList)
            {
                Volume volume = new Volume();
                volume.Caption = string.Empty;
                if (managementObject[ConstString.VOLUME_DRIVE_TYPE] != null)
                {
                    volume.DedupMode = ((DedupModeEnum)((uint)managementObject[ConstString.VOLUME_DEDUP_MODE])).GetEnumDescription();
                }
                else
                {
                    volume.DedupMode = string.Empty;
                }

                volume.Description = string.Empty;
                volume.DriveLetter = managementObject[ConstString.VOLUME_DRIVE_LETTER].TryGetStringValue();

                if (managementObject[ConstString.VOLUME_DRIVE_TYPE] != null)
                {
                    volume.DriveType = ((DriveTypeEnum)((uint)managementObject[ConstString.VOLUME_DRIVE_TYPE])).GetEnumDescription();
                }
                else
                {
                    volume.DriveType = string.Empty;
                }

                volume.FileSystem = managementObject[ConstString.VOLUME_FILE_SYSTEM].TryGetStringValue();
                volume.FileSystemLabel = managementObject[ConstString.VOLUME_FILE_SYTEM_LABEL].TryGetStringValue();

                if (managementObject[ConstString.VOLUME_DRIVE_TYPE] != null)
                {
                    volume.HealthStatus = ((HealthStatusVolumeEnum)((ushort)managementObject[ConstString.VOLUME_HEALTH_STATUS])).GetEnumDescription();
                }
                else
                {
                    volume.HealthStatus = string.Empty;
                }

                volume.Name = string.Empty;
                volume.ObjectId = managementObject[ConstString.VOLUME_OBJECT_ID].TryGetStringValue();
                volume.Path = managementObject[ConstString.VOLUME_PATH].TryGetStringValue();
                volume.Size = managementObject[ConstString.VOLUME_SIZE].TryGetUnitValue(Unit.B);
                volume.SizeRemaining = managementObject[ConstString.VOLUME_SIZE_REMAINING].TryGetUnitValue(Unit.B);
                volume.Status = string.Empty;
                volume.UniqueId = managementObject[ConstString.VOLUME_UNIQUE_ID].TryGetStringValue();
                staticData.Add(volume);
            }

            return staticData;
        }

        public List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstString.WMI_NAMESPACE_ROOT_MICROSOFT_WINDOWS_STORAGE, ConstString.WMI_QUERY_VOLUME);
        }
    }
}
