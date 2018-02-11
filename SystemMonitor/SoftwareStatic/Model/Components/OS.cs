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
using SystemMonitor.SoftwareStatic.Provider;

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

            operatingSystem.BuildNumber = managementObject[ConstString.OS_BUILD_NUMBER].TryGetStringValue();
            operatingSystem.BuildType = managementObject[ConstString.OS_BUILD_TYPE].TryGetStringValue();
            operatingSystem.Caption = managementObject[ConstString.COMPONENT_CAPTION].TryGetStringValue();
            operatingSystem.CountryCode = managementObject[ConstString.OS_COUNTRY_CODE].TryGetStringValue();
            operatingSystem.CDSVersion = managementObject[ConstString.OS_CSD_VERSION].TryGetStringValue();
            operatingSystem.CSName = managementObject[ConstString.COMPONENT_NAME].TryGetStringValue();
            operatingSystem.CurrentTimeZone = managementObject[ConstString.OS_CURRENT_TIME_ZONE].TryGetUnitValue(Unit.Minutes);
            operatingSystem.Description = managementObject[ConstString.COMPONENT_DESCRIPTION].TryGetStringValue();
            operatingSystem.EncryptionLevel = managementObject[ConstString.OS_ENCRYPTION_LEVEL].TryGetUnitValue(Unit.BIT);
            operatingSystem.InstallDate = managementObject[ConstString.OS_INSTALL_DATE] != null ? ManagementDateTimeConverter.ToDateTime(managementObject[ConstString.OS_INSTALL_DATE].ToString()) : default(DateTime);
            operatingSystem.LastBootUpTime = managementObject[ConstString.OS_LAST_BOOT_UP_TIME] != null ? ManagementDateTimeConverter.ToDateTime(managementObject[ConstString.OS_LAST_BOOT_UP_TIME].ToString()) : default(DateTime);
            operatingSystem.LocalDateTime = managementObject[ConstString.OS_LOCALE_DATE_TIME] != null ? ManagementDateTimeConverter.ToDateTime(managementObject[ConstString.OS_LOCALE_DATE_TIME].ToString()) : default(DateTime);
            operatingSystem.Locale = managementObject[ConstString.OS_LOCALE].TryGetStringValue();
            operatingSystem.MaxNumerOfProcesses = managementObject[ConstString.OS_MAX_NUMBER_OF_PROCESSES].TryGetStringValue();
            operatingSystem.MaxProcessMemorySize = managementObject[ConstString.OS_MAX_PROCESS_MEMORY_SIZE].TryGetUnitValue(Unit.KB);
            operatingSystem.Name = managementObject[ConstString.COMPONENT_NAME].TryGetStringValue();
            operatingSystem.Organization = managementObject[ConstString.OS_ORGANIZATION].TryGetStringValue();
            operatingSystem.OSArchitecture = managementObject[ConstString.OS_ARCHITECTURE].TryGetStringValue();
            operatingSystem.RegisteredUser = managementObject[ConstString.OS_REGISTERED_USER].TryGetStringValue();
            operatingSystem.SerialNumber = managementObject[ConstString.OS_SERIAL_NUMBER].TryGetStringValue();
            operatingSystem.ServicePackMajorVersion = managementObject[ConstString.OS_SERVICE_PACK_MAJOR_VERSION].TryGetStringValue();
            operatingSystem.ServicePackMinorVersion = managementObject[ConstString.OS_SERVICE_PACK_MINOR_VERSION].TryGetStringValue();
            operatingSystem.SystemDirectory = managementObject[ConstString.OS_SYSTEM_DIRECTORY].TryGetStringValue();
            operatingSystem.SystemDrive = managementObject[ConstString.OS_SYSTEM_DRIVE].TryGetStringValue();
            operatingSystem.Version = managementObject[ConstString.OS_VERSION].TryGetStringValue();
            operatingSystem.WindowsDirectory = managementObject[ConstString.OS_WINDOWS_DIRECTORY].TryGetStringValue();

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
