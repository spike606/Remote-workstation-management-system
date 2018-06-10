using System.Collections.Generic;
using SystemManagament.Client.WPF.WorkstationMonitorService;

namespace SystemManagament.Client.WPF.Comparer
{
    public class ClaimDuplicateComparer : IEqualityComparer<ClaimDuplicate>
    {
        public bool Equals(ClaimDuplicate x, ClaimDuplicate y)
        {
            return x.Issuer == y.Issuer
                && x.OriginalIssuer == y.OriginalIssuer
                && x.Type == y.Type
                && x.Value == y.Value
                && x.ValueType == y.ValueType;
        }

        public int GetHashCode(ClaimDuplicate obj)
        {
            return obj.GetHashCode();
        }
    }
}