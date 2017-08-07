using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenHardwareMonitor.Hardware;
using SystemMonitor.HardwareDynamic.Model.Components;
using SystemMonitor.HardwareDynamic.Model.Components.Abstract;
using SystemMonitor.HardwareDynamic.Model.CustomProperties;
using SystemMonitor.HardwareDynamic.Model.CustomProperties.Enum;
using SystemMonitor.HardwareStatic.Model.CustomProperties.Attributes;

namespace SystemMonitor.HardwareDynamic.OHMProvider
{
    internal class OHMProvider : IOHMProvider
    {
        public OHMProvider()
        {
            this.Computer = new Computer();
            this.Computer.CPUEnabled = true;
            this.Computer.RAMEnabled = true;
            this.Computer.HDDEnabled = true;
            this.Computer.Open();
        }

        public Computer Computer { get;  private set; }

        public Sensor ExtractDataFromSpecificSensor(ISensor sensor, SensorUnit unit)
        {
            return new Sensor()
            {
                MaxValue = sensor.Max.HasValue ? sensor.Max.ToString() : "No value",
                MinValue = sensor.Min.HasValue ? sensor.Min.ToString() : "No value",
                SensorType = sensor.SensorType.ToString(),
                Value = sensor.Value.HasValue ? sensor.Value.ToString() : "No value",
                SensorName = sensor.Name,
                Unit = EnumExtensions.GetEnumDescription(unit)
            };
        }
    }
}
