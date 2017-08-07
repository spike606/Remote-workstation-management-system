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
    public class MainBoardDynamic : HardwareDynamicComponent
    {
        public override HardwareDynamicComponent GetDynamicDataForHardwareComponent(IOHMProvider ohmProvider)
        {
            MainBoardDynamic mainBoardDynamic = new MainBoardDynamic();

            foreach (var hardwareItem in ohmProvider.Computer.Hardware)
            {
                if (hardwareItem.HardwareType == HardwareType.Mainboard)
                {
                    mainBoardDynamic.Name = hardwareItem.Name;
                    hardwareItem.Update();
                    ohmProvider.ExtractDataFromSensors(mainBoardDynamic, hardwareItem);
                }
            }

            return mainBoardDynamic;
        }
    }
}
