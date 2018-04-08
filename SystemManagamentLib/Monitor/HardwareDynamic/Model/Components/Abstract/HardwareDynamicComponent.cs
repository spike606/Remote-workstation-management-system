using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.HardwareDynamic.Model.CustomProperties;

namespace SystemManagament.Monitor.HardwareDynamic.Model.Components.Abstract
{
    [DataContract]
    public abstract class HardwareDynamicComponent
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public List<Sensor> Clock { get; set; } = new List<Sensor>();

        [DataMember]
        public List<Sensor> Temperature { get; set; } = new List<Sensor>();

        [DataMember]
        public List<Sensor> Load { get; set; } = new List<Sensor>();

        [DataMember]
        public List<Sensor> Fan { get; set; } = new List<Sensor>();

        [DataMember]
        public List<Sensor> Control { get; set; } = new List<Sensor>();

        [DataMember]
        public List<Sensor> Voltage { get; set; } = new List<Sensor>();

        [DataMember]
        public List<Sensor> Data { get; set; } = new List<Sensor>();

        [DataMember]
        public List<Sensor> Power { get; set; } = new List<Sensor>();
    }
}
