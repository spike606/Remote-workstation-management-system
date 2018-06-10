using System.Collections.Generic;
using SystemManagament.Client.WPF.WorkstationMonitorService;

namespace SystemManagament.Client.WPF.Comparer
{
    public class OSComparer : IEqualityComparer<OS>
    {
        public bool Equals(OS x, OS y)
        {
            return x.BuildNumber == y.BuildNumber
                && x.BuildType == y.BuildType
                && x.Caption == y.Caption
                && x.CDSVersion == y.CDSVersion
                && x.CountryCode == y.CountryCode
                && x.CSName == y.CSName
                && x.CurrentTimeZone.Value == y.CurrentTimeZone.Value
                && x.EncryptionLevel.Value == y.EncryptionLevel.Value
                && x.InstallDate == y.InstallDate
                && x.LastBootUpTime == y.LastBootUpTime
                && x.LocalDateTime == y.LocalDateTime
                && x.Locale == y.Locale
                && x.MaxNumerOfProcesses == y.MaxNumerOfProcesses
                && x.MaxProcessMemorySize.Value == y.MaxProcessMemorySize.Value
                && x.Name == y.Name
                && x.Organization == y.Organization
                && x.OSArchitecture == y.OSArchitecture
                && x.RegisteredUser == y.RegisteredUser
                && x.SerialNumber == y.SerialNumber
                && x.ServicePackMajorVersion == y.ServicePackMajorVersion
                && x.ServicePackMinorVersion == y.ServicePackMinorVersion
                && x.SystemDirectory == y.SystemDirectory
                && x.SystemDrive == y.SystemDrive
                && x.Version == y.Version
                && x.WindowsDirectory == y.WindowsDirectory;
        }

        public int GetHashCode(OS obj)
        {
            return obj.GetHashCode();
        }
    }
}