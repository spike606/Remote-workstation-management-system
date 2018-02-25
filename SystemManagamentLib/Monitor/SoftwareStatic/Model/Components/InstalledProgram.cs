using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using SystemManagament.Monitor.HardwareStatic;
using SystemManagament.Monitor.SoftwareStatic.Model.Components.Interface;
using SystemManagament.Monitor.SoftwareStatic.Provider;

namespace SystemManagament.Monitor.SoftwareStatic.Model.Components
{
    public class InstalledProgram : ISoftwareStaticComponent<InstalledProgram>
    {
        public string InstallLocation { get; set; }

        public DateTime InstallDate { get; set; }

        public string Name { get; set; }

        public string Version { get; set; }

        public List<InstalledProgram> GetStaticDataForSoftwareComponent(ISoftwareStaticProvider softwareStaticProvider)
        {
            return softwareStaticProvider.GetInstalledPrograms();
        }
    }
}
