using System.Collections.Generic;
using SystemManagament.Client.WPF.WorkstationMonitorService;

namespace SystemManagament.Client.WPF.Comparer
{
    public class BiosComparer : IEqualityComparer<Bios>
    {
        public bool Equals(Bios x, Bios y)
        {
            return x.BuildNumber == y.BuildNumber
                && x.BIOSVersion == y.BIOSVersion
                && x.Caption == y.Caption
                && x.EmbeddedControllerMajorVersion == y.EmbeddedControllerMajorVersion
                && x.EmbeddedControllerMinorVersion == y.EmbeddedControllerMinorVersion
                && x.Manufacturer == y.Manufacturer
                && x.Name == y.Name
                && x.ReleaseDate == y.ReleaseDate
                && x.SerialNumber == y.SerialNumber
                && x.SMBIOSBIOSVersion == y.SMBIOSBIOSVersion
                && x.SMBIOSMajorVersion == y.SMBIOSMajorVersion
                && x.SMBIOSMinorVersion == y.SMBIOSMinorVersion
                && x.SMBIOSPresent == y.SMBIOSPresent
                && x.SystemBiosMajorVersion == y.SystemBiosMajorVersion
                && x.Name == y.Name
                && x.SystemBiosMinorVersion == y.SystemBiosMinorVersion
                && x.Version == y.Version
                && x.SerialNumber == y.SerialNumber
                && x.Version == y.Version;
        }

        public int GetHashCode(Bios obj)
        {
            return obj.GetHashCode();
        }
    }
}