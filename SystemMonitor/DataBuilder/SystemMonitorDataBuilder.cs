using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using SystemMonitor.HardwareStatic.Builder;
using SystemMonitor.HardwareStatic.Model;
using SystemMonitor.NLogger;

namespace SystemMonitor.DataBuilder
{
    internal class SystemMonitorDataBuilder : ISystemMonitorDataBuilder
    {
        public SystemMonitorDataBuilder(INLogger logger, IHardwareStaticBuilder hardwareStaticBuilder)
        {
            this.Logger = logger;
            this.HardwareStaticBuilder = hardwareStaticBuilder;
        }

        private INLogger Logger { get; set; }

        private IHardwareStaticBuilder HardwareStaticBuilder { get; set; }

        public HardwareStaticData GetHardwareStaticData()
        {
            HardwareStaticData data = new HardwareStaticData();
            data.Processor = this.HardwareStaticBuilder.GetProcessorStaticData();
            data.Memory = this.HardwareStaticBuilder.GetMemoryStaticData();
            data.DiskDrive = this.HardwareStaticBuilder.GetDiskDriveStaticData();
            return data;
        }
    }
}
