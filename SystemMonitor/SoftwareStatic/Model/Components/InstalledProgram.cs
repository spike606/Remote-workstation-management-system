using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using SystemMonitor.HardwareStatic;
using SystemMonitor.Shared;
using SystemMonitor.SoftwareStatic.Model.Components.Interface;
using SystemMonitor.SoftwareStatic.SoftwareStaticProvider;

namespace SystemMonitor.SoftwareStatic.Model.Components
{
    public class InstalledProgram : ISoftwareStaticComponent<InstalledProgram>
    {
        public string InstallLocation { get; set; }

        public DateTime InstallDate { get; set; }

        public string Name { get; set; }

        public string Version { get; set; }

        public List<InstalledProgram> GetStaticDataForSoftwareComponent(ISoftwareStaticProvider softwareStaticProvider)
        {
            List<InstalledProgram> installedPrograms = new List<InstalledProgram>();

            this.GetProgramsFromRegistryKey(installedPrograms, RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(ConstString.REGISTRY_INSTALLED_PROGRAMS_64));
            this.GetProgramsFromRegistryKey(installedPrograms, RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(ConstString.REGISTRY_INSTALLED_PROGRAMS_32));
            this.GetProgramsFromRegistryKey(installedPrograms, RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry32).OpenSubKey(ConstString.REGISTRY_INSTALLED_PROGRAMS_64));
            var sortedInstalledPrograms = installedPrograms.OrderBy(x => ((InstalledProgram)x).Name).ToList();
            return sortedInstalledPrograms;
        }

        private void GetProgramsFromRegistryKey(List<InstalledProgram> installedPrograms, RegistryKey registryKey)
        {
            using (registryKey)
            {
                foreach (string subkeyName in registryKey.GetSubKeyNames())
                {
                    using (RegistryKey subkey = registryKey.OpenSubKey(subkeyName))
                    {
                        InstalledProgram program = new InstalledProgram();
                        string applicationName = subkey.GetValue(ConstString.REGISTRY_DISPLAY_NAME)?.ToString() ?? string.Empty;
                        if (!string.IsNullOrEmpty(applicationName) && !installedPrograms.Cast<InstalledProgram>().ToList().Any(x => x.Name == applicationName))
                        {
                            program.Name = applicationName;
                            string installDateAsString = subkey.GetValue(ConstString.REGISTRY_INSTALL_DATE)?.ToString() ?? string.Empty;
                            program.InstallDate = DateTimeHelper.ConvertRegistryDateStringToCorrectDateTimeFormat(installDateAsString);
                            program.InstallLocation = subkey.GetValue(ConstString.REGISTRY_INSTALL_LOCATION)?.ToString() ?? string.Empty;
                            program.Version = subkey.GetValue(ConstString.REGISTRY_DISPLAY_VERSION)?.ToString() ?? string.Empty;
                            installedPrograms.Add(program);
                        }
                    }
                }
            }
        }
    }
}
