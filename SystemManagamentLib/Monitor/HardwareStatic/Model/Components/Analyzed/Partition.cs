using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.HardwareStatic.Model.CustomProperties;

namespace SystemManagament.Monitor.HardwareStatic.Model.Components.Analyzed
{
    [DataContract]
    public class Partition : LogicalPartition
    {
        // based on docs: https://msdn.microsoft.com/en-us/library/windows/desktop/hh830604(v=vs.85).aspx
        [DataMember]
        public string DedupMode { get; internal set; }

        [DataMember]
        public string DriveType { get; internal set; }

        [DataMember]
        public string FileSystem { get; internal set; }

        [DataMember]
        public string FileSystemLabel { get; internal set; }

        [DataMember]
        public string HealthStatus { get; internal set; }

        [DataMember]
        public string ObjectIdAsVolume { get; internal set; }

        [DataMember]
        public string Path { get; internal set; }

        [DataMember]
        public UnitULongValue SizeAsVolume { get; internal set; }

        [DataMember]
        public UnitULongValue SizeRemaining { get; internal set; }

        [DataMember]
        public string UniqueId { get; internal set; }
    }
}
