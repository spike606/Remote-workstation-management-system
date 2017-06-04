using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model;
using SystemMonitor.HardwareStatic.Model.Components;
using SystemMonitor.HardwareStatic.Model.Components.Abstract;
using SystemMonitor.HardwareStatic.WMI;

namespace SystemMonitor.HardwareStatic.Builder
{
    internal class HardwareStaticBuilder : IHardwareStaticBuilder
    {
        public HardwareStaticBuilder(IWMIClient wmiClient)
        {
            this.WMIClient = wmiClient;
        }

        private IWMIClient WMIClient { get; set; }

        public List<HardwareComponent> GetStaticData(HardwareComponent hardwareComponent)
        {
            List<ManagementObject> managementObjectList = hardwareComponent.GetManagementObjectsForHardwareComponent(this.WMIClient);
            List<HardwareComponent> staticData = new List<HardwareComponent>();

            foreach (var managementObject in managementObjectList)
            {
                staticData.Add(hardwareComponent.ExtractData(managementObject));
            }

            return staticData;
        }
    }
}
