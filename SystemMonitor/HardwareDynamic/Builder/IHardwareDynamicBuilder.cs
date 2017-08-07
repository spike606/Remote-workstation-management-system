using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareDynamic.Model.Components.Abstract;

namespace SystemMonitor.HardwareDynamic.Builder
{
    public interface IHardwareDynamicBuilder
    {
        HardwareDynamicComponent GetHardwareDynamicData(HardwareDynamicComponent hardwareDynamicComponent);
    }
}
