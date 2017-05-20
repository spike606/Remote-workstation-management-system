using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.Components;

namespace SystemMonitor.HardwareStatic.Builder
{
    public interface IHardwareStaticBuilder
    {
        Processor GetProcessorStaticData();

        List<Memory> GetMemoryStaticData();

        List<DiskDrive> GetDiskDriveStaticData();
    }
}
