using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.CustomProperties;
using SystemMonitor.HardwareStatic.WMI;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class Processor
    {
        public UnitValue AddressWidth { get; set; }

        public string Architecture { get; set; }

        public string Caption { get; set; }

        public UnitValue DataWidth { get; set; }

        public string Description { get; set; }

        public UnitValue BusSpeed { get; set; }

        public List<CpuCacheMemory> Cache { get; set; } = new List<CpuCacheMemory>();

        public string Manufacturer { get; set; }

        public UnitValue MaxClockSpeed { get; set; }

        public string Name { get; set; }

        public string NumberOfCores { get; set; }

        public string NumberOfLogicalProcessors { get; set; }

        public string ProcessorID { get; set; }

        public string SerialNumber { get; set; }

        public string SocketDesignation { get; set; }

        public string Stepping { get; set; }

        public string ThreadCount { get; set; }

        public string UniqueId { get; set; }
    }
}
