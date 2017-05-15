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
    public class Should_ExtractProcessorDataCorrectly_When_AllPropertiesAreNull_Source : IEnumerable<object[]>
    {
        private readonly List<object[]> data = new List<object[]>
        {
            new object[]
            {
                           new ManagamentObjectBuilder()
                                .WithPathNamespace(@"\\.\root\cimv2")
                                .WithPathClassName("Win32_Processor")
                                .PrepareManagamentObject()
                                .WithProperty(ConstStringHardwareStatic.PROCESSOR_ADDRESS_WIDTH, null)
                                .WithProperty(ConstStringHardwareStatic.PROCESSOR_ARCHITECTURE, null)
                                .WithProperty(ConstStringHardwareStatic.PROCESSOR_CAPTION, null)
                                .WithProperty(ConstStringHardwareStatic.PROCESSOR_DATA_WIDTH, null)
                                .WithProperty(ConstStringHardwareStatic.PROCESSOR_DESCRIPTION, null)
                                .WithProperty(ConstStringHardwareStatic.PROCESSOR_BUS_SPEED, null)
                                .WithProperty(ConstStringHardwareStatic.PROCESSOR_MANUFACTURER, null)
                                .WithProperty(ConstStringHardwareStatic.PROCESSOR_MAX_CLOCK_SPEED, null)
                                .WithProperty(ConstStringHardwareStatic.PROCESSOR_NAME, null)
                                .WithProperty(ConstStringHardwareStatic.PROCESSOR_NUMBER_OF_CORES, null)
                                .WithProperty(ConstStringHardwareStatic.PROCESSOR_NUMBER_OF_LOGICAL_PROCESSORS, null)
                                .WithProperty(ConstStringHardwareStatic.PROCESSOR_ID, null)
                                //.WithProperty(ConstStringHardwareStatic.PROCESSOR_SERIAL_NUMBER, null)
                                .WithProperty(ConstStringHardwareStatic.PROCESSOR_SOCKET_DESIGNATION, null)
                                .WithProperty(ConstStringHardwareStatic.PROCESSOR_STEPPING, null)
                                //.WithProperty(ConstStringHardwareStatic.PROCESSOR_THREAD_COUNT, null)
                                .WithProperty(ConstStringHardwareStatic.PROCESSOR_UNIQUE_ID, null)
                                .Build(),
                           new List<ManagementObject>(),
                           18
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
