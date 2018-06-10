using System.Collections.Generic;
using SystemManagament.Client.WPF.WorkstationMonitorService;

namespace SystemManagament.Client.WPF.Comparer
{
    public class InstalledProgramComparer : IEqualityComparer<InstalledProgram>
    {
        public bool Equals(InstalledProgram x, InstalledProgram y)
        {
            return x.InstallDate == y.InstallDate
                && x.InstallLocation == y.InstallLocation
                && x.Name == y.Name
                && x.Version == y.Version;
        }

        public int GetHashCode(InstalledProgram obj)
        {
            return obj.GetHashCode();
        }
    }
}