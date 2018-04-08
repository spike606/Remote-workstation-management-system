using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagament.Monitor.SoftwareDynamic.Model.Components.Duplicate
{
    public enum EventLogEntryTypeDuplicate
    {
        Unknown = 0,
        Error = 1,
        Warning = 2,
        Information = 4,
        SuccessAudit = 8,
        FailureAudit = 16
    }
}
