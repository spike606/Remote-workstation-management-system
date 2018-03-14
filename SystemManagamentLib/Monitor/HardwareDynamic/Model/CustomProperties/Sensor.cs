using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagament.Monitor.HardwareDynamic.Model.CustomProperties
{
    [DataContract]
    public class Sensor
    {
        [DataMember]
        public string SensorType { get; set; }

        [DataMember]
        public string SensorName { get; set; }

        [DataMember]
        public string MinValue { get; set; }

        [DataMember]
        public string MaxValue { get; set; }

        [DataMember]
        public string Value { get; set; }

        [DataMember]
        public string Unit { get; set; }
    }
}
