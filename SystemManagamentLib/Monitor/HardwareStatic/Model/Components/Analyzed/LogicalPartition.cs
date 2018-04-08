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
    [KnownType(typeof(Partition))]
    public class LogicalPartition
    {
        // based on docs: https://msdn.microsoft.com/en-us/library/windows/desktop/hh830524(v=vs.85).aspx
        [DataMember]
        public string DiskId { get; set; }

        [DataMember]
        public string DiskNumber { get; set; }

        [DataMember]
        public string DriveLetter { get; set; }

        [DataMember]
        public string IsActive { get; set; }

        [DataMember]
        public string IsBoot { get; set; }

        [DataMember]
        public string IsHidden { get; set; }

        [DataMember]
        public string IsOffline { get; set; }

        [DataMember]
        public string IsReadOnly { get; set; }

        [DataMember]
        public string IsShadowCopy { get; set; }

        [DataMember]
        public string IsSystem { get; set; }

        // See https://en.wikipedia.org/wiki/Partition_type#PID_00h
        [DataMember]
        public string MbrType { get; set; }

        [DataMember]
        public string NoDefaultDriveLetter { get; set; }

        [DataMember]
        public string ObjectIdAsPartition { get; set; }

        [DataMember]
        public UnitValue Offset { get; set; }

        [DataMember]
        public string PartitionNumber { get; set; }

        [DataMember]
        public UnitValue SizeAsPartition { get; set; }

        [DataMember]
        public List<LogicalPartition> Partitions { get; set; } = new List<LogicalPartition>();
    }
}
