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

namespace SystemMonitor.HardwareDynamic.OHMProvider
{
    public interface IOHMProvider
    {
        Computer Computer { get; }

        void GetDynamicData<T>(
            List<T> hardwareDynamicComponentList,
            IEnumerable<HardwareType> hardwareType)
            where T : HardwareDynamicComponent, IHardwareDynamicComponent, new();
    }
}
