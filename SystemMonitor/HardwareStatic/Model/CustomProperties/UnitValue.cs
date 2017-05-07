using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMonitor.HardwareStatic.Model.CustomProperties
{
    public struct UnitValue
    {
        public string Unit;

        public string Value;

        public UnitValue(string unit, string value)
        {
            this.Unit = unit;
            this.Value = value;
        }
    }
}
