using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.HardwareStatic;
using SystemManagament.Monitor.SoftwareStatic.Model.Components.Duplicate;
using SystemManagament.Monitor.SoftwareStatic.Model.Components.Interface;
using SystemManagament.Monitor.SoftwareStatic.Provider;

namespace SystemManagament.Monitor.SoftwareStatic.Model.Components
{
    // https://support.microsoft.com/en-us/help/243330/well-known-security-identifiers-in-windows-operating-systems
    [DataContract]
    public class CurrentUser : ISoftwareStaticComponent<CurrentUser>
    {
        [DataMember]
        public string Name { get; internal set; } = string.Empty;

        [DataMember]
        public string Sid { get; internal set; } = string.Empty;

        [DataMember]
        public DateTime LastLogonDate { get; internal set; }

        [DataMember]
        public DateTime LastPasswordSet { get; internal set; }

        public List<CurrentUser> GetStaticDataForSoftwareComponent(ISoftwareStaticProvider softwareStaticProvider)
        {
            List<CurrentUser> currentUserList = softwareStaticProvider.GetCurrentUsers();

            return currentUserList;
        }
    }
}
