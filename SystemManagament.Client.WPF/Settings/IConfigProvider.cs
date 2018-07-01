using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagament.Client.WPF.Settings
{
    public interface IConfigProvider
    {
        string TestSetting { get; set; }

        Dictionary<string, WorkstationSettings> WorkstationsParameters { get; set; }

        void Save();

        void Load();
    }
}
