using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using SystemMonitor.HardwareStatic.Builder;
using SystemMonitor.HardwareStatic.Model;
using SystemMonitor.HardwareStatic.Model.Components;
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
            data.Processor = this.HardwareStaticBuilder.GetStaticData(new Processor());
            data.ProcessorCache = this.HardwareStaticBuilder.GetStaticData(new ProcessorCache());
            data.Memory = this.HardwareStaticBuilder.GetStaticData(new Memory());
            data.Disk = this.HardwareStaticBuilder.GetStaticData(new Disk());
            data.CDROMDrive = this.HardwareStaticBuilder.GetStaticData(new CDROMDrive());
            data.BaseBoard = this.HardwareStaticBuilder.GetStaticData(new BaseBoard());
            data.Fan = this.HardwareStaticBuilder.GetStaticData(new Fan());
            data.Battery = this.HardwareStaticBuilder.GetStaticData(new Battery());
            data.NetworkAdapter = this.HardwareStaticBuilder.GetStaticData(new NetworkAdapter());
            data.Printer = this.HardwareStaticBuilder.GetStaticData(new Printer());
            data.VideoController = this.HardwareStaticBuilder.GetStaticData(new VideoController());
            data.PnPEntity = this.HardwareStaticBuilder.GetStaticData(new PnPEntity());
            data.Volume = this.HardwareStaticBuilder.GetStaticData(new Volume());
            data.DiskPartition = this.HardwareStaticBuilder.GetStaticData(new DiskPartition());
            return data;
        }
    }
}
