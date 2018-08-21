using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagament.Client.WPF.ViewModel.Messages
{
    public class UpdatePreferencesMessage
    {
        public uint DelayBetweenCalls_WindowsProcess { get; set; }

        public uint DelayBetweenCalls_WindowsService { get; set; }

        public uint DelayBetweenCalls_HardwareDynamic { get; set; }

        public bool DynamicHardwareLogs_Include { get; set; }

        public string DynamicHardwareLogs_Path { get; set; }
    }
}
