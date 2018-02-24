using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagament.Monitor.HardwareDynamic.Model.CustomProperties
{
    public class Sensor
    {
        public string SensorType { get; set; }

        public string SensorName { get; set; }

        public string MinValue { get; set; }

        public string MaxValue { get; set; }

        public string Value { get; set; }

        public string Unit { get; set; }
    }
}
