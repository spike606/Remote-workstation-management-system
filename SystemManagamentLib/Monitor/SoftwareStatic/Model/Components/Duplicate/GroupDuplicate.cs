using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagament.Monitor.SoftwareStatic.Model.Components.Duplicate
{
    [DataContract]
    public class GroupDuplicate
    {
        [DataMember]
        public string Value { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}
