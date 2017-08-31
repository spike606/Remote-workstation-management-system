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
            this.Computer.GPUEnabled = true;
            this.Computer.MainboardEnabled = true;
            this.Computer.Open();
        }

        public Computer Computer { get; private set; }

        public void ExtractDataFromSensors(HardwareDynamicComponent hardwareDynamicComponent, IHardware hardwareItem)
        {
            foreach (var sensor in hardwareItem.Sensors)
            {
                switch (sensor.SensorType)
                {
                    case SensorType.Clock:
                        hardwareDynamicComponent.Clock.Add(this.ExtractDataFromSpecificSensor(sensor, SensorUnit.MHZ));
                        break;
                    case SensorType.Data:
                        hardwareDynamicComponent.Data.Add(this.ExtractDataFromSpecificSensor(sensor, SensorUnit.GigaByte));
                        break;
                    case SensorType.Temperature:
                        hardwareDynamicComponent.Temperature.Add(this.ExtractDataFromSpecificSensor(sensor, SensorUnit.Celcius));
                        break;
                    case SensorType.Load:
                        hardwareDynamicComponent.Load.Add(this.ExtractDataFromSpecificSensor(sensor, SensorUnit.Percentage));
                        break;
                    case SensorType.Fan:
                        hardwareDynamicComponent.Fan.Add(this.ExtractDataFromSpecificSensor(sensor, SensorUnit.RPM));
                        break;
                    case SensorType.Control:
                        hardwareDynamicComponent.Control.Add(this.ExtractDataFromSpecificSensor(sensor, SensorUnit.Percentage));
                        break;
                    case SensorType.Voltage:
                        hardwareDynamicComponent.Voltage.Add(this.ExtractDataFromSpecificSensor(sensor, SensorUnit.Volt));
                        break;
                    case SensorType.Power:
                        hardwareDynamicComponent.Power.Add(this.ExtractDataFromSpecificSensor(sensor, SensorUnit.Watt));
                        break;
                    default:
                        break;
                }
            }
        }

        private Sensor ExtractDataFromSpecificSensor(ISensor sensor, SensorUnit unit)
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
