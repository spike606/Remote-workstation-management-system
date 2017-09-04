using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using SystemMonitor.HardwareStatic;
using SystemMonitor.SoftwareStatic.Model.Components.Abstract;
using SystemMonitor.SoftwareStatic.SoftwareStaticProvider;

namespace SystemMonitor.SoftwareStatic.Model.Components
{
    public class InstalledProgram : SoftwareStaticComponent
    {
        public string InstallLocation { get; set; }

        public string InstallDate { get; set; }

        public string Name { get; set; }

        public string Version { get; set; }

        public override List<SoftwareStaticComponent> GetStaticDataForSoftwareComponent(ISoftwareStaticProvider softwareStaticProvider)
        {
            List<SoftwareStaticComponent> installedPrograms = new List<SoftwareStaticComponent>();

            this.GetProgramsFromRegistryKey(installedPrograms, ConstString.REGISTRY_INSTALLED_PROGRAMS_32);
            this.GetProgramsFromRegistryKey(installedPrograms, ConstString.REGISTRY_INSTALLED_PROGRAMS_64);
            var sortedInstalledPrograms = installedPrograms.OrderBy(x => ((InstalledProgram)x).Name).ToList();
            return sortedInstalledPrograms;
        }

        private void GetProgramsFromRegistryKey(List<SoftwareStaticComponent> installedPrograms, string registryKey)
        {
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registryKey))
            {
                foreach (string subkeyName in key.GetSubKeyNames())
                {
                    using (RegistryKey subkey = key.OpenSubKey(subkeyName))
                    {
                        InstalledProgram program = new InstalledProgram();
                        string applicationName = subkey.GetValue(ConstString.REGISTRY_DISPLAY_NAME)?.ToString() ?? string.Empty;
                        if (!string.IsNullOrEmpty(applicationName) && !installedPrograms.Cast<InstalledProgram>().ToList().Any(x => x.Name == applicationName))
                        {
                            program.Name = applicationName;
                            program.InstallDate = subkey.GetValue(ConstString.REGISTRY_INSTALL_DATE)?.ToString() ?? string.Empty;
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
