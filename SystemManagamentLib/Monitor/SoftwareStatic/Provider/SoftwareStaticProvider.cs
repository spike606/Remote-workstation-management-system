using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Management;
using System.Security;
using System.Security.Claims;
using System.Security.Principal;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using SystemManagament.Logger;
using SystemManagament.Monitor.HardwareStatic;
using SystemManagament.Monitor.SoftwareStatic.Model.Components;
using SystemManagament.Monitor.SoftwareStatic.Model.Components.Duplicate;
using SystemManagament.Shared;
using SystemManagament.Shared.WMI;

namespace SystemManagament.Monitor.SoftwareStatic.Provider
{
    public class SoftwareStaticProvider : ISoftwareStaticProvider
    {
        public SoftwareStaticProvider(IWMIClient wmiClient, INLogger logger)
        {
            this.WMIClient = wmiClient;
            this.Logger = logger;
        }

        private IWMIClient WMIClient { get; set; }

        private INLogger Logger { get; set; }

        public List<CurrentUser> GetCurrentUsers()
        {
            List<CurrentUser> currentUsers = new List<CurrentUser>();

            List<ManagementObject> explorerProcesses = this.WMIClient.RetriveListOfObjectsByExecutingWMIQuery(
                ConstString.WMI_NAMESPACE_ROOT_CIMV2,
                ConstString.WMI_QUERY_EXPLORER_PROCESS);

            foreach (var explorerProcess in explorerProcesses)
            {
                CurrentUser currentUser = new CurrentUser();

                string[] currentUserName = new string[2];
                explorerProcess.InvokeMethod("GetOwner", (object[])currentUserName);
                currentUser.Name = currentUserName[1] + "\\" + currentUserName[0];

                try
                {
                    using (var user = this.GetUserPrincipal(currentUser.Name))
                    {
                        currentUser.Sid = user.Sid.ToString();
                        currentUser.LastLogonDate = user.LastLogon ?? default(DateTime);
                        currentUser.LastPasswordSet = user.LastPasswordSet ?? default(DateTime);
                    }
                }
                catch (SecurityException ex)
                {
                    this.Logger.LogError(ex.Message, ex);
                }

                currentUsers.Add(currentUser);
            }

            return currentUsers;
        }

        public List<InstalledProgram> GetInstalledPrograms()
        {
            List<InstalledProgram> installedPrograms = new List<InstalledProgram>();
            this.GetProgramsFromRegistryKey(installedPrograms, RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(ConstString.REGISTRY_INSTALLED_PROGRAMS_64));
            this.GetProgramsFromRegistryKey(installedPrograms, RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(ConstString.REGISTRY_INSTALLED_PROGRAMS_32));
            this.GetProgramsFromRegistryKey(installedPrograms, RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry32).OpenSubKey(ConstString.REGISTRY_INSTALLED_PROGRAMS_64));
            var sortedInstalledPrograms = installedPrograms.OrderBy(x => ((InstalledProgram)x).Name).ToList();

            return sortedInstalledPrograms;
        }

        public List<T> GetSoftwareStaticDataFromWMI<T>()
            where T : IWMISoftwareStaticComponent<T>, new()
        {
            List<T> softwareStaticDataList = new List<T>();
            var softwareStaticData = new T();
            List<ManagementObject> managementObjectList = softwareStaticData.GetManagementObjectsForSoftwareComponent(this.WMIClient);

            foreach (var managementObject in managementObjectList)
            {
                softwareStaticDataList.Add(softwareStaticData.ExtractData(managementObject));
            }

            return softwareStaticDataList;
        }

        public UserPrincipal GetUserPrincipal(string username)
        {
            return UserPrincipal.FindByIdentity(
                                    UserPrincipal.Current.Context,
                                    IdentityType.SamAccountName,
                                    username) ??
                                    UserPrincipal.FindByIdentity(
                                    UserPrincipal.Current.Context,
                                    IdentityType.UserPrincipalName,
                                    username
                                    );
        }

        private void GetProgramsFromRegistryKey(List<InstalledProgram> installedPrograms, RegistryKey registryKey)
        {
            using (registryKey)
            {
                foreach (string subkeyName in registryKey.GetSubKeyNames())
                {
                    using (RegistryKey subkey = registryKey.OpenSubKey(subkeyName))
                    {
                        try
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
                        catch (Exception ex)
                        {
                            this.Logger.LogError(ex.Message, ex);
                        }
                    }
                }
            }
        }

        private List<GroupDuplicate> MapSystemGroups(WindowsIdentity identity)
        {
            List<GroupDuplicate> groupDuplicate = new List<GroupDuplicate>();

            if (identity != null)
            {
                foreach (var group in identity.Groups)
                {
                    groupDuplicate.Add(new GroupDuplicate()
                    {
                        Value = group.Value,
                        Name = group.Translate(typeof(NTAccount)).Value
                    });
                }
            }

            return groupDuplicate;
        }
    }
}
