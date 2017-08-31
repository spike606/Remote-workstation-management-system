using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.CustomProperties.Attributes;

namespace SystemMonitor.HardwareStatic.Model.CustomProperties.Enums
{
    internal enum DedupModeEnum
    {
        // Based on documentation: https://msdn.microsoft.com/en-us/library/windows/desktop/hh830604(v=vs.85).aspx
        Disabled,
        [EnumDescription("General Purpose")]
        GeneralPurpose,
        HyperV,
        Backup,
        [EnumDescription("Not Available")]
        NotAvailable
    }

    internal enum DriveTypeEnum
    {
        // Based on documentation: https://msdn.microsoft.com/en-us/library/windows/desktop/hh830604(v=vs.85).aspx
        Unknown,
        [EnumDescription("Invalid Root Path")]
        InvalidRootPath,
        Removable,
        Fixed,
        Remote,
        [EnumDescription("CD-ROM")]
        CDROM,
        [EnumDescription("RAM Disk")]
        RAMDisk
    }

    internal enum HealthStatusVolumeEnum
    {
        // Based on documentation: https://msdn.microsoft.com/en-us/library/windows/desktop/hh830604(v=vs.85).aspx
        Healthy,
        [EnumDescription("Scan Needed")]
        ScanNeeded,
        [EnumDescription("Spot Fix Needed")]
        SpotFixNeeded,
        [EnumDescription("Full Repair Needed")]
        FullRepairNeeded
    }

    internal enum HealthStatusDiskEnum
    {
        // Based on documentation: https://msdn.microsoft.com/en-us/library/windows/desktop/hh830493(v=vs.85).aspx
        [EnumDescription("Healthy - The disk is functioning normally.")]
        Healthy,
        [EnumDescription("Warning - The disk is still functioning, but has detected errors or issues that require administrator intervention.")]
        Warning,
        [EnumDescription("Unhealthy - The volume is not functioning, due to errors or failures. The volume needs immediate attention from an administrator.")]
        Unhealthy
    }

    internal enum OfflineReasonEnum
    {
        // Based on documentation: https://msdn.microsoft.com/en-us/library/windows/desktop/hh830493(v=vs.85).aspx
        [EnumDescription("Not applicable")]
        NotApplicable,
        [EnumDescription("Policy - The user requested the disk to be offline.")]
        Policy,
        [EnumDescription("RedundantPath - The disk is used for multi-path I/O.")]
        RedundantPath,
        [EnumDescription("Snapshot - The disk is a snapshot disk.")]
        Snapshot,
        [EnumDescription("Collision - There was a signature or identifier collision with another disk.")]
        Collision,
        [EnumDescription("Resource Exhaustion - There were insufficient resources to bring the disk online.")]
        ResourceExhaustion,
        [EnumDescription("Critical Write Failures - There were critical write failures on the disk.")]
        CriticalWriteFailures,
        [EnumDescription("Data Integrity Scan Required - A data integrity scan is required.")]
        DataIntegrityScanRequired
    }

    internal enum PartitionStyleEnum
    {
        // Based on documentation: https://msdn.microsoft.com/en-us/library/windows/desktop/hh830493(v=vs.85).aspx
        [EnumDescription("The partition style is unknown.")]
        Unknown,
        [EnumDescription("Master Boot Record (MBR)")]
        MBR,
        [EnumDescription("GUID Partition Table (GPT)")]
        GPT
    }
}
