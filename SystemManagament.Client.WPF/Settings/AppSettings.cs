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

        [UserScopedSetting()]
        [DefaultSettingValue("white")]
        public string TestSetting
        {
            get
            {
                return (string)this["TestSetting"];
            }

            set
            {
                this["TestSetting"] = value;
            }
        }
    }
}
