using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagament.Monitor.HardwareStatic.Model.CustomProperties
{
    [DataContract]
    public struct UnitUShortValue
    {
        [DataMember]
        public string Unit;

        [DataMember]
        public ushort? Value;

        public UnitUShortValue(string unit, ushort? value = null)
        {
            this.Unit = unit;
            this.Value = value;
        }
    }
}
