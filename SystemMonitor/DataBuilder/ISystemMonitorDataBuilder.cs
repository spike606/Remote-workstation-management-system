using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model;

namespace SystemMonitor.DataBuilder
{
    public interface ISystemMonitorDataBuilder
    {
        HardwareStaticData GetHardwareStaticData();
    }
}
