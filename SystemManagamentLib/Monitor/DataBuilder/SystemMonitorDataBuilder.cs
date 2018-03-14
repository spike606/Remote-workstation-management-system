using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using SystemManagament.Logger;
using SystemManagament.Monitor.HardwareDynamic.Builder;
using SystemManagament.Monitor.HardwareDynamic.Model;
using SystemManagament.Monitor.HardwareDynamic.Model.Components;
using SystemManagament.Monitor.HardwareStatic.Analyzer;
using SystemManagament.Monitor.HardwareStatic.Builder;
using SystemManagament.Monitor.HardwareStatic.Model;
using SystemManagament.Monitor.HardwareStatic.Model.Components;
using SystemManagament.Monitor.SoftwareDynamic.Builder;
using SystemManagament.Monitor.SoftwareDynamic.Model;
using SystemManagament.Monitor.SoftwareDynamic.Model.Components;
using SystemManagament.Monitor.SoftwareStatic.Builder;
using SystemManagament.Monitor.SoftwareStatic.Model;
using SystemManagament.Monitor.SoftwareStatic.Model.Components;

namespace SystemManagament.Monitor.DataBuilder
{
    public class SystemMonitorDataBuilder : ISystemMonitorDataBuilder
    {
        public SystemMonitorDataBuilder(
                INLogger logger,
                IHardwareStaticBuilder hardwareStaticBuilder,
                IHardwareStaticAnalyzer hardwareStaticAnalyzer,
                IHardwareDynamicBuilder hardwareDynamicBuilder,
                ISoftwareStaticBuilder softwareStaticBuilder,
                ISoftwareDynamicBuilder softwareDynamicBuilder)
        {
            this.Logger = logger;
            this.HardwareStaticBuilder = hardwareStaticBuilder;
            this.HardwareStaticAnalyzer = hardwareStaticAnalyzer;
            this.HardwareDynamicBuilder = hardwareDynamicBuilder;
            this.SoftwareStaticBuilder = softwareStaticBuilder;
            this.SoftwareDynamicBuilder = softwareDynamicBuilder;
        }

        private INLogger Logger { get; set; }

        private IHardwareStaticBuilder HardwareStaticBuilder { get; set; }

        private IHardwareStaticAnalyzer HardwareStaticAnalyzer { get; set; }

        private IHardwareDynamicBuilder HardwareDynamicBuilder { get; set; }

        private ISoftwareStaticBuilder SoftwareStaticBuilder { get; set; }

        private ISoftwareDynamicBuilder SoftwareDynamicBuilder { get; set; }

        public HardwareDynamicData GetHardwareDynamicData()
        {
            HardwareDynamicData data = new HardwareDynamicData();
            data.Processor = this.HardwareDynamicBuilder.GetHardwareDynamicData<ProcessorDynamic>();
            data.Memory = this.HardwareDynamicBuilder.GetHardwareDynamicData<MemoryDynamic>();
            data.Disk = this.HardwareDynamicBuilder.GetHardwareDynamicData<DiskDynamic>();
            data.MainBoard = this.HardwareDynamicBuilder.GetHardwareDynamicData<MainBoardDynamic>();
            data.VideoController = this.HardwareDynamicBuilder.GetHardwareDynamicData<VideoControllerDynamic>();

            return data;
        }

        public HardwareStaticData GetHardwareStaticData()
        {
            HardwareStaticData data = new HardwareStaticData();
            data.Processor = this.HardwareStaticBuilder.GetHardwareStaticData<ProcessorStatic>();
            data.ProcessorCache = this.HardwareStaticBuilder.GetHardwareStaticData<ProcessorCache>();
            data.Memory = this.HardwareStaticBuilder.GetHardwareStaticData<Memory>();
            data.Disk = this.HardwareStaticBuilder.GetHardwareStaticData<Disk>();
            data.CDROMDrive = this.HardwareStaticBuilder.GetHardwareStaticData<CDROMDrive>();
            data.BaseBoard = this.HardwareStaticBuilder.GetHardwareStaticData<BaseBoard>();
            data.Fan = this.HardwareStaticBuilder.GetHardwareStaticData<Fan>();
            data.Battery = this.HardwareStaticBuilder.GetHardwareStaticData<Battery>();
            data.NetworkAdapter = this.HardwareStaticBuilder.GetHardwareStaticData<NetworkAdapter>();
            data.Printer = this.HardwareStaticBuilder.GetHardwareStaticData<Printer>();
            data.VideoController = this.HardwareStaticBuilder.GetHardwareStaticData<VideoController>();
            data.PnPEntity = this.HardwareStaticBuilder.GetHardwareStaticData<PnPEntity>();
            data.Volume = this.HardwareStaticBuilder.GetHardwareStaticData<Volume>();
            data.DiskPartition = this.HardwareStaticBuilder.GetHardwareStaticData<DiskPartition>();
            data.SmartFailurePredictData = this.HardwareStaticBuilder.GetHardwareStaticData<SmartFailurePredictData>();
            data.SmartFailurePredictStatus = this.HardwareStaticBuilder.GetHardwareStaticData<SmartFailurePredictStatus>();
            data.SmartFailurePredictThresholds = this.HardwareStaticBuilder.GetHardwareStaticData<SmartFailurePredictThresholds>();
            data.SMARTData = this.HardwareStaticAnalyzer.GetSmartData(
                data.SmartFailurePredictStatus,
                data.SmartFailurePredictData,
                data.SmartFailurePredictThresholds);

            data.DiskToPartition = this.HardwareStaticBuilder.GetHardwareStaticData<DiskToPartition>();
            data.PartitionToVolume = this.HardwareStaticBuilder.GetHardwareStaticData<PartitionToVolume>();

            data.Storage = this.HardwareStaticAnalyzer.GetStorageData(
                data.Disk,
                data.DiskPartition,
                data.Volume,
                data.DiskToPartition,
                data.PartitionToVolume);
            return data;
        }

        public SoftwareDynamicData GetSoftwareDynamicData()
        {
            SoftwareDynamicData data = new SoftwareDynamicData();
            data.WindowsService = this.SoftwareDynamicBuilder.GetSoftwareDynamicData<WindowsService>();
            data.WindowsLog = this.SoftwareDynamicBuilder.GetSoftwareDynamicData<WindowsLog>();
            data.WindowsProcess = this.SoftwareDynamicBuilder.GetSoftwareDynamicData<WindowsProcess>();

            return data;
        }

        public SoftwareStaticData GetSoftwareStaticData()
        {
            SoftwareStaticData data = new SoftwareStaticData();
            data.Bios = this.SoftwareStaticBuilder.GetSoftwareStaticData<Bios>();
            data.OperatingSystem = this.SoftwareStaticBuilder.GetSoftwareStaticData<OS>();
            data.InstalledProgram = this.SoftwareStaticBuilder.GetSoftwareStaticData<InstalledProgram>();
            data.StartupCommand = this.SoftwareStaticBuilder.GetSoftwareStaticData<StartupCommand>();
            data.MicrosoftWindowsUpdate = this.SoftwareStaticBuilder.GetSoftwareStaticData<MicrosoftWindowsUpdate>();
            data.LocalUser = this.SoftwareStaticBuilder.GetSoftwareStaticData<LocalUser>();
            data.CurrentUser = this.SoftwareStaticBuilder.GetSoftwareStaticData<CurrentUser>();
            return data;
        }
    }
}
