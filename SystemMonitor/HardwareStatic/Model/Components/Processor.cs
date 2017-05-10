using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.CustomProperties;

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

        public UnitValue L1CacheSize { get; set; }

        public UnitValue L1CacheSpeed { get; set; }

        public UnitValue L2CacheSize { get; set; }

        public UnitValue L2CacheSpeed { get; set; }

        public UnitValue L3CacheSize { get; set; }

        public UnitValue L3CacheSpeed { get; set; }

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
