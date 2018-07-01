using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Client.WPF.ViewModel;

namespace SystemManagament.Client.WPF.Settings
{
    public class ConfigProvider : IConfigProvider
    {
        public string TestSetting { get; set; }

        public Dictionary<string, WorkstationSettings> WorkstationsParameters { get; set; }

        public void Load()
        {
            AppSettings settings = ViewModelLocator.Instance;

            this.TestSetting = settings.TestSetting;

            if (settings.WorkstationsParameters == null)
            {
                settings.WorkstationsParameters = new Dictionary<string, WorkstationSettings>();
                settings.Save();
                settings.Reload();
            }

            this.WorkstationsParameters = settings.WorkstationsParameters;
        }

        public void Save()
        {
            AppSettings settings = ViewModelLocator.Instance;

            settings.TestSetting = this.TestSetting;
            settings.WorkstationsParameters = this.WorkstationsParameters;
            settings.Save();
            settings.Reload();
        }
    }
}
