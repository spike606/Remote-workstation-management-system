using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareDynamic.Model.Components.Abstract;
using SystemMonitor.HardwareDynamic.OHMProvider;

namespace SystemMonitor.HardwareDynamic.Builder
{
    public class HardwareDynamicBuilder : IHardwareDynamicBuilder
    {
        public HardwareDynamicBuilder(IOHMProvider ohmProvider)
        {
            this.OhmMProvider = ohmProvider;
        }

        private IOHMProvider OhmMProvider { get; set; }

        public HardwareDynamicComponent GetHardwareDynamicData(HardwareDynamicComponent hardwareDynamicComponent)
        {
            return hardwareDynamicComponent.GetDynamicDataForHardwareComponent(this.OhmMProvider);
        }
    }
}
