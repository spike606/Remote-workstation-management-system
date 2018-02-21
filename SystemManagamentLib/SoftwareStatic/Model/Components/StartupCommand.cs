using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic;
using SystemMonitor.Shared.WMI;
using SystemMonitor.SoftwareStatic.Model.Components.Interface;
using SystemMonitor.SoftwareStatic.Provider;

namespace SystemMonitor.SoftwareStatic.Model.Components
{
    public class StartupCommand : ISoftwareStaticComponent<StartupCommand>, IWMISoftwareStaticComponent<StartupCommand>
    {
        public string Caption { get; set; }

        public string Command { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public string Name { get; set; }

        public string SettingID { get; set; }

        public string User { get; set; }

        public string UserSID { get; set; }

        public StartupCommand ExtractData(ManagementObject managementObject)
        {
            StartupCommand startupCommand = new StartupCommand();
            startupCommand.Caption = managementObject[ConstString.COMPONENT_CAPTION].TryGetStringValue();
            startupCommand.Command = managementObject[ConstString.STARTUP_COMMAND_COMMAND].TryGetStringValue();
            startupCommand.Description = managementObject[ConstString.COMPONENT_DESCRIPTION].TryGetStringValue();
            startupCommand.Location = managementObject[ConstString.STARTUP_COMMAND_LOCATION].TryGetStringValue();
            startupCommand.Name = managementObject[ConstString.COMPONENT_NAME].TryGetStringValue();
            startupCommand.SettingID = managementObject[ConstString.STARTUP_COMMAND_SETTING_ID].TryGetStringValue();
            startupCommand.User = managementObject[ConstString.STARTUP_COMMAND_USER].TryGetStringValue();
            startupCommand.UserSID = managementObject[ConstString.STARTUP_COMMAND_USER_SID].TryGetStringValue();

            return startupCommand;
        }

        public List<ManagementObject> GetManagementObjectsForSoftwareComponent(IWMIClient wmiClient)
        {
            return wmiClient.RetriveListOfObjectsByExecutingWMIQuery(ConstString.WMI_NAMESPACE_ROOT_CIMV2, ConstString.WMI_QUERY_STARTUP_COMMAND);
        }

        public List<StartupCommand> GetStaticDataForSoftwareComponent(ISoftwareStaticProvider softwareStaticProvider)
        {
            return softwareStaticProvider.GetSoftwareStaticDataFromWMI<StartupCommand>();
        }
    }
}
