using System.Collections.Generic;
using SystemManagament.Client.WPF.WorkstationMonitorService;

namespace SystemManagament.Client.WPF.Comparer
{
    public class MicrosoftWindowsUpdateComparer : IEqualityComparer<MicrosoftWindowsUpdate>
    {
        public bool Equals(MicrosoftWindowsUpdate x, MicrosoftWindowsUpdate y)
        {
            return x.Caption == y.Caption
                && x.CSName == y.CSName
                && x.Name == y.Name
                && x.Description == y.Description
                && x.FixComments == y.FixComments
                && x.HotFixID == y.HotFixID
                && x.InstallDate == y.InstallDate
                && x.InstalledBy == y.InstalledBy
                && x.InstalledOn == y.InstalledOn
                && x.ServicePackInEffect == y.ServicePackInEffect
                && x.Status == y.Status;
        }

        public int GetHashCode(MicrosoftWindowsUpdate obj)
        {
            return obj.GetHashCode();
        }
    }
}