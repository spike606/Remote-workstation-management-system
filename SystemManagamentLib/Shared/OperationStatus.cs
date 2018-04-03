using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagament.Shared
{
    [DataContract]
    public class OperationStatus
    {
        public OperationStatus(bool isSucceded, string message)
        {
            this.IsSucceded = isSucceded;
            this.Message = message;
        }

        [DataMember]
        public bool IsSucceded { get; set; }

        [DataMember]
        public string Message { get; set; }
    }
}
