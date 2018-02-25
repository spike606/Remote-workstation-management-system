using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.HardwareDynamic.Model.Components;

namespace SystemManagament.Monitor.HardwareDynamic.Model
{
    public class HardwareDynamicData
    {
        public List<ProcessorDynamic> Processor { get; set; }

        public List<MemoryDynamic> Memory { get; set; }

        public List<DiskDynamic> Disk { get; set; }

        public List<MainBoardDynamic> MainBoard { get; set; }

        public List<VideoControllerDynamic> VideoController { get; set; }
    }
}
