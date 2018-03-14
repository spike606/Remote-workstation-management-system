using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagament.Monitor.HardwareStatic.Model.CustomProperties
{
    [DataContract]
    public struct UnitValue
    {
        [DataMember]
        public string Unit;

        [DataMember]
        public string Value;

        public UnitValue(string unit, string value = "")
        {
            this.Unit = unit;
            this.Value = value;
        }
    }
}
