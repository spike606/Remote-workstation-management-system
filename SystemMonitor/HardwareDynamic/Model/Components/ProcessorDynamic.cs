using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenHardwareMonitor.Hardware;
using SystemMonitor.HardwareDynamic.Model.Components.Abstract;
using SystemMonitor.HardwareDynamic.Model.CustomProperties;
using SystemMonitor.HardwareDynamic.Model.CustomProperties.Enum;
using SystemMonitor.HardwareDynamic.OHMProvider;

namespace SystemMonitor.HardwareDynamic.Model.Components
{
    public class ProcessorDynamic : HardwareDynamicComponent
    {
        public List<Sensor> Clock { get; set; } = new List<Sensor>();

        public List<Sensor> Temperature { get; set; } = new List<Sensor>();

        public List<Sensor> Load { get; set; } = new List<Sensor>();

        public List<Sensor> Power { get; set; } = new List<Sensor>();

        public override HardwareDynamicComponent GetDynamicDataForHardwareComponent(IOHMProvider ohmProvider)
        {
            ProcessorDynamic processorDynamic = new ProcessorDynamic();

            foreach (var hardwareItem in ohmProvider.Computer.Hardware)
            {
                if (hardwareItem.HardwareType == HardwareType.CPU)
                {
                    processorDynamic.Name = hardwareItem.Name;
                    hardwareItem.Update();
                    foreach (var sensor in hardwareItem.Sensors)
                    {
                        switch (sensor.SensorType)
                        {
                            case SensorType.Clock:
                                processorDynamic.Clock.Add(ohmProvider.ExtractDataFromSpecificSensor(sensor, SensorUnit.MHZ));
                                break;
                            case SensorType.Temperature:
                                processorDynamic.Temperature.Add(ohmProvider.ExtractDataFromSpecificSensor(sensor, SensorUnit.Celcius));
                                break;
                            case SensorType.Load:
                                processorDynamic.Load.Add(ohmProvider.ExtractDataFromSpecificSensor(sensor, SensorUnit.Percentage));
                                break;
                            case SensorType.Power:
                                processorDynamic.Power.Add(ohmProvider.ExtractDataFromSpecificSensor(sensor, SensorUnit.Watt));
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            return processorDynamic;
        }
    }
}
