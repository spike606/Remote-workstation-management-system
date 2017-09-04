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
    public class StartupCommand : SoftwareStaticComponent, IWMISoftwareStaticComponent
    {
        public string Caption { get; set; }

        public string Command { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public string Name { get; set; }

        public string SettingID { get; set; }

        public string User { get; set; }

        public string UserSID { get; set; }

        public SoftwareStaticComponent ExtractData(ManagementObject managementObject)
        {
            StartupCommand startupCommand = new StartupCommand();
            startupCommand.Caption = managementObject[ConstString.COMPONENT_CAPTION]?.ToString() ?? string.Empty;
            startupCommand.Command = managementObject[ConstString.STARTUP_COMMAND_COMMAND]?.ToString() ?? string.Empty;
            startupCommand.Description = managementObject[ConstString.COMPONENT_DESCRIPTION]?.ToString() ?? string.Empty;
            startupCommand.Location = managementObject[ConstString.STARTUP_COMMAND_LOCATION]?.ToString() ?? string.Empty;
            startupCommand.Name = managementObject[ConstString.COMPONENT_NAME]?.ToString() ?? string.Empty;
            startupCommand.SettingID = managementObject[ConstString.STARTUP_COMMAND_SETTING_ID]?.ToString() ?? string.Empty;
            startupCommand.User = managementObject[ConstString.STARTUP_COMMAND_USER]?.ToString() ?? string.Empty;
            startupCommand.UserSID = managementObject[ConstString.STARTUP_COMMAND_USER_SID]?.ToString() ?? string.Empty;

            return startupCommand;
        }

        public List<ManagementObject> GetManagementObjectsForSoftwareComponent(IWMIClient wmiClient)
        {
            return wmiClient.RetriveListOfObjectsByExecutingWMIQuery(ConstString.WMI_NAMESPACE_ROOT_CIMV2, ConstString.WMI_QUERY_STARTUP_COMMAND);
        }

        public override List<SoftwareStaticComponent> GetStaticDataForSoftwareComponent(ISoftwareStaticProvider softwareStaticProvider)
        {
            return softwareStaticProvider.GetSoftwareStaticDataFromWMI(new StartupCommand());
        }
    }
}
