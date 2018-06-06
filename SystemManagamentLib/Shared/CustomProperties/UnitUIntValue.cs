using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagament.Monitor.HardwareStatic.Model.CustomProperties
{
    [DataContract]
    public struct UnitUIntValue
    {
        [DataMember]
        public string Unit;

        [DataMember]
        public uint? Value;

        public UnitUIntValue(string unit, uint? value = null)
        {
            this.Unit = unit;
            this.Value = value;
        }
    }
}
