using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.SoftwareDynamic.Model.Components.Duplicate;

namespace SystemManagament.Monitor.SoftwareDynamic.Model.Components
{
    [DataContract]
    public class EventLogEntryDuplicate
    {
        [DataMember]
        public string MachineName { get; set; }

        [DataMember]
        public byte[] Data { get; set; }

        [DataMember]
        public int Index { get; set; }

        [DataMember]
        public string Category { get; set; }

        [DataMember]
        public short CategoryNumber { get; set; }

        [DataMember]
        public EventLogEntryTypeDuplicate EntryType { get; set; }

        [DataMember]
        public string Message { get; set; }

        [DataMember]
        public string Source { get; set; }

        [DataMember]
        public string[] ReplacementStrings { get; set; }

        [DataMember]
        public long InstanceId { get; set; }

        [DataMember]
        public DateTime TimeGenerated { get; set; }

        [DataMember]
        public DateTime TimeWritten { get; set; }

        [DataMember]
        public string UserName { get; set; }
    }
}