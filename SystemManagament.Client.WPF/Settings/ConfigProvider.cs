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
        public Dictionary<string, WorkstationSettings> WorkstationsParameters { get; set; }

        public uint DelayBetweenCalls_HardwareDynamic { get; set; }

        public uint DelayBetweenCalls_WindowsProcess { get; set; }

        public uint DelayBetweenCalls_WindowsService { get; set; }

        public void Load()
        {
            AppSettings settings = ViewModelLocator.Instance;

            if (settings.WorkstationsParameters == null)
            {
                settings.WorkstationsParameters = new Dictionary<string, WorkstationSettings>();
                settings.Save();
                settings.Reload();
            }

            if (settings.DelayBetweenCalls_HardwareDynamic == null)
            {
                settings.DelayBetweenCalls_HardwareDynamic = "3";
                settings.Save();
                settings.Reload();
            }

            if (settings.DelayBetweenCalls_WindowsProcess == null)
            {
                settings.DelayBetweenCalls_WindowsProcess = "3";
                settings.Save();
                settings.Reload();
            }

            if (settings.DelayBetweenCalls_WindowsService == null)
            {
                settings.DelayBetweenCalls_WindowsService = "3";
                settings.Save();
                settings.Reload();
            }

            this.WorkstationsParameters = settings.WorkstationsParameters;
            this.DelayBetweenCalls_HardwareDynamic = uint.Parse(settings.DelayBetweenCalls_HardwareDynamic);
            this.DelayBetweenCalls_WindowsProcess = uint.Parse(settings.DelayBetweenCalls_WindowsProcess);
            this.DelayBetweenCalls_WindowsService = uint.Parse(settings.DelayBetweenCalls_WindowsService);
        }

        public void Save()
        {
            AppSettings settings = ViewModelLocator.Instance;

            settings.WorkstationsParameters = this.WorkstationsParameters;
            settings.DelayBetweenCalls_HardwareDynamic = this.DelayBetweenCalls_HardwareDynamic.ToString();
            settings.DelayBetweenCalls_WindowsProcess = this.DelayBetweenCalls_WindowsProcess.ToString();
            settings.DelayBetweenCalls_WindowsService = this.DelayBetweenCalls_WindowsService.ToString();
            settings.Save();
            settings.Reload();
        }
    }
}
