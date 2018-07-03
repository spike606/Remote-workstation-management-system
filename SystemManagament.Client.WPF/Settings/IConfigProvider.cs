using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagament.Client.WPF.Settings
{
    public interface IConfigProvider
    {
        Dictionary<string, WorkstationSettings> WorkstationsParameters { get; set; }

        uint DelayBetweenCalls_HardwareDynamic { get; set; }

        uint DelayBetweenCalls_WindowsProcess { get; set; }

        uint DelayBetweenCalls_WindowsService { get; set; }

        void Save();

        void Load();
    }
}
