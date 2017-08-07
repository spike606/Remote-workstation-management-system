using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareDynamic.Model.CustomProperties;
using SystemMonitor.HardwareDynamic.OHMProvider;

namespace SystemMonitor.HardwareDynamic.Model.Components.Abstract
{
    public abstract class HardwareDynamicComponent
    {
        public string Name { get; set; }

        public abstract HardwareDynamicComponent GetDynamicDataForHardwareComponent(IOHMProvider ohmProvider);
    }
}
