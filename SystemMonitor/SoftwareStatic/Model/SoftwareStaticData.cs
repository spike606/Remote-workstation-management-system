using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.SoftwareStatic.Model.Components;

namespace SystemMonitor.SoftwareStatic.Model
{
    public class SoftwareStaticData
    {
        public List<WindowsService> WindowsService { get; set; }

        public List<Bios> Bios { get; set; }

        public List<OS> OperatingSystem { get; set; }

        public List<InstalledProgram> InstalledProgram { get; set; }

        public List<StartupCommand> StartupCommand { get; set; }

        public List<MicrosoftWindowsUpdate> MicrosoftWindowsUpdate { get; set; }

        public List<LocalUser> LocalUser { get; set; }

        public List<CurrentUser> CurrentUser { get; set; }
    }
}
