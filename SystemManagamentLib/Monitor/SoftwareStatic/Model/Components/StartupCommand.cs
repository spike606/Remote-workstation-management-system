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
using SystemManagament.Shared.WMI;

namespace SystemManagament.Monitor.SoftwareStatic.Model.Components
{
    [DataContract]
    public class StartupCommand : ISoftwareStaticComponent<StartupCommand>, IWMISoftwareStaticComponent<StartupCommand>
    {
        [DataMember]
        public string Caption { get; set; }

        [DataMember]
        public string Command { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Location { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string SettingID { get; set; }

        [DataMember]
        public string User { get; set; }

        [DataMember]
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
