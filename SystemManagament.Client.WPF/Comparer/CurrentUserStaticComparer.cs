using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Client.WPF.WorkstationMonitorService;

namespace SystemManagament.Client.WPF.Comparer
{
    public class CurrentUserStaticComparer : IEqualityComparer<CurrentUser>
    {
        public bool Equals(CurrentUser x, CurrentUser y)
        {
            return x.Sid == y.Sid
                && x.Name == y.Name
                && x.LastLogonDate == y.LastLogonDate
                && x.LastPasswordSet == y.LastPasswordSet;
        }

        public int GetHashCode(CurrentUser obj)
        {
            return obj.GetHashCode();
        }
    }
}
