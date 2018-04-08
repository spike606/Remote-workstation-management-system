using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.HardwareStatic;
using SystemManagament.Monitor.HardwareStatic.Model.CustomProperties;
using SystemManagament.Monitor.SoftwareStatic.Model.Components.Interface;
using SystemManagament.Monitor.SoftwareStatic.Provider;
using SystemManagament.Shared.WMI;

namespace SystemManagament.Monitor.SoftwareStatic.Model.Components
{
    [DataContract]
    public class OS : ISoftwareStaticComponent<OS>, IWMISoftwareStaticComponent<OS>
    {
        [DataMember]
        public string BuildNumber { get; set; }

        [DataMember]
        public string BuildType { get; set; }

        [DataMember]
        public string Caption { get; set; }

        [DataMember]
        public string CountryCode { get; set; }

        [DataMember]
        public string CDSVersion { get; set; }

        [DataMember]
        public string CSName { get; set; }

        [DataMember]
        public UnitValue CurrentTimeZone { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public UnitValue EncryptionLevel { get; set; }

        [DataMember]
        public DateTime InstallDate { get; set; }

        [DataMember]
        public DateTime LastBootUpTime { get; set; }

        [DataMember]
        public DateTime LocalDateTime { get; set; }

        [DataMember]
        public string Locale { get; set; }

        [DataMember]
        public string MaxNumerOfProcesses { get; set; }

        [DataMember]
        public UnitValue MaxProcessMemorySize { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Organization { get; set; }

        [DataMember]
        public string OSArchitecture { get; set; }

        [DataMember]
        public string RegisteredUser { get; set; }

        [DataMember]
        public string SerialNumber { get; set; }

        [DataMember]
        public string ServicePackMajorVersion { get; set; }

        [DataMember]
        public string ServicePackMinorVersion { get; set; }

        [DataMember]
        public string SystemDirectory { get; set; }

        [DataMember]
        public string SystemDrive { get; set; }

        [DataMember]
        public string Version { get; set; }

        [DataMember]
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
