using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Logger;
using SystemManagament.Monitor.HardwareStatic.Model.CustomProperties;
using SystemManagament.Monitor.SoftwareDynamic.Model.Components;
using SystemManagament.Monitor.SoftwareDynamic.Model.Components.Duplicate;
using SystemManagament.Shared.Win32API;

namespace SystemManagament.Monitor.SoftwareDynamic.Provider
{
    public class SoftwareDynamicProvider : ISoftwareDynamicProvider
    {
        public SoftwareDynamicProvider(INLogger logger, IWin32APIClient win32APIClient)
        {
            this.Logger = logger;
            this.Win32APIClient = win32APIClient;
        }

        public INLogger Logger { get; set; }

        private IWin32APIClient Win32APIClient { get; set; }

        public ServiceController[] GetWindowsServices()
        {
            try
            {
                return ServiceController.GetServices();
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex.Message, ex);
            }

            return new ServiceController[0];
        }

        public List<WindowsProcess> GetWindowsProcesses()
        {
            List<WindowsProcess> windowsProcesses = new List<WindowsProcess>();

            try
            {
                foreach (var process in Process.GetProcesses())
                {
                    WindowsProcess windowsProcess = new WindowsProcess();
                    windowsProcess.BasePriority = process.BasePriority.ToString();
                    windowsProcess.Id = process.Id.ToString();
                    windowsProcess.Name = process.ProcessName;
                    windowsProcess.StartTime = process.StartTime;
                    windowsProcess.TotalProcessorTime = process.TotalProcessorTime;
                    windowsProcess.PagedMemorySize64 = new UnitLongValue() { Unit = Unit.B, Value = process.PagedMemorySize64 };
                    windowsProcess.VirtualMemorySize64 = new UnitLongValue() { Unit = Unit.B, Value = process.VirtualMemorySize64 };
                    windowsProcess.MemorySize = new UnitLongValue() { Unit = Unit.B, Value = process.WorkingSet64 };
                    windowsProcess.TotalProcessorTime = process.TotalProcessorTime;
                    windowsProcess.PeakPagedMemorySize64 = new UnitLongValue() { Unit = Unit.B, Value = process.PeakPagedMemorySize64 };
                    windowsProcess.PeakVirtualMemorySize64 = new UnitLongValue() { Unit = Unit.B, Value = process.PeakVirtualMemorySize64 };
                    windowsProcess.PeakMemorySize = new UnitLongValue() { Unit = Unit.B, Value = process.PeakWorkingSet64 };
                    windowsProcess.SessionId = process.SessionId.ToString();

                    var processOwner = this.GetProcessOwner(process);
                    windowsProcess.UserName = processOwner.Contains(@"\") ? processOwner.Substring(processOwner.IndexOf(@"\") + 1) : processOwner;

                    windowsProcesses.Add(windowsProcess);
                }
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex.Message, ex);
            }

            return windowsProcesses;
        }

        public List<WindowsLog> GetWindowsLogs()
        {
            List<WindowsLog> windowsLogs = new List<WindowsLog>();
            try
            {
                var logs = EventLog.GetEventLogs();

                foreach (var log in logs)
                {
                    WindowsLog windowsLog = new WindowsLog();
                    windowsLog.Entries = this.MapSystemEventLogEntries(log.Entries);
                    windowsLog.LogName = log.Log;
                    windowsLog.LogDisplayName = log.LogDisplayName;
                    windowsLog.MaximumKilobytes = new UnitLongValue() { Unit = Unit.KB, Value = log.MaximumKilobytes };
                    windowsLog.MinimumRetentionDays = new UnitIntValue() { Unit = Unit.Days, Value = log.MinimumRetentionDays };
                    windowsLogs.Add(windowsLog);
                }
            }
            catch (Exception ex)
            {
                this.Logger.LogError(ex.Message, ex);
            }

            return windowsLogs;
        }

        private List<EventLogEntryDuplicate> MapSystemEventLogEntries(EventLogEntryCollection entries)
        {
            List<EventLogEntryDuplicate> eventLogEntryDuplicates = new List<EventLogEntryDuplicate>();

            var enumarator = entries.GetEnumerator();

            while (enumarator.MoveNext())
            {
                EventLogEntry eventLogEntry = (EventLogEntry)enumarator.Current;
                eventLogEntryDuplicates.Add(new EventLogEntryDuplicate()
                {
                    Category = eventLogEntry.Category,
                    Data = eventLogEntry.Data,
                    CategoryNumber = eventLogEntry.CategoryNumber,
                    EntryType = (EventLogEntryTypeDuplicate)eventLogEntry.EntryType,
                    Index = eventLogEntry.Index,
                    InstanceId = eventLogEntry.InstanceId,
                    MachineName = eventLogEntry.MachineName,
                    Message = eventLogEntry.Message,
                    ReplacementStrings = eventLogEntry.ReplacementStrings,
                    Source = eventLogEntry.Source,
                    TimeGenerated = eventLogEntry.TimeGenerated,
                    TimeWritten = eventLogEntry.TimeWritten,
                    UserName = eventLogEntry.UserName,
                });
            }

            return eventLogEntryDuplicates;
        }

        private string GetProcessOwner(Process process)
        {
            return this.Win32APIClient.GetProcessUser(process);
        }
    }
}
