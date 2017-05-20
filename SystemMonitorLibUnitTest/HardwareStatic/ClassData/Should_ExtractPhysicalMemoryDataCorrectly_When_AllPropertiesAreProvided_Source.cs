using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic;
using SystemMonitor.HardwareStatic.Model.CustomProperties;
using SystemMonitor.HardwareStatic.Model.CustomProperties.Enum;
using SystemMonitorLibUnitTest.HardwareStatic.Builder;

namespace SystemMonitorLibUnitTest.HardwareStatic.ClassData
{
    public class Should_ExtractPhysicalMemoryDataCorrectly_When_AllPropertiesAreProvided_Source : IEnumerable<object[]>
    {
        private readonly List<object[]> data = new List<object[]>
        {
            new object[]
            {
                           new ManagamentObjectBuilder()
                                .WithPathNamespace(@"\\.\root\cimv2")
                                .WithPathClassName("Win32_PhysicalMemory")
                                .PrepareManagamentObject()
                                .WithProperty(ConstStringHardwareStatic.MEMORY_BANK_LABEL, "BANK 0")
                                .WithProperty(ConstStringHardwareStatic.MEMORY_CAPACITY, ulong.Parse("4294967296"))
                                .WithProperty(ConstStringHardwareStatic.MEMORY_CAPTION, "Pamięć fizyczna")
                                .WithProperty(ConstStringHardwareStatic.MEMORY_CONFIGURED_CLOCK_SPEED, uint.Parse("1600"))
                                .WithProperty(ConstStringHardwareStatic.MEMORY_CONFIGURED_VOLTAGE, uint.Parse("0"))
                                .WithProperty(ConstStringHardwareStatic.MEMORY_DATA_WIDTH, ushort.Parse("64"))
                                .WithProperty(ConstStringHardwareStatic.MEMORY_DESCRIPTION, "Pamięć fizyczna")
                                .WithProperty(ConstStringHardwareStatic.MEMORY_DEVICE_LOCATOR, "DIMM0")
                                .WithProperty(ConstStringHardwareStatic.MEMORY_MANUFACTURER, "Unknown")
                                .WithProperty(ConstStringHardwareStatic.MEMORY_MAX_VOLTAGE, uint.Parse("0"))
                                .WithProperty(ConstStringHardwareStatic.MEMORY_MEMORY_TYPE, ushort.Parse("24"))
                                .WithProperty(ConstStringHardwareStatic.MEMORY_MIN_VOLTAGE, uint.Parse("0"))
                                .WithProperty(ConstStringHardwareStatic.MEMORY_NAME, "Pamięć fizyczna")
                                .WithProperty(ConstStringHardwareStatic.MEMORY_PART_NUMBER, "RMT3160ED58E9W1600")
                                .WithProperty(ConstStringHardwareStatic.MEMORY_SERIAL_NUMBER, "43752667")
                                .WithProperty(ConstStringHardwareStatic.MEMORY_TOTAL_WIDTH, ushort.Parse("64"))
                                .Build(),
                           16
            }
        };

        public IEnumerator<object[]> GetEnumerator()
        {
            return this.data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
