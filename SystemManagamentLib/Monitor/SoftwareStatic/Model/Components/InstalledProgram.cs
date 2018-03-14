using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using SystemManagament.Monitor.HardwareStatic;
using SystemManagament.Monitor.SoftwareStatic.Model.Components.Interface;
using SystemManagament.Monitor.SoftwareStatic.Provider;

namespace SystemManagament.Monitor.SoftwareStatic.Model.Components
{
    [DataContract]
    public class InstalledProgram : ISoftwareStaticComponent<InstalledProgram>
    {
        [DataMember]
        public string InstallLocation { get; set; }

        [DataMember]
        public DateTime InstallDate { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Version { get; set; }

        public List<InstalledProgram> GetStaticDataForSoftwareComponent(ISoftwareStaticProvider softwareStaticProvider)
        {
            return softwareStaticProvider.GetInstalledPrograms();
        }
    }
}
