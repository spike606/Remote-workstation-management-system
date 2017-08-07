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
    public class DiskDynamic : HardwareDynamicComponent
    {
        public List<Sensor> Temperature { get; set; } = new List<Sensor>();

        public List<Sensor> Load { get; set; } = new List<Sensor>();

        public override HardwareDynamicComponent GetDynamicDataForHardwareComponent(IOHMProvider ohmProvider)
        {
            DiskDynamic diskDynamic = new DiskDynamic();

            foreach (var hardwareItem in ohmProvider.Computer.Hardware)
            {
                if (hardwareItem.HardwareType == HardwareType.HDD)
                {
                    diskDynamic.Name = hardwareItem.Name;
                    hardwareItem.Update();
                    foreach (var sensor in hardwareItem.Sensors)
                    {
                        switch (sensor.SensorType)
                        {
                            case SensorType.Load:
                                diskDynamic.Load.Add(ohmProvider.ExtractDataFromSpecificSensor(sensor, SensorUnit.Percentage));
                                break;
                            case SensorType.Temperature:
                                diskDynamic.Temperature.Add(ohmProvider.ExtractDataFromSpecificSensor(sensor, SensorUnit.Celcius));
                                break;
                            default:
                                break;
                        }
                    }
                }
            }

            return diskDynamic;
        }
    }
}
