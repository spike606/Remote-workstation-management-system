using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
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
    }
}
