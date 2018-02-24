using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenHardwareMonitor.Hardware;
using SystemManagament.Monitor.HardwareDynamic.Model.Components.Abstract;
using SystemManagament.Monitor.HardwareDynamic.Model.Components.Interface;

namespace SystemManagament.Monitor.HardwareDynamic.OHMProvider
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
