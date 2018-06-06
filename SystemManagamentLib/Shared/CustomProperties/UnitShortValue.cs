using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagament.Monitor.HardwareStatic.Model.CustomProperties
{
    [DataContract]
    public struct UnitShortValue
    {
        [DataMember]
        public string Unit;

        [DataMember]
        public short? Value;

        public UnitShortValue(string unit, short? value = null)
        {
            this.Unit = unit;
            this.Value = value;
        }
    }
}
