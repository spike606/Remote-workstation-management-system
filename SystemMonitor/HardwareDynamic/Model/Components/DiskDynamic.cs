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
        public override HardwareDynamicComponent GetDynamicDataForHardwareComponent(IOHMProvider ohmProvider)
        {
            DiskDynamic diskDynamic = new DiskDynamic();

            foreach (var hardwareItem in ohmProvider.Computer.Hardware)
            {
                if (hardwareItem.HardwareType == HardwareType.HDD)
                {
                    diskDynamic.Name = hardwareItem.Name;
                    hardwareItem.Update();
                    ohmProvider.ExtractDataFromSensors(diskDynamic, hardwareItem);
                }
            }

            return diskDynamic;
        }
    }
}
