using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.HardwareStatic.Model.Components;
using SystemManagament.Monitor.HardwareStatic.Model.Components.Analyzed;

namespace SystemManagament.Monitor.HardwareStatic.Model
{
    [DataContract]
    public class HardwareStaticData
    {
        [DataMember]
        public List<ProcessorStatic> Processor { get; set; }

        [DataMember]
        public List<ProcessorCache> ProcessorCache { get; set; }

        [DataMember]
        public List<Memory> Memory { get; set; }

        [DataMember]
        public List<CDROMDrive> CDROMDrive { get; set; }

        [DataMember]
        public List<BaseBoard> BaseBoard { get; set; }

        [DataMember]
        public List<Fan> Fan { get; set; }

        [DataMember]
        public List<Battery> Battery { get; set; }

        [DataMember]
        public List<NetworkAdapter> NetworkAdapter { get; set; }

        [DataMember]
        public List<Printer> Printer { get; set; }

        [DataMember]
        public List<VideoController> VideoController { get; set; }

        [DataMember]
        public List<PnPEntity> PnPEntity { get; set; }

        [DataMember]
        public List<SMARTData> SMARTData { get; set; }

        [DataMember]
        public List<Storage> Storage { get; set; }

        internal List<Disk> Disk { get; set; }

        internal List<Volume> Volume { get; set; }

        internal List<DiskPartition> DiskPartition { get; set; }

        internal List<SmartFailurePredictData> SmartFailurePredictData { get; set; }

        internal List<SmartFailurePredictStatus> SmartFailurePredictStatus { get; set; }

        internal List<SmartFailurePredictThresholds> SmartFailurePredictThresholds { get; set; }

        internal List<DiskToPartition> DiskToPartition { get; set; }

        internal List<PartitionToVolume> PartitionToVolume { get; set; }
    }
}
