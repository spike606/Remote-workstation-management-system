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
            return x.AuthenticationType == y.AuthenticationType
                && x.Name == y.Name;
        }

        public int GetHashCode(CurrentUser obj)
        {
            return obj.GetHashCode();
        }
    }
}
