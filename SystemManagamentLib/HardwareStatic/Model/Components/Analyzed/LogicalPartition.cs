using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.Components.Abstract;
using SystemMonitor.HardwareStatic.Model.CustomProperties;

namespace SystemMonitor.HardwareStatic.Model.Components.Analyzed
{
    public class LogicalPartition
    {
        // based on docs: https://msdn.microsoft.com/en-us/library/windows/desktop/hh830524(v=vs.85).aspx
        public string DiskId { get; internal set; }

        public string DiskNumber { get; internal set; }

        public string DriveLetter { get; internal set; }

        public string IsActive { get; internal set; }

        public string IsBoot { get; internal set; }

        public string IsHidden { get; internal set; }

        public string IsOffline { get; internal set; }

        public string IsReadOnly { get; internal set; }

        public string IsShadowCopy { get; internal set; }

        public string IsSystem { get; internal set; }

        // See https://en.wikipedia.org/wiki/Partition_type#PID_00h
        public string MbrType { get; internal set; }

        public string NoDefaultDriveLetter { get; internal set; }

        public string ObjectIdAsPartition { get; internal set; }

        public UnitValue Offset { get; internal set; }

        public string PartitionNumber { get; internal set; }

        public UnitValue SizeAsPartition { get; internal set; }

        public List<LogicalPartition> Partitions { get; internal set; } = new List<LogicalPartition>();
    }
}
