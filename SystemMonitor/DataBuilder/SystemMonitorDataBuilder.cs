using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using SystemMonitor.HardwareDynamic.Builder;
using SystemMonitor.HardwareDynamic.Model;
using SystemMonitor.HardwareDynamic.Model.Components;
using SystemMonitor.HardwareStatic.Analyzer;
using SystemMonitor.HardwareStatic.Builder;
using SystemMonitor.HardwareStatic.Model;
using SystemMonitor.HardwareStatic.Model.Components;
using SystemMonitor.NLogger;

namespace SystemMonitor.DataBuilder
{
    internal class SystemMonitorDataBuilder : ISystemMonitorDataBuilder
    {
        public SystemMonitorDataBuilder(
                INLogger logger,
                IHardwareStaticBuilder hardwareStaticBuilder,
                IHardwareStaticAnalyzer hardwareStaticAnalyzer,
                IHardwareDynamicBuilder hardwareDynamicBuilder)
        {
            this.Logger = logger;
            this.HardwareStaticBuilder = hardwareStaticBuilder;
            this.HardwareStaticAnalyzer = hardwareStaticAnalyzer;
            this.HardwareDynamicBuilder = hardwareDynamicBuilder;
        }

        private INLogger Logger { get; set; }

        private IHardwareStaticBuilder HardwareStaticBuilder { get; set; }

        private IHardwareStaticAnalyzer HardwareStaticAnalyzer { get; set; }

        private IHardwareDynamicBuilder HardwareDynamicBuilder { get; set; }

        public HardwareDynamicData GetHardwareDynamicData()
        {
            HardwareDynamicData data = new HardwareDynamicData();
            data.Processor = this.HardwareDynamicBuilder.GetHardwareDynamicData(new ProcessorDynamic());
            data.Memory = this.HardwareDynamicBuilder.GetHardwareDynamicData(new MemoryDynamic());
            data.Disk = this.HardwareDynamicBuilder.GetHardwareDynamicData(new DiskDynamic());
            data.MainBoard = this.HardwareDynamicBuilder.GetHardwareDynamicData(new MainBoardDynamic());
            data.VideoController = this.HardwareDynamicBuilder.GetHardwareDynamicData(new VideoControllerDynamic());

            return data;
        }

        public HardwareStaticData GetHardwareStaticData()
        {
            HardwareStaticData data = new HardwareStaticData();
            data.Processor = this.HardwareStaticBuilder.GetHardwareStaticData(new ProcessorStatic());
            data.ProcessorCache = this.HardwareStaticBuilder.GetHardwareStaticData(new ProcessorCache());
            data.Memory = this.HardwareStaticBuilder.GetHardwareStaticData(new Memory());
            data.Disk = this.HardwareStaticBuilder.GetHardwareStaticData(new Disk());
            data.CDROMDrive = this.HardwareStaticBuilder.GetHardwareStaticData(new CDROMDrive());
            data.BaseBoard = this.HardwareStaticBuilder.GetHardwareStaticData(new BaseBoard());
            data.Fan = this.HardwareStaticBuilder.GetHardwareStaticData(new Fan());
            data.Battery = this.HardwareStaticBuilder.GetHardwareStaticData(new Battery());
            data.NetworkAdapter = this.HardwareStaticBuilder.GetHardwareStaticData(new NetworkAdapter());
            data.Printer = this.HardwareStaticBuilder.GetHardwareStaticData(new Printer());
            data.VideoController = this.HardwareStaticBuilder.GetHardwareStaticData(new VideoController());
            data.PnPEntity = this.HardwareStaticBuilder.GetHardwareStaticData(new PnPEntity());
            data.Volume = this.HardwareStaticBuilder.GetHardwareStaticData(new Volume());
            data.DiskPartition = this.HardwareStaticBuilder.GetHardwareStaticData(new DiskPartition());
            data.SmartFailurePredictData = this.HardwareStaticBuilder.GetHardwareStaticData(new SmartFailurePredictData());
            data.SmartFailurePredictStatus = this.HardwareStaticBuilder.GetHardwareStaticData(new SmartFailurePredictStatus());
            data.SmartFailurePredictThresholds = this.HardwareStaticBuilder.GetHardwareStaticData(new SmartFailurePredictThresholds());
            data.SMARTData = this.HardwareStaticAnalyzer.GetSmartData(
                data.SmartFailurePredictStatus,
                data.SmartFailurePredictData,
                data.SmartFailurePredictThresholds);

            data.DiskToPartition = this.HardwareStaticBuilder.GetHardwareStaticData(new DiskToPartition());
            data.PartitionToVolume = this.HardwareStaticBuilder.GetHardwareStaticData(new PartitionToVolume());

            data.Storage = this.HardwareStaticAnalyzer.GetStorageData(
                data.Disk,
                data.DiskPartition,
                data.Volume,
                data.DiskToPartition,
                data.PartitionToVolume);
            return data;
        }
    }
}
