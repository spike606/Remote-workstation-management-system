using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic;
using SystemMonitor.Shared.WMI;
using SystemMonitor.SoftwareStatic.Model.Components.Abstract;
using SystemMonitor.SoftwareStatic.SoftwareStaticProvider;

namespace SystemMonitor.SoftwareStatic.Model.Components
{
    public class Bios : SoftwareStaticComponent, IWMISoftwareStaticComponent
    {
        public string BIOSVersion { get; private set; }

        public string BuildNumber { get; private set; }

        public string Caption { get; private set; }

        public string Description { get; private set; }

        public string EmbeddedControllerMajorVersion { get; private set; }

        public string EmbeddedControllerMinorVersion { get; private set; }

        public string Manufacturer { get; private set; }

        public string Name { get; private set; }

        public DateTime ReleaseDate { get; private set; }

        public string SerialNumber { get; private set; }

        public string SMBIOSBIOSVersion { get; private set; }

        public string SMBIOSMajorVersion { get; private set; }

        public string SMBIOSMinorVersion { get; private set; }

        public string SMBIOSPresent { get; private set; }

        public string SystemBiosMajorVersion { get; private set; }

        public string SystemBiosMinorVersion { get; private set; }

        public string Version { get; private set; }

        public SoftwareStaticComponent ExtractData(ManagementObject managementObject)
        {
            Bios bios = new Bios();

            bios.BIOSVersion = managementObject[ConstString.BIOS_BIOS_VERSION]?.ToString() ?? string.Empty;
            bios.BuildNumber = managementObject[ConstString.BIOS_BUILD_NUMBER]?.ToString() ?? string.Empty;
            bios.Caption = managementObject[ConstString.COMPONENT_CAPTION]?.ToString() ?? string.Empty;
            bios.Description = managementObject[ConstString.COMPONENT_DESCRIPTION]?.ToString() ?? string.Empty;
            bios.EmbeddedControllerMajorVersion = managementObject[ConstString.BIOS_EMBEDDED_CONTROLLER_MAJOR_VERSION]?.ToString() ?? string.Empty;
            bios.EmbeddedControllerMinorVersion = managementObject[ConstString.BIOS_EMBEDDED_CONTROLLER_MINOR_VERSION]?.ToString() ?? string.Empty;
            bios.Manufacturer = managementObject[ConstString.BIOS_MANUFACTURER]?.ToString() ?? string.Empty;
            bios.Name = managementObject[ConstString.COMPONENT_NAME]?.ToString() ?? string.Empty;
            bios.ReleaseDate = managementObject[ConstString.BIOS_RELEASE_DATE] != null ? ManagementDateTimeConverter.ToDateTime(managementObject[ConstString.BIOS_RELEASE_DATE].ToString()) : default(DateTime);
            bios.SerialNumber = managementObject[ConstString.BIOS_SERIAL_NUMBER]?.ToString() ?? string.Empty;
            bios.SMBIOSMajorVersion = managementObject[ConstString.BIOS_SMBIOS_MAJOR_VERSION]?.ToString() ?? string.Empty;
            bios.SMBIOSMinorVersion = managementObject[ConstString.BIOS_SMBIOS_MINOR_VERSION]?.ToString() ?? string.Empty;
            bios.SMBIOSPresent = managementObject[ConstString.BIOS_SMBIOS_PRESENT]?.ToString() ?? string.Empty;
            bios.SMBIOSBIOSVersion = managementObject[ConstString.BIOS_SMBIOS_VERSION]?.ToString() ?? string.Empty;
            bios.SystemBiosMajorVersion = managementObject[ConstString.BIOS_SYSTEM_BIOS_MAJOR_VERSION]?.ToString() ?? string.Empty;
            bios.SystemBiosMinorVersion = managementObject[ConstString.BIOS_SYSTEM_BIOS_MINOR_VERSION]?.ToString() ?? string.Empty;
            bios.Version = managementObject[ConstString.BIOS_VERSION]?.ToString() ?? string.Empty;

            return bios;
        }

        public List<ManagementObject> GetManagementObjectsForSoftwareComponent(IWMIClient wmiClient)
        {
            return wmiClient.RetriveListOfObjectsByExecutingWMIQuery(ConstString.WMI_NAMESPACE_ROOT_CIMV2, ConstString.WMI_QUERY_BIOS);
        }

        public override List<SoftwareStaticComponent> GetStaticDataForSoftwareComponent(ISoftwareStaticProvider softwareStaticProvider)
        {
            return softwareStaticProvider.GetSoftwareStaticDataFromWMI(new Bios());
        }
    }
}
