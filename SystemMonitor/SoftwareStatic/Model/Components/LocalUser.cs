using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic;
using SystemMonitor.Shared.WMI;
using SystemMonitor.SoftwareStatic.Model.Components.Abstract;
using SystemMonitor.SoftwareStatic.SoftwareStaticProvider;

namespace SystemMonitor.SoftwareStatic.Model.Components
{
    public class LocalUser : SoftwareStaticComponent, IWMISoftwareStaticComponent
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

        public SoftwareStaticComponent ExtractData(ManagementObject managementObject)
        {
            LocalUser localUser = new LocalUser();
            localUser.Caption = managementObject[ConstString.COMPONENT_CAPTION]?.ToString() ?? string.Empty;
            localUser.Descritption = managementObject[ConstString.COMPONENT_DESCRIPTION]?.ToString() ?? string.Empty;
            localUser.Domain = managementObject[ConstString.LOCAL_USER_DOMAIN]?.ToString() ?? string.Empty;
            localUser.FullName = managementObject[ConstString.LOCAL_USER_FULL_NAME]?.ToString() ?? string.Empty;
            localUser.Name = managementObject[ConstString.COMPONENT_NAME]?.ToString() ?? string.Empty;
            localUser.PasswordChangeable = managementObject[ConstString.LOCAL_USER_PASSWORD_CHANGEABLE]?.ToString() ?? string.Empty;
            localUser.PasswordExpires = managementObject[ConstString.LOCAL_USER_PASSWORD_EXPIRES]?.ToString() ?? string.Empty;
            localUser.PasswordRequired = managementObject[ConstString.LOCAL_USER_PASSWORD_REQUIRED]?.ToString() ?? string.Empty;
            localUser.SID = managementObject[ConstString.LOCAL_USER_SID]?.ToString() ?? string.Empty;
            localUser.SIDType = managementObject[ConstString.LOCAL_USER_SID_TYPE]?.ToString() ?? string.Empty;

            return localUser;
        }

        public List<ManagementObject> GetManagementObjectsForSoftwareComponent(IWMIClient wmiClient)
        {
            return wmiClient.RetriveListOfObjectsByExecutingWMIQuery(ConstString.WMI_NAMESPACE_ROOT_CIMV2, ConstString.WMI_QUERY_LOCAL_USER);
        }

        public override List<SoftwareStaticComponent> GetStaticDataForSoftwareComponent(ISoftwareStaticProvider softwareStaticProvider)
        {
            return softwareStaticProvider.GetSoftwareStaticDataFromWMI(new LocalUser());
        }
    }
}
