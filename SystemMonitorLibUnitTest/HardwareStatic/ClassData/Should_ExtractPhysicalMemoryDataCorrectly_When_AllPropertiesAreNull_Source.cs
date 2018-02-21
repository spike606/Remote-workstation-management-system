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
                                .WithProperty(ConstString.MEMORY_BANK_LABEL, null)
                                .WithProperty(ConstString.MEMORY_CAPACITY, null)
                                .WithProperty(ConstString.COMPONENT_CAPTION, null)
                                .WithProperty(ConstString.MEMORY_CONFIGURED_CLOCK_SPEED, null)
                                .WithProperty(ConstString.MEMORY_CONFIGURED_VOLTAGE, null)
                                .WithProperty(ConstString.MEMORY_DATA_WIDTH, null)
                                .WithProperty(ConstString.COMPONENT_DESCRIPTION, null)
                                .WithProperty(ConstString.MEMORY_DEVICE_LOCATOR, null)
                                .WithProperty(ConstString.MEMORY_MANUFACTURER, null)
                                .WithProperty(ConstString.MEMORY_MAX_VOLTAGE, null)
                                .WithProperty(ConstString.MEMORY_MEMORY_TYPE, null)
                                .WithProperty(ConstString.MEMORY_MIN_VOLTAGE, null)
                                .WithProperty(ConstString.COMPONENT_NAME, null)
                                .WithProperty(ConstString.MEMORY_PART_NUMBER, null)
                                .WithProperty(ConstString.MEMORY_SERIAL_NUMBER, null)
                                .WithProperty(ConstString.COMPONENT_STATUS, null)
                                .WithProperty(ConstString.MEMORY_TOTAL_WIDTH, null)
                                .Build(),
                           17
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
