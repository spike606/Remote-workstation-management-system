using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagament.Monitor.SoftwareStatic.Model.Components.Duplicate
{
    [DataContract]
    public class ClaimDuplicate
    {
        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public IDictionary<string, string> Properties { get; set; }

        [DataMember]
        public string OriginalIssuer { get; set; }

        [DataMember]
        public string Issuer { get; set; }

        [DataMember]
        public string ValueType { get; set; }

        [DataMember]
        public string Value { get; set; }
    }
}
