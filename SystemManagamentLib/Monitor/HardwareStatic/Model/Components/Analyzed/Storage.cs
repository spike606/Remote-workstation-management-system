using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagament.Monitor.HardwareStatic.Model.Components.Analyzed
{
    [DataContract]
    public class Storage
    {
        [DataMember]
        public Disk Disk { get; set; }

        [DataMember]
        public List<LogicalPartition> Partition { get; set; }

        [DataMember]
        public SMARTData SMARTData { get; set; }
    }
}
