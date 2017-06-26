using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using SystemMonitor.HardwareStatic.Analyzer;
using SystemMonitor.HardwareStatic.Builder;
using SystemMonitor.HardwareStatic.Model;
using SystemMonitor.HardwareStatic.Model.Components;
using SystemMonitor.NLogger;

namespace SystemMonitor.DataBuilder
{
    internal class SystemMonitorDataBuilder : ISystemMonitorDataBuilder
    {
        public SystemMonitorDataBuilder(INLogger logger, IHardwareStaticBuilder hardwareStaticBuilder, IHardwareStaticAnalyzer hardwareStaticAnalyzer)
        {
            this.Logger = logger;
            this.HardwareStaticBuilder = hardwareStaticBuilder;
            this.HardwareStaticAnalyzer = hardwareStaticAnalyzer;
        }

        private INLogger Logger { get; set; }

        private IHardwareStaticBuilder HardwareStaticBuilder { get; set; }

        private IHardwareStaticAnalyzer HardwareStaticAnalyzer { get; set; }

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
            data.SmartFailurePredictData = this.HardwareStaticBuilder.GetStaticData(new SmartFailurePredictData());
            data.SmartFailurePredictStatus = this.HardwareStaticBuilder.GetStaticData(new SmartFailurePredictStatus());
            data.SmartFailurePredictTresholds = this.HardwareStaticBuilder.GetStaticData(new SmartFailurePredictTresholds());
            data.SMARTData = this.HardwareStaticAnalyzer.GetSmartData(
                data.SmartFailurePredictStatus,
                data.SmartFailurePredictData,
                data.SmartFailurePredictTresholds);
            return data;
        }
    }
}
