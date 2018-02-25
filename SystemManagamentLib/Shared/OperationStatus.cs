using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagament.Shared
{
    public class OperationStatus
    {
        public OperationStatus(bool isSucceded, string message)
        {
            this.IsSucceded = isSucceded;
            this.Message = message;
        }

        public bool IsSucceded { get; set; }

        public string Message { get; set; }
    }
}
