using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.HardwareStatic.Model.Components.Abstract;
using SystemManagament.Monitor.HardwareStatic.Model.Components.Interface;
using SystemManagament.Shared.WMI;

namespace SystemManagament.Monitor.HardwareStatic.Model.Components
{
    [DataContract]
    public class CDROMDrive : HardwareStaticComponent, IHardwareStaticComponent<CDROMDrive>
    {
        // based on docs: https://msdn.microsoft.com/en-us/library/aa394081(v=vs.85).aspx
        [DataMember]
        public string DeviceID { get; private set; }

        [DataMember]
        public string Drive { get; private set; }

        [DataMember]
        public string MediaType { get; private set; }

        public List<CDROMDrive> ExtractData(List<ManagementObject> managementObjectList)
        {
            List<CDROMDrive> staticData = new List<CDROMDrive>();

            foreach (var managementObject in managementObjectList)
            {
                CDROMDrive cdROMDrive = new CDROMDrive();
                cdROMDrive.Caption = managementObject[ConstString.COMPONENT_CAPTION].TryGetStringValue();
                cdROMDrive.Description = managementObject[ConstString.COMPONENT_DESCRIPTION].TryGetStringValue();
                cdROMDrive.DeviceID = managementObject[ConstString.CDROM_DRIVE_DEVICE_ID].TryGetStringValue();
                cdROMDrive.Drive = managementObject[ConstString.CDROM_DRIVE_DRIVE].TryGetStringValue();
                cdROMDrive.MediaType = managementObject[ConstString.CDROM_DRIVE_MEDIA_TYPE].TryGetStringValue();
                cdROMDrive.Name = managementObject[ConstString.COMPONENT_NAME].TryGetStringValue();
                cdROMDrive.Status = managementObject[ConstString.COMPONENT_STATUS].TryGetStringValue();

                staticData.Add(cdROMDrive);
            }

            return staticData;
        }

        public List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstString.WMI_NAMESPACE_ROOT_CIMV2, ConstString.WMI_QUERY_CDROM_DRIVE);
        }
    }
}
