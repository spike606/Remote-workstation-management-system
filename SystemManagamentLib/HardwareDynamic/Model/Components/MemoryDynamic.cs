using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenHardwareMonitor.Hardware;
using SystemMonitor.HardwareDynamic.Model.Components.Abstract;
using SystemMonitor.HardwareDynamic.Model.Components.Interface;
using SystemMonitor.HardwareDynamic.Model.CustomProperties;
using SystemMonitor.HardwareDynamic.Model.CustomProperties.Enum;
using SystemMonitor.HardwareDynamic.OHMProvider;

namespace SystemMonitor.HardwareDynamic.Model.Components
{
    public class MemoryDynamic : HardwareDynamicComponent, IHardwareDynamicComponent
    {
        public List<T> GetDynamicDataForHardwareComponent<T>(IOHMProvider ohmProvider)
            where T : HardwareDynamicComponent, IHardwareDynamicComponent, new()
        {
            List<T> hardwareDynamicComponentList = new List<T>();

            ohmProvider.GetDynamicData(hardwareDynamicComponentList, new List<HardwareType>() { HardwareType.RAM });

            return hardwareDynamicComponentList;
        }
    }
}
