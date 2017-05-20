using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic;
using SystemMonitorLibUnitTest.HardwareStatic.Builder;

namespace SystemMonitorLibUnitTest.HardwareStatic.ClassData
{
    public class Should_ExtractPhysicalMemoryDataCorrectly_When_AllPropertiesAreNull_Source : IEnumerable<object[]>
    {
        private readonly List<object[]> data = new List<object[]>
        {
            new object[]
            {
                           new ManagamentObjectBuilder()
                                .WithPathNamespace(@"\\.\root\cimv2")
                                .WithPathClassName("Win32_PhysicalMemory")
                                .PrepareManagamentObject()
                                .WithProperty(ConstStringHardwareStatic.MEMORY_BANK_LABEL, null)
                                .WithProperty(ConstStringHardwareStatic.MEMORY_CAPACITY, null)
                                .WithProperty(ConstStringHardwareStatic.MEMORY_CAPTION, null)
                                .WithProperty(ConstStringHardwareStatic.MEMORY_CONFIGURED_CLOCK_SPEED, null)
                                .WithProperty(ConstStringHardwareStatic.MEMORY_CONFIGURED_VOLTAGE, null)
                                .WithProperty(ConstStringHardwareStatic.MEMORY_DATA_WIDTH, null)
                                .WithProperty(ConstStringHardwareStatic.MEMORY_DESCRIPTION, null)
                                .WithProperty(ConstStringHardwareStatic.MEMORY_DEVICE_LOCATOR, null)
                                .WithProperty(ConstStringHardwareStatic.MEMORY_MANUFACTURER, null)
                                .WithProperty(ConstStringHardwareStatic.MEMORY_MAX_VOLTAGE, null)
                                .WithProperty(ConstStringHardwareStatic.MEMORY_MEMORY_TYPE, null)
                                .WithProperty(ConstStringHardwareStatic.MEMORY_MIN_VOLTAGE, null)
                                .WithProperty(ConstStringHardwareStatic.MEMORY_NAME, null)
                                .WithProperty(ConstStringHardwareStatic.MEMORY_PART_NUMBER, null)
                                .WithProperty(ConstStringHardwareStatic.MEMORY_SERIAL_NUMBER, null)
                                .WithProperty(ConstStringHardwareStatic.MEMORY_TOTAL_WIDTH, null)
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
