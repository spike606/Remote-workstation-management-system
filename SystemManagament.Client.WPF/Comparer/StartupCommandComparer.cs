using System.Collections.Generic;
using SystemManagament.Client.WPF.WorkstationMonitorService;

namespace SystemManagament.Client.WPF.Comparer
{
    public class StartupCommandComparer : IEqualityComparer<StartupCommand>
    {
        public bool Equals(StartupCommand x, StartupCommand y)
        {
            return x.Caption == y.Caption
                && x.Command == y.Command
                && x.Name == y.Name
                && x.Description == y.Description
                && x.Location == y.Location
                && x.SettingID == y.SettingID
                && x.User == y.User
                && x.UserSID == y.UserSID;
        }

        public int GetHashCode(StartupCommand obj)
        {
            return obj.GetHashCode();
        }
    }
}