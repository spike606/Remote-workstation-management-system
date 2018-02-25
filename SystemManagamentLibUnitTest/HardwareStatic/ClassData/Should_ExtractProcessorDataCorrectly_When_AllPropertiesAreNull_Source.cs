using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.HardwareStatic;
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
                                .WithProperty(ConstString.PROCESSOR_ADDRESS_WIDTH, null)
                                .WithProperty(ConstString.PROCESSOR_ARCHITECTURE, null)
                                .WithProperty(ConstString.COMPONENT_CAPTION, null)
                                .WithProperty(ConstString.PROCESSOR_DATA_WIDTH, null)
                                .WithProperty(ConstString.COMPONENT_DESCRIPTION, null)
                                .WithProperty(ConstString.PROCESSOR_BUS_SPEED, null)
                                .WithProperty(ConstString.PROCESSOR_MANUFACTURER, null)
                                .WithProperty(ConstString.PROCESSOR_MAX_CLOCK_SPEED, null)
                                .WithProperty(ConstString.COMPONENT_NAME, null)
                                .WithProperty(ConstString.PROCESSOR_NUMBER_OF_CORES, null)
                                .WithProperty(ConstString.PROCESSOR_NUMBER_OF_LOGICAL_PROCESSORS, null)
                                .WithProperty(ConstString.PROCESSOR_ID, null)
                                .WithProperty(ConstString.PROCESSOR_SERIAL_NUMBER, null)
                                .WithProperty(ConstString.PROCESSOR_SOCKET_DESIGNATION, null)
                                .WithProperty(ConstString.COMPONENT_STATUS, null)
                                .WithProperty(ConstString.PROCESSOR_STEPPING, null)
                                .WithProperty(ConstString.PROCESSOR_THREAD_COUNT, null)
                                .WithProperty(ConstString.PROCESSOR_UNIQUE_ID, null)
                                .Build(),
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
