using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.HardwareDynamic.Model.Components;

namespace SystemManagament.Monitor.HardwareDynamic.Model
{
    [DataContract]
    public class HardwareDynamicData
    {
        [DataMember]
        public List<ProcessorDynamic> Processor { get; set; }

        [DataMember]
        public List<MemoryDynamic> Memory { get; set; }

        [DataMember]
        public List<DiskDynamic> Disk { get; set; }

        [DataMember]
        public List<MainBoardDynamic> MainBoard { get; set; }

        [DataMember]
        public List<VideoControllerDynamic> VideoController { get; set; }
    }
}
