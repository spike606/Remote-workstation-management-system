using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagament.Client.WPF.ViewModel.Messages
{
    public class UpdateMachineMessage
    {
        public string MachineIdentifier { get; set; }

        public string MachineName { get; set; }

        public string MachineUri { get; set; }
    }
}
