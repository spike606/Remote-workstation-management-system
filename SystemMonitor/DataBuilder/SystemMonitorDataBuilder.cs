using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Builder;
using SystemMonitor.HardwareStatic.Model;

namespace SystemMonitor.DataBuilder
{
    internal class SystemMonitorDataBuilder
    {
        internal HardwareStaticData GetHardwareStaticData()
        {
            HardwareStaticData data = new HardwareStaticData();
            HardwareStaticBuilder builder = new HardwareStaticBuilder();
            data.Processor = builder.GetProcessorStaticData();
            return data;
        }
    }
}
