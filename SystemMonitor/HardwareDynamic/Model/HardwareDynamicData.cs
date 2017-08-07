using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareDynamic.Model.Components.Abstract;

namespace SystemMonitor.HardwareDynamic.Model
{
    public class HardwareDynamicData
    {
        public HardwareDynamicComponent Processor { get; set; }

        public HardwareDynamicComponent Memory { get; set; }

        public HardwareDynamicComponent Disk { get; set; }

        public HardwareDynamicComponent MainBoard { get; set; }

        public HardwareDynamicComponent VideoController { get; set; }
    }
}
