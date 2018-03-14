using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.SoftwareStatic.Model.Components;

namespace SystemManagament.Monitor.SoftwareStatic.Model
{
    [DataContract]
    public class SoftwareStaticData
    {
        [DataMember]
        public List<Bios> Bios { get; set; }

        [DataMember]
        public List<OS> OperatingSystem { get; set; }

        [DataMember]
        public List<InstalledProgram> InstalledProgram { get; set; }

        [DataMember]
        public List<StartupCommand> StartupCommand { get; set; }

        [DataMember]
        public List<MicrosoftWindowsUpdate> MicrosoftWindowsUpdate { get; set; }

        [DataMember]
        public List<LocalUser> LocalUser { get; set; }

        [DataMember]
        public List<CurrentUser> CurrentUser { get; set; }
    }
}
