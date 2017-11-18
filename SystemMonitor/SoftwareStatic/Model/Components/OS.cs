using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic;
using SystemMonitor.HardwareStatic.Model.CustomProperties;
using SystemMonitor.Shared.WMI;
using SystemMonitor.SoftwareStatic.Model.Components.Interface;
using SystemMonitor.SoftwareStatic.SoftwareStaticProvider;

namespace SystemMonitor.SoftwareStatic.Model.Components
{
    public class OS : ISoftwareStaticComponent<OS>, IWMISoftwareStaticComponent<OS>
    {
        public string BuildNumber { get; set; }

        public string BuildType { get; set; }

        public string Caption { get; set; }

        public string CountryCode { get; set; }

        public string CDSVersion { get; set; }

        public string CSName { get; set; }

        public UnitValue CurrentTimeZone { get; set; }

        public string Description { get; set; }

        public UnitValue EncryptionLevel { get; set; }

        public DateTime InstallDate { get; set; }

        public DateTime LastBootUpTime { get; set; }

        public DateTime LocalDateTime { get; set; }

        public string Locale { get; set; }

        public string MaxNumerOfProcesses { get; set; }

        public UnitValue MaxProcessMemorySize { get; set; }

        public string Name { get; set; }

        public string Organization { get; set; }

        public string OSArchitecture { get; set; }

        public string RegisteredUser { get; set; }

        public string SerialNumber { get; set; }

        public string ServicePackMajorVersion { get; set; }

        public string ServicePackMinorVersion { get; set; }

        public string SystemDirectory { get; set; }

        public string SystemDrive { get; set; }

        public string Version { get; set; }

        public string WindowsDirectory { get; set; }

        public OS ExtractData(ManagementObject managementObject)
        {
            OS operatingSystem = new OS();

            operatingSystem.BuildNumber = managementObject[ConstString.OS_BUILD_NUMBER]?.ToString() ?? string.Empty;
            operatingSystem.BuildType = managementObject[ConstString.OS_BUILD_TYPE]?.ToString() ?? string.Empty;
            operatingSystem.Caption = managementObject[ConstString.COMPONENT_CAPTION]?.ToString() ?? string.Empty;
            operatingSystem.CountryCode = managementObject[ConstString.OS_COUNTRY_CODE]?.ToString() ?? string.Empty;
            operatingSystem.CDSVersion = managementObject[ConstString.OS_CSD_VERSION]?.ToString() ?? string.Empty;
            operatingSystem.CSName = managementObject[ConstString.COMPONENT_NAME]?.ToString() ?? string.Empty;
            operatingSystem.CurrentTimeZone = new UnitValue(Unit.Minutes, managementObject[ConstString.OS_CURRENT_TIME_ZONE]?.ToString() ?? string.Empty);
            operatingSystem.Description = managementObject[ConstString.COMPONENT_DESCRIPTION]?.ToString() ?? string.Empty;
            operatingSystem.EncryptionLevel = new UnitValue(Unit.BIT, managementObject[ConstString.OS_ENCRYPTION_LEVEL]?.ToString() ?? string.Empty);
            operatingSystem.InstallDate = managementObject[ConstString.OS_INSTALL_DATE] != null ? ManagementDateTimeConverter.ToDateTime(managementObject[ConstString.OS_INSTALL_DATE].ToString()) : default(DateTime);
            operatingSystem.LastBootUpTime = managementObject[ConstString.OS_LAST_BOOT_UP_TIME] != null ? ManagementDateTimeConverter.ToDateTime(managementObject[ConstString.OS_LAST_BOOT_UP_TIME].ToString()) : default(DateTime);
            operatingSystem.LocalDateTime = managementObject[ConstString.OS_LOCALE_DATE_TIME] != null ? ManagementDateTimeConverter.ToDateTime(managementObject[ConstString.OS_LOCALE_DATE_TIME].ToString()) : default(DateTime);
            operatingSystem.Locale = managementObject[ConstString.OS_LOCALE]?.ToString() ?? string.Empty;
            operatingSystem.MaxNumerOfProcesses = managementObject[ConstString.OS_MAX_NUMBER_OF_PROCESSES]?.ToString() ?? string.Empty;
            operatingSystem.MaxProcessMemorySize = new UnitValue(Unit.KB, managementObject[ConstString.OS_MAX_PROCESS_MEMORY_SIZE]?.ToString() ?? string.Empty);
            operatingSystem.Name = managementObject[ConstString.COMPONENT_NAME]?.ToString() ?? string.Empty;
            operatingSystem.Organization = managementObject[ConstString.OS_ORGANIZATION]?.ToString() ?? string.Empty;
            operatingSystem.OSArchitecture = managementObject[ConstString.OS_ARCHITECTURE]?.ToString() ?? string.Empty;
            operatingSystem.RegisteredUser = managementObject[ConstString.OS_REGISTERED_USER]?.ToString() ?? string.Empty;
            operatingSystem.SerialNumber = managementObject[ConstString.OS_SERIAL_NUMBER]?.ToString() ?? string.Empty;
            operatingSystem.ServicePackMajorVersion = managementObject[ConstString.OS_SERVICE_PACK_MAJOR_VERSION]?.ToString() ?? string.Empty;
            operatingSystem.ServicePackMinorVersion = managementObject[ConstString.OS_SERVICE_PACK_MINOR_VERSION]?.ToString() ?? string.Empty;
            operatingSystem.SystemDirectory = managementObject[ConstString.OS_SYSTEM_DIRECTORY]?.ToString() ?? string.Empty;
            operatingSystem.SystemDrive = managementObject[ConstString.OS_SYSTEM_DRIVE]?.ToString() ?? string.Empty;
            operatingSystem.Version = managementObject[ConstString.OS_VERSION]?.ToString() ?? string.Empty;
            operatingSystem.WindowsDirectory = managementObject[ConstString.OS_WINDOWS_DIRECTORY]?.ToString() ?? string.Empty;

            return operatingSystem;
        }

        public List<ManagementObject> GetManagementObjectsForSoftwareComponent(IWMIClient wmiClient)
        {
            return wmiClient.RetriveListOfObjectsByExecutingWMIQuery(ConstString.WMI_NAMESPACE_ROOT_CIMV2, ConstString.WMI_QUERY_OS);
        }

        public List<OS> GetStaticDataForSoftwareComponent(ISoftwareStaticProvider softwareStaticProvider)
        {
            return softwareStaticProvider.GetSoftwareStaticDataFromWMI<OS>();
        }
    }
}
