using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareDynamic.Model;
using SystemMonitor.HardwareStatic.Model;
using SystemMonitor.SoftwareStatic.Model;

namespace SystemMonitor.DataBuilder
{
    public interface ISystemMonitorDataBuilder
    {
        HardwareStaticData GetHardwareStaticData();

        HardwareDynamicData GetHardwareDynamicData();

        SoftwareStaticData GetSoftwareStaticData();
    }
}
