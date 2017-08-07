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
    public class MemoryDynamic : HardwareDynamicComponent
    {
        public List<Sensor> Load { get; set; } = new List<Sensor>();

        public List<Sensor> Data { get; set; } = new List<Sensor>();

        public override HardwareDynamicComponent GetDynamicDataForHardwareComponent(IOHMProvider ohmProvider)
        {
            MemoryDynamic memoryDynamic = new MemoryDynamic();

            foreach (var hardwareItem in ohmProvider.Computer.Hardware)
            {
                if (hardwareItem.HardwareType == HardwareType.RAM)
                {
                    memoryDynamic.Name = hardwareItem.Name;
                    hardwareItem.Update();
                    foreach (var sensor in hardwareItem.Sensors)
                    {
                        switch (sensor.SensorType)
                        {
                            case SensorType.Load:
                                memoryDynamic.Load.Add(ohmProvider.ExtractDataFromSpecificSensor(sensor, SensorUnit.Percentage));
                                break;
                            case SensorType.Data:
                                memoryDynamic.Data.Add(ohmProvider.ExtractDataFromSpecificSensor(sensor, SensorUnit.GigaByte));
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            return memoryDynamic;
        }
    }
}
