﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using OpenHardwareMonitor.Hardware;
using SystemManagament.Monitor.HardwareDynamic.Model.Components.Abstract;
using SystemManagament.Monitor.HardwareDynamic.Model.Components.Interface;
using SystemManagament.Monitor.HardwareDynamic.OHMProvider;

namespace SystemManagament.Monitor.HardwareDynamic.Model.Components
{
    [DataContract]
    public class MemoryDynamic : HardwareDynamicComponent, IHardwareDynamicComponent
    {
        public List<T> GetDynamicDataForHardwareComponent<T>(IOHMProvider ohmProvider)
            where T : HardwareDynamicComponent, IHardwareDynamicComponent, new()
        {
            List<T> hardwareDynamicComponentList = new List<T>();

            ohmProvider.GetDynamicData(hardwareDynamicComponentList, new List<HardwareType>() { HardwareType.RAM });

            return hardwareDynamicComponentList;
        }
    }
}
