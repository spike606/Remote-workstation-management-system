using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model;
using SystemMonitor.HardwareStatic.Model.Components;
using SystemMonitor.HardwareStatic.Model.Components.Abstract;
using SystemMonitor.HardwareStatic.Model.Components.Interface;

namespace SystemMonitor.HardwareStatic.Builder
{
    public interface IHardwareStaticBuilder
    {
        List<T> GetHardwareStaticData<T>()
            where T : HardwareStaticComponent, IHardwareStaticComponent<T>, new();
    }
}
