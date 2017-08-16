using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenHardwareMonitor.Hardware;
using SystemMonitor.HardwareDynamic.Model.Components.Abstract;
using SystemMonitor.HardwareDynamic.Model.CustomProperties;
using SystemMonitor.HardwareDynamic.Model.CustomProperties.Enum;
using SystemMonitor.HardwareDynamic.OHMProvider;

namespace SystemMonitor.HardwareDynamic.Model.Components
{
    public class DiskDynamic : HardwareDynamicComponent
    {
        public override List<HardwareDynamicComponent> GetDynamicDataForHardwareComponent(IOHMProvider ohmProvider)
        {
            return this.GetDynamicData(ohmProvider, new List<HardwareType>() { HardwareType.HDD }, new DiskDynamic());
        }

        public override HardwareDynamicComponent GetHardwareDynamicComponentInstance()
        {
            return new DiskDynamic();
        }
    }
}
