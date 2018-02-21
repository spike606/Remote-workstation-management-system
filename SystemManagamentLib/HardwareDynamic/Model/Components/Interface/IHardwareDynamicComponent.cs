using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenHardwareMonitor.Hardware;
using SystemMonitor.HardwareDynamic.Model.Components.Abstract;
using SystemMonitor.HardwareDynamic.Model.CustomProperties;
using SystemMonitor.HardwareDynamic.OHMProvider;

namespace SystemMonitor.HardwareDynamic.Model.Components.Interface
{
    public interface IHardwareDynamicComponent
    {
        List<T> GetDynamicDataForHardwareComponent<T>(IOHMProvider ohmProvider)
            where T : HardwareDynamicComponent, IHardwareDynamicComponent, new();
    }
}
