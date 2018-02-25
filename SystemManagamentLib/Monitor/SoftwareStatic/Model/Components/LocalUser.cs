using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.HardwareStatic;
using SystemManagament.Monitor.SoftwareStatic.Model.Components.Interface;
using SystemManagament.Monitor.SoftwareStatic.Provider;
using SystemManagament.Shared.WMI;

namespace SystemManagament.Monitor.SoftwareStatic.Model.Components
{
    public class LocalUser : ISoftwareStaticComponent<LocalUser>, IWMISoftwareStaticComponent<LocalUser>
    {
        public string Caption { get; set; }

        public string Descritption { get; set; }

        public string Domain { get; set; }

        public string FullName { get; set; }

        public string Name { get; set; }

        public string PasswordChangeable { get; set; }

        public string PasswordExpires { get; set; }

        public string PasswordRequired { get; set; }

        public string SID { get; set; }

        public string SIDType { get; set; }

        public LocalUser ExtractData(ManagementObject managementObject)
        {
            LocalUser localUser = new LocalUser();
            localUser.Caption = managementObject[ConstString.COMPONENT_CAPTION].TryGetStringValue();
            localUser.Descritption = managementObject[ConstString.COMPONENT_DESCRIPTION].TryGetStringValue();
            localUser.Domain = managementObject[ConstString.LOCAL_USER_DOMAIN].TryGetStringValue();
            localUser.FullName = managementObject[ConstString.LOCAL_USER_FULL_NAME].TryGetStringValue();
            localUser.Name = managementObject[ConstString.COMPONENT_NAME].TryGetStringValue();
            localUser.PasswordChangeable = managementObject[ConstString.LOCAL_USER_PASSWORD_CHANGEABLE].TryGetStringValue();
            localUser.PasswordExpires = managementObject[ConstString.LOCAL_USER_PASSWORD_EXPIRES].TryGetStringValue();
            localUser.PasswordRequired = managementObject[ConstString.LOCAL_USER_PASSWORD_REQUIRED].TryGetStringValue();
            localUser.SID = managementObject[ConstString.LOCAL_USER_SID].TryGetStringValue();
            localUser.SIDType = managementObject[ConstString.LOCAL_USER_SID_TYPE].TryGetStringValue();

            return localUser;
        }

        public List<ManagementObject> GetManagementObjectsForSoftwareComponent(IWMIClient wmiClient)
        {
            return wmiClient.RetriveListOfObjectsByExecutingWMIQuery(ConstString.WMI_NAMESPACE_ROOT_CIMV2, ConstString.WMI_QUERY_LOCAL_USER);
        }

        public List<LocalUser> GetStaticDataForSoftwareComponent(ISoftwareStaticProvider softwareStaticProvider)
        {
            return softwareStaticProvider.GetSoftwareStaticDataFromWMI<LocalUser>();
        }
    }
}
