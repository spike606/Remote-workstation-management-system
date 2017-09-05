using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic;
using SystemMonitor.Shared;
using SystemMonitor.Shared.WMI;
using SystemMonitor.SoftwareStatic.Model.Components.Abstract;
using SystemMonitor.SoftwareStatic.SoftwareStaticProvider;

namespace SystemMonitor.SoftwareStatic.Model.Components
{
    public class MicrosoftWindowsUpdate : SoftwareStaticComponent, IWMISoftwareStaticComponent
    {
        public string Caption { get; set; }

        public string CSName { get; set; }

        public string Description { get; set; }

        public string FixComments { get; set; }

        public string HotFixID { get; set; }

        public DateTime InstallDate { get; set; }

        public string InstalledBy { get; set; }

        public DateTime InstalledOn { get; set; }

        public string Name { get; set; }

        public string ServicePackInEffect { get; set; }

        public string Status { get; set; }

        public SoftwareStaticComponent ExtractData(ManagementObject managementObject)
        {
            MicrosoftWindowsUpdate microsoftWindowsUpdate = new MicrosoftWindowsUpdate();
            microsoftWindowsUpdate.Caption = managementObject[ConstString.COMPONENT_CAPTION]?.ToString() ?? string.Empty;
            microsoftWindowsUpdate.CSName = managementObject[ConstString.QUICK_FIX_ENGINEERING_CSNAME]?.ToString() ?? string.Empty;
            microsoftWindowsUpdate.Description = managementObject[ConstString.COMPONENT_DESCRIPTION]?.ToString() ?? string.Empty;
            microsoftWindowsUpdate.FixComments = managementObject[ConstString.QUICK_FIX_ENGINEERING_FIX_COMMENTS]?.ToString() ?? string.Empty;
            microsoftWindowsUpdate.HotFixID = managementObject[ConstString.QUICK_FIX_ENGINEERING_HOT_FIX_ID]?.ToString() ?? string.Empty;
            string installdateAsString = managementObject[ConstString.QUICK_FIX_ENGINEERING_INSTALL_DATE]?.ToString() ?? string.Empty;
            microsoftWindowsUpdate.InstallDate = DateTimeHelper.ConvertRegistryDateStringToCorrectDateTimeFormat(installdateAsString);
            microsoftWindowsUpdate.InstalledBy = managementObject[ConstString.QUICK_FIX_ENGINEERING_INSTALLED_BY]?.ToString() ?? string.Empty;
            string installedOnAsString = managementObject[ConstString.QUICK_FIX_ENGINEERING_INSTALLED_ON]?.ToString() ?? string.Empty;
            microsoftWindowsUpdate.InstalledOn = DateTimeHelper.ConvertRegistryDateStringToCorrectDateTimeFormat(installedOnAsString);
            microsoftWindowsUpdate.Name = managementObject[ConstString.COMPONENT_NAME]?.ToString() ?? string.Empty;
            microsoftWindowsUpdate.ServicePackInEffect = managementObject[ConstString.QUICK_FIX_ENGINEERING_SERVICE_PACK_IN_EFFECT]?.ToString() ?? string.Empty;
            microsoftWindowsUpdate.Status = managementObject[ConstString.COMPONENT_STATUS]?.ToString() ?? string.Empty;

            return microsoftWindowsUpdate;
        }

        public List<ManagementObject> GetManagementObjectsForSoftwareComponent(IWMIClient wmiClient)
        {
            return wmiClient.RetriveListOfObjectsByExecutingWMIQuery(ConstString.WMI_NAMESPACE_ROOT_CIMV2, ConstString.WMI_QUERY_STARTUP_QUICK_FIX_ENGINEERING);
        }

        public override List<SoftwareStaticComponent> GetStaticDataForSoftwareComponent(ISoftwareStaticProvider softwareStaticProvider)
        {
            return softwareStaticProvider.GetSoftwareStaticDataFromWMI(new MicrosoftWindowsUpdate());
        }
    }
}
