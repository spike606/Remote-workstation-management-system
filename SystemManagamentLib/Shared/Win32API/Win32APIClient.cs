using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;
using SystemManagament.Logger;

namespace SystemManagament.Shared.Win32API
{
    public class Win32APIClient : IWin32APIClient
    {
        private const uint EWX_FORCEIFHUNG_FLAG = 0x00000010;

        public Win32APIClient(INLogger logger)
        {
            this.Logger = logger;
        }

        public INLogger Logger { get; private set; }

        public string GetProcessUser(Process process)
        {
            IntPtr processHandle = IntPtr.Zero;
            try
            {
                OpenProcessToken(process.Handle, 8, out processHandle);
                WindowsIdentity windowsIdentity = new WindowsIdentity(processHandle);
                return windowsIdentity.Name;
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex.Message, ex);
                return string.Empty;
            }
            finally
            {
                if (processHandle != IntPtr.Zero)
                {
                    CloseHandle(processHandle);
                }
            }
        }

        public OperationStatus LogOutUser()
        {
            try
            {
                ExitWindowsEx(EWX_FORCEIFHUNG_FLAG, 0);
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex.Message, ex);
                return new OperationStatus(false, ex.Message);
            }

            return new OperationStatus(true, string.Empty);
        }

        public DateTime GetRegistryKeyLastModifiedDate(SafeRegistryHandle safeRegistryHandle)
        {
            long lastModified = default(long);
            var lpcbClass = default(uint);
            var lpReserved = default(IntPtr);

            try
            {
                uint lpcbSubKeys;
                uint lpcbMaxKeyLen;
                uint lpcbMaxClassLen;
                uint lpcValues;
                uint maxValueName;
                uint maxValueLen;
                uint securityDescriptor;
                StringBuilder sb;
                if (RegQueryInfoKey(
                             safeRegistryHandle,
                             out sb,
                             ref lpcbClass,
                             lpReserved,
                             out lpcbSubKeys,
                             out lpcbMaxKeyLen,
                             out lpcbMaxClassLen,
                             out lpcValues,
                             out maxValueName,
                             out maxValueLen,
                             out securityDescriptor,
                             out lastModified) != 0)
                {
                    return default(DateTime);
                }

                var result = DateTime.FromFileTimeUtc(lastModified);
                return result;
            }
            catch (Exception ex)
            {
                return default(DateTime);
            }
        }

        [SuppressMessage("Microsoft.Design", "CA1060:MovePInvokesToNativeMethodsClass", Justification = "Method used locally")]
        [SuppressMessage("StyleCop.Analyzers", "SA1313:ParameterNamesMustBeginWithLowerCaseLetter", Justification = "Dll import")]
        [DllImport(".\\Externals\\advapi32.dll", SetLastError = true)]
        private static extern bool OpenProcessToken(IntPtr ProcessHandle, uint DesiredAccess, out IntPtr TokenHandle);

        [SuppressMessage("Microsoft.Design", "CA1060:MovePInvokesToNativeMethodsClass", Justification = "Method used locally")]
        [DllImport(".\\Externals\\kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool CloseHandle(IntPtr hObject);

        [SuppressMessage("Microsoft.Design", "CA1060:MovePInvokesToNativeMethodsClass", Justification = "Method used locally")]
        [DllImport(".\\Externals\\user32.dll")]
        private static extern bool ExitWindowsEx(uint uFlags, uint dwReason);

        [DllImport(".\\Externals\\advapi32.dll")]
        private static extern int RegQueryInfoKey(
            SafeRegistryHandle handle,
            out StringBuilder lpClass,
            ref uint lpcbClass,
            IntPtr lpReserved,
            out uint lpcSubKeys,
            out uint lpcbMaxSubKeyLen,
            out uint lpcbMaxClassLen,
            out uint lpcValues,
            out uint lpcbMaxValueNameLen,
            out uint lpcbMaxValueLen,
            out uint lpcbSecurityDescriptor,
            out long lpftLastWriteTime);
    }
}
