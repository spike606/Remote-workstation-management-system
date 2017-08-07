using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareDynamic.Model.CustomProperties;
using SystemMonitor.HardwareDynamic.OHMProvider;

namespace SystemMonitor.HardwareDynamic.Model.Components.Abstract
{
    public abstract class HardwareDynamicComponent
    {
        public string Name { get; set; }

        public List<Sensor> Clock { get; set; } = new List<Sensor>();

        public List<Sensor> Temperature { get; set; } = new List<Sensor>();

        public List<Sensor> Load { get; set; } = new List<Sensor>();

        public List<Sensor> Fan { get; set; } = new List<Sensor>();

        public List<Sensor> Control { get; set; } = new List<Sensor>();

        public List<Sensor> Voltage { get; set; } = new List<Sensor>();

        public List<Sensor> Data { get; set; } = new List<Sensor>();

        public List<Sensor> Power { get; set; } = new List<Sensor>();

        public abstract HardwareDynamicComponent GetDynamicDataForHardwareComponent(IOHMProvider ohmProvider);
    }
}
