using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemManagament.Client.WPF.Settings
{
    public class AppSettings : ApplicationSettingsBase
    {
        [UserScopedSetting]
        [SettingsSerializeAs(SettingsSerializeAs.Binary)]
        public Dictionary<string, WorkstationSettings> WorkstationsParameters
        {
            get
            {
                return (Dictionary<string, WorkstationSettings>)this["WorkstationsParameters"];
            }

            set
            {
                this["WorkstationsParameters"] = value;
            }
        }

        [UserScopedSetting]
        [SettingsSerializeAs(SettingsSerializeAs.Binary)]
        public string DelayBetweenCalls_HardwareDynamic
        {
            get
            {
                return (string)this["DelayBetweenCalls_HardwareDynamic"];
            }

            set
            {
                this["DelayBetweenCalls_HardwareDynamic"] = value;
            }
        }

        [UserScopedSetting]
        [SettingsSerializeAs(SettingsSerializeAs.Binary)]
        public string DelayBetweenCalls_WindowsService
        {
            get
            {
                return (string)this["DelayBetweenCalls_WindowsService"];
            }

            set
            {
                this["DelayBetweenCalls_WindowsService"] = value;
            }
        }

        [UserScopedSetting]
        [SettingsSerializeAs(SettingsSerializeAs.Binary)]
        public string DelayBetweenCalls_WindowsProcess
        {
            get
            {
                return (string)this["DelayBetweenCalls_WindowsProcess"];
            }

            set
            {
                this["DelayBetweenCalls_WindowsProcess"] = value;
            }
        }
    }
}
