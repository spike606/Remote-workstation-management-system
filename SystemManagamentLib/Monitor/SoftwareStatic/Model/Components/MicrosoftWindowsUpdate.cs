using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.HardwareStatic;
using SystemManagament.Monitor.SoftwareStatic.Model.Components.Interface;
using SystemManagament.Monitor.SoftwareStatic.Provider;
using SystemManagament.Shared;
using SystemManagament.Shared.WMI;

namespace SystemManagament.Monitor.SoftwareStatic.Model.Components
{
    [DataContract]
    public class MicrosoftWindowsUpdate : ISoftwareStaticComponent<MicrosoftWindowsUpdate>, IWMISoftwareStaticComponent<MicrosoftWindowsUpdate>
    {
        [DataMember]
        public string Caption { get; set; }

        [DataMember]
        public string CSName { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string FixComments { get; set; }

        [DataMember]
        public string HotFixID { get; set; }

        [DataMember]
        public DateTime InstallDate { get; set; }

        [DataMember]
        public string InstalledBy { get; set; }

        [DataMember]
        public DateTime InstalledOn { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string ServicePackInEffect { get; set; }

        [DataMember]
        public string Status { get; set; }

        public MicrosoftWindowsUpdate ExtractData(ManagementObject managementObject)
        {
            MicrosoftWindowsUpdate microsoftWindowsUpdate = new MicrosoftWindowsUpdate();
            microsoftWindowsUpdate.Caption = managementObject[ConstString.COMPONENT_CAPTION].TryGetStringValue();
            microsoftWindowsUpdate.CSName = managementObject[ConstString.QUICK_FIX_ENGINEERING_CSNAME].TryGetStringValue();
            microsoftWindowsUpdate.Description = managementObject[ConstString.COMPONENT_DESCRIPTION].TryGetStringValue();
            microsoftWindowsUpdate.FixComments = managementObject[ConstString.QUICK_FIX_ENGINEERING_FIX_COMMENTS].TryGetStringValue();
            microsoftWindowsUpdate.HotFixID = managementObject[ConstString.QUICK_FIX_ENGINEERING_HOT_FIX_ID].TryGetStringValue();
            string installdateAsString = managementObject[ConstString.QUICK_FIX_ENGINEERING_INSTALL_DATE].TryGetStringValue();
            microsoftWindowsUpdate.InstallDate = DateTimeHelper.ConvertRegistryDateStringToCorrectDateTimeFormat(installdateAsString);
            microsoftWindowsUpdate.InstalledBy = managementObject[ConstString.QUICK_FIX_ENGINEERING_INSTALLED_BY].TryGetStringValue();
            string installedOnAsString = managementObject[ConstString.QUICK_FIX_ENGINEERING_INSTALLED_ON].TryGetStringValue();
            microsoftWindowsUpdate.InstalledOn = DateTimeHelper.ConvertRegistryDateStringToCorrectDateTimeFormat(installedOnAsString);
            microsoftWindowsUpdate.Name = managementObject[ConstString.COMPONENT_NAME].TryGetStringValue();
            microsoftWindowsUpdate.ServicePackInEffect = managementObject[ConstString.QUICK_FIX_ENGINEERING_SERVICE_PACK_IN_EFFECT].TryGetStringValue();
            microsoftWindowsUpdate.Status = managementObject[ConstString.COMPONENT_STATUS].TryGetStringValue();

            return microsoftWindowsUpdate;
        }

        public List<ManagementObject> GetManagementObjectsForSoftwareComponent(IWMIClient wmiClient)
        {
            return wmiClient.RetriveListOfObjectsByExecutingWMIQuery(ConstString.WMI_NAMESPACE_ROOT_CIMV2, ConstString.WMI_QUERY_STARTUP_QUICK_FIX_ENGINEERING);
        }

        public List<MicrosoftWindowsUpdate> GetStaticDataForSoftwareComponent(ISoftwareStaticProvider softwareStaticProvider)
        {
            return softwareStaticProvider.GetSoftwareStaticDataFromWMI<MicrosoftWindowsUpdate>();
        }
    }
}
