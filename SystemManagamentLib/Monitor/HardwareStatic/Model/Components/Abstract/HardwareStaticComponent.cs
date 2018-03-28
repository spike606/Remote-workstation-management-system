using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagament.Monitor.HardwareStatic.Model.Components.Abstract
{
    [DataContract]
    public abstract class HardwareStaticComponent
    {
        [DataMember]
        public string Caption { get; protected set; }

        [DataMember]
        public string Name { get; protected set; }

        [DataMember]
        public string Description { get; protected set; }

        [DataMember]
        public string Status { get; protected set; }
    }
}
