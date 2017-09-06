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
using SystemMonitor.HardwareStatic.Model.Components.Interface;
using SystemMonitor.Shared.WMI;

namespace SystemMonitor.HardwareStatic.Builder
{
    internal class HardwareStaticBuilder : IHardwareStaticBuilder
    {
        public HardwareStaticBuilder(IWMIClient wmiClient)
        {
            this.WMIClient = wmiClient;
        }

        private IWMIClient WMIClient { get; set; }

        public List<T> GetHardwareStaticData<T>()
             where T : HardwareStaticComponent, IHardwareStaticComponent<T>, new()
        {
            T hardwareStaticComponent = new T();
            List<ManagementObject> managementObjectList = hardwareStaticComponent.GetManagementObjectsForHardwareComponent(this.WMIClient);
            return hardwareStaticComponent.ExtractData(managementObjectList);
        }
    }
}
