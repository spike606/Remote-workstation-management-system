using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic;
using SystemMonitor.Shared.WMI;
using SystemMonitor.SoftwareStatic.Model.Components.Interface;
using SystemMonitor.SoftwareStatic.Provider;

namespace SystemMonitor.SoftwareStatic.Model.Components
{
    // https://support.microsoft.com/en-us/help/243330/well-known-security-identifiers-in-windows-operating-systems
    public class CurrentUser : ISoftwareStaticComponent<CurrentUser>
    {
        public string Name { get; set; }

        public string AuthenticationType { get; private set; }

        public IEnumerable<Claim> Claims { get; private set; }

        public IdentityReferenceCollection Groups { get; private set; }

        public List<CurrentUser> GetStaticDataForSoftwareComponent(ISoftwareStaticProvider softwareStaticProvider)
        {
            List<CurrentUser> currentUserList = new List<CurrentUser>();

            CurrentUser currentUser = new CurrentUser();
            var identity = WindowsIdentity.GetCurrent();

            currentUser.Name = identity.Name;
            currentUser.AuthenticationType = identity.AuthenticationType;
            currentUser.Claims = identity.Claims;
            currentUser.Groups = identity.Groups;

            currentUserList.Add(currentUser);

            return currentUserList;
        }
    }
}
