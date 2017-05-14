using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.CustomProperties;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class Memory
    {
        public string BankLabel { get; set; }

        public UnitValue Capacity { get; set; }

        public string Caption { get; set; }

        public UnitValue ConfiguredClockSpeed { get; set; }

        public UnitValue ConfiguredVoltage { get; set; }

        public UnitValue DataWidth { get; set; }

        public string Description { get; set; }

        public string DeviceLocator { get; set; }

        public string Manufacturer { get; set; }

        public UnitValue MaxVoltage { get; set; }

        public string MemoryType { get; set; }

        public UnitValue MinVoltage { get; set; }

        public string Name { get; set; }

        public string PartNumber { get; set; }

        public string SerialNumber { get; set; }

        public UnitValue TotalWidth { get; set; }
    }
}
