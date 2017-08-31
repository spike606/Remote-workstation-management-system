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
using SystemMonitor.SoftwareStatic.Builder;
using SystemMonitor.SoftwareStatic.Model;
using SystemMonitor.SoftwareStatic.Model.Components;

namespace SystemMonitor.DataBuilder
{
    internal class SystemMonitorDataBuilder : ISystemMonitorDataBuilder
    {
        public SystemMonitorDataBuilder(
                INLogger logger,
                IHardwareStaticBuilder hardwareStaticBuilder,
                IHardwareStaticAnalyzer hardwareStaticAnalyzer,
                IHardwareDynamicBuilder hardwareDynamicBuilder,
                ISoftwareStaticBuilder softwareStaticBuilder)
        {
            this.Logger = logger;
            this.HardwareStaticBuilder = hardwareStaticBuilder;
            this.HardwareStaticAnalyzer = hardwareStaticAnalyzer;
            this.HardwareDynamicBuilder = hardwareDynamicBuilder;
            this.SoftwareStaticBuilder = softwareStaticBuilder;
        }

        private INLogger Logger { get; set; }

        private IHardwareStaticBuilder HardwareStaticBuilder { get; set; }

        private IHardwareStaticAnalyzer HardwareStaticAnalyzer { get; set; }

        private IHardwareDynamicBuilder HardwareDynamicBuilder { get; set; }

        private ISoftwareStaticBuilder SoftwareStaticBuilder { get; set; }

        public HardwareDynamicData GetHardwareDynamicData()
        {
            HardwareDynamicData data = new HardwareDynamicData();
            data.Processor = this.HardwareDynamicBuilder.GetHardwareDynamicData(new ProcessorDynamic()).Cast<ProcessorDynamic>().ToList();
            data.Memory = this.HardwareDynamicBuilder.GetHardwareDynamicData(new MemoryDynamic()).Cast<MemoryDynamic>().ToList();
            data.Disk = this.HardwareDynamicBuilder.GetHardwareDynamicData(new DiskDynamic()).Cast<DiskDynamic>().ToList();
            data.MainBoard = this.HardwareDynamicBuilder.GetHardwareDynamicData(new MainBoardDynamic()).Cast<MainBoardDynamic>().ToList();
            data.VideoController = this.HardwareDynamicBuilder.GetHardwareDynamicData(new VideoControllerDynamic()).Cast<VideoControllerDynamic>().ToList();

            return data;
        }

        public HardwareStaticData GetHardwareStaticData()
        {
            HardwareStaticData data = new HardwareStaticData();
            data.Processor = this.HardwareStaticBuilder.GetHardwareStaticData(new ProcessorStatic()).Cast<ProcessorStatic>().ToList();
            data.ProcessorCache = this.HardwareStaticBuilder.GetHardwareStaticData(new ProcessorCache()).Cast<ProcessorCache>().ToList();
            data.Memory = this.HardwareStaticBuilder.GetHardwareStaticData(new Memory()).Cast<Memory>().ToList();
            data.Disk = this.HardwareStaticBuilder.GetHardwareStaticData(new Disk()).Cast<Disk>().ToList();
            data.CDROMDrive = this.HardwareStaticBuilder.GetHardwareStaticData(new CDROMDrive()).Cast<CDROMDrive>().ToList();
            data.BaseBoard = this.HardwareStaticBuilder.GetHardwareStaticData(new BaseBoard()).Cast<BaseBoard>().ToList();
            data.Fan = this.HardwareStaticBuilder.GetHardwareStaticData(new Fan()).Cast<Fan>().ToList();
            data.Battery = this.HardwareStaticBuilder.GetHardwareStaticData(new Battery()).Cast<Battery>().ToList();
            data.NetworkAdapter = this.HardwareStaticBuilder.GetHardwareStaticData(new NetworkAdapter()).Cast<NetworkAdapter>().ToList();
            data.Printer = this.HardwareStaticBuilder.GetHardwareStaticData(new Printer()).Cast<Printer>().ToList();
            data.VideoController = this.HardwareStaticBuilder.GetHardwareStaticData(new VideoController()).Cast<VideoController>().ToList();
            data.PnPEntity = this.HardwareStaticBuilder.GetHardwareStaticData(new PnPEntity()).Cast<PnPEntity>().ToList();
            data.Volume = this.HardwareStaticBuilder.GetHardwareStaticData(new Volume()).Cast<Volume>().ToList();
            data.DiskPartition = this.HardwareStaticBuilder.GetHardwareStaticData(new DiskPartition()).Cast<DiskPartition>().ToList();
            data.SmartFailurePredictData = this.HardwareStaticBuilder.GetHardwareStaticData(new SmartFailurePredictData()).Cast<SmartFailurePredictData>().ToList();
            data.SmartFailurePredictStatus = this.HardwareStaticBuilder.GetHardwareStaticData(new SmartFailurePredictStatus()).Cast<SmartFailurePredictStatus>().ToList();
            data.SmartFailurePredictThresholds = this.HardwareStaticBuilder.GetHardwareStaticData(new SmartFailurePredictThresholds()).Cast<SmartFailurePredictThresholds>().ToList();
            data.SMARTData = this.HardwareStaticAnalyzer.GetSmartData(
                data.SmartFailurePredictStatus,
                data.SmartFailurePredictData,
                data.SmartFailurePredictThresholds);

            data.DiskToPartition = this.HardwareStaticBuilder.GetHardwareStaticData(new DiskToPartition()).Cast<DiskToPartition>().ToList();
            data.PartitionToVolume = this.HardwareStaticBuilder.GetHardwareStaticData(new PartitionToVolume()).Cast<PartitionToVolume>().ToList();

            data.Storage = this.HardwareStaticAnalyzer.GetStorageData(
                data.Disk,
                data.DiskPartition,
                data.Volume,
                data.DiskToPartition,
                data.PartitionToVolume);
            return data;
        }

        public SoftwareStaticData GetSoftwareStaticData()
        {
            SoftwareStaticData data = new SoftwareStaticData();
            data.WindowsService = this.SoftwareStaticBuilder.GetSoftwareStaticData(new WindowsService()).Cast<WindowsService>().ToList();
            data.Bios = this.SoftwareStaticBuilder.GetSoftwareStaticData(new Bios()).Cast<Bios>().ToList();
            data.OperatingSystem = this.SoftwareStaticBuilder.GetSoftwareStaticData(new OS()).Cast<OS>().ToList();
            return data;
        }
    }
}
