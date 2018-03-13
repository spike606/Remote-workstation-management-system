using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.SoftwareDynamic.Model.Components;

namespace SystemManagament.Monitor.SoftwareDynamic.Model
{
    [DataContract]
    public class SoftwareDynamicData
    {
        [DataMember]
        public List<WindowsService> WindowsService { get; set; }

        [DataMember]
        public List<WindowsLog> WindowsLog { get; set; }

        [DataMember]
        public List<WindowsProcess> WindowsProcess { get; set; }
    }
}
