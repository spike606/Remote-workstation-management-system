using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.HardwareStatic.Model.CustomProperties;

namespace SystemManagament.Monitor.HardwareStatic.Model.Components.Analyzed
{
    public class Partition : LogicalPartition
    {
        // based on docs: https://msdn.microsoft.com/en-us/library/windows/desktop/hh830604(v=vs.85).aspx
        public string DedupMode { get; internal set; }

        public string DriveType { get; internal set; }

        public string FileSystem { get; internal set; }

        public string FileSystemLabel { get; internal set; }

        public string HealthStatus { get; internal set; }

        public string ObjectIdAsVolume { get; internal set; }

        public string Path { get; internal set; }

        public UnitValue SizeAsVolume { get; internal set; }

        public UnitValue SizeRemaining { get; internal set; }

        public string UniqueId { get; internal set; }
    }
}
