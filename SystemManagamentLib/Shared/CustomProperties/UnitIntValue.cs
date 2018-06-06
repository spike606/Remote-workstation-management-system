using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagament.Monitor.HardwareStatic.Model.CustomProperties
{
    [DataContract]
    public struct UnitIntValue
    {
        [DataMember]
        public string Unit;

        [DataMember]
        public int? Value;

        public UnitIntValue(string unit, int? value = null)
        {
            this.Unit = unit;
            this.Value = value;
        }
    }
}
