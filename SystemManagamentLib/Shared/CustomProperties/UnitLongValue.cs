using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagament.Monitor.HardwareStatic.Model.CustomProperties
{
    [DataContract]
    public struct UnitLongValue
    {
        [DataMember]
        public string Unit;

        [DataMember]
        public long? Value;

        public UnitLongValue(string unit, long? value = null)
        {
            this.Unit = unit;
            this.Value = value;
        }
    }
}
