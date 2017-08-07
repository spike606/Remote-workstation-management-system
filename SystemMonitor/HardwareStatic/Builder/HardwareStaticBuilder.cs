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

        public List<HardwareStaticComponent> GetHardwareStaticData(HardwareStaticComponent hardwareStaticComponent)
        {
            List<ManagementObject> managementObjectList = hardwareStaticComponent.GetManagementObjectsForHardwareComponent(this.WMIClient);
            List<HardwareStaticComponent> staticData = new List<HardwareStaticComponent>();

            foreach (var managementObject in managementObjectList)
            {
                staticData.Add(hardwareStaticComponent.ExtractData(managementObject));
            }

            return staticData;
        }
    }
}
