using System.Collections.Generic;
using SystemManagament.Client.WPF.WorkstationMonitorService;

namespace SystemManagament.Client.WPF.Comparer
{
    public class LocalUserComparer : IEqualityComparer<LocalUser>
    {
        public bool Equals(LocalUser x, LocalUser y)
        {
            return x.Caption == y.Caption
                && x.Descritption == y.Descritption
                && x.Name == y.Name
                && x.FullName == y.FullName
                && x.PasswordChangeable == y.PasswordChangeable
                && x.PasswordExpires == y.PasswordExpires
                && x.PasswordRequired == y.PasswordRequired
                && x.SID == y.SID
                && x.SIDType == y.SIDType;
        }

        public int GetHashCode(LocalUser obj)
        {
            return obj.GetHashCode();
        }
    }
}