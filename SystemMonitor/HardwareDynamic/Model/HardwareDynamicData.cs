using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareDynamic.Model.Components;
using SystemMonitor.HardwareDynamic.Model.Components.Abstract;

namespace SystemMonitor.HardwareDynamic.Model
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
