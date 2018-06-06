using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagament.Monitor.HardwareStatic.Model.CustomProperties
{
    [DataContract]
    public struct UnitULongValue
    {
        [DataMember]
        public string Unit;

        [DataMember]
        public ulong? Value;

        public UnitULongValue(string unit, ulong? value = null)
        {
            this.Unit = unit;
            this.Value = value;
        }
    }
}
