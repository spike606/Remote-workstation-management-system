using System.Collections.Generic;
using SystemManagament.Client.WPF.WorkstationMonitorService;

namespace SystemManagament.Client.WPF.Comparer
{
    public class GroupDuplicateComparer : IEqualityComparer<GroupDuplicate>
    {
        public bool Equals(GroupDuplicate x, GroupDuplicate y)
        {
            return x.Value == y.Value;
        }

        public int GetHashCode(GroupDuplicate obj)
        {
            return obj.GetHashCode();
        }
    }
}