using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareDynamic.Model.Components.Abstract;
using SystemMonitor.HardwareDynamic.Model.Components.Interface;

namespace SystemMonitor.HardwareDynamic.Builder
{
    public interface IHardwareDynamicBuilder
    {
        List<T> GetHardwareDynamicData<T>()
            where T : HardwareDynamicComponent, IHardwareDynamicComponent, new();
    }
}
