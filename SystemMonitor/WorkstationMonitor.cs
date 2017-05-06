using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.DataBuilder;
using SystemMonitor.HardwareStatic.Model;

namespace HardwareMonitor
{
    public class WorkstationMonitor
    {
        // TODO: IoC
        public HardwareStaticData GetHardwareStaticData()
        {
            SystemMonitorDataBuilder builder = new SystemMonitorDataBuilder();
            return builder.GetHardwareStaticData();
        }
    }
}
