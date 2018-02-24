using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.HardwareStatic;
using SystemManagament.Monitor.HardwareStatic.Model.CustomProperties.Enums;
using SystemMonitorLibUnitTest.HardwareStatic.Builder;

namespace SystemMonitorLibUnitTest.HardwareStatic.ClassData
{
    public class Should_ExtractProcessorDataCorrectly_When_AllPropertiesAreProvided_Source : IEnumerable<object[]>
    {
        private readonly List<object[]> data = new List<object[]>
        {
            new object[]
            {
                           new ManagamentObjectBuilder()
                                .WithPathNamespace(@"\\.\root\cimv2")
                                .WithPathClassName("Win32_Processor")
                                .PrepareManagamentObject()
                                .WithProperty(ConstString.PROCESSOR_ADDRESS_WIDTH, ushort.Parse("64"))
                                .WithProperty(ConstString.PROCESSOR_ARCHITECTURE, ushort.Parse("9"))
                                .WithProperty(ConstString.COMPONENT_CAPTION, "Intel64 Family 6 Model 58 Stepping 9")
                                .WithProperty(ConstString.PROCESSOR_DATA_WIDTH, ushort.Parse("64"))
                                .WithProperty(ConstString.COMPONENT_DESCRIPTION, "Intel64 Family 6 Model 58 Stepping 9")
                                .WithProperty(ConstString.PROCESSOR_BUS_SPEED, uint.Parse("100"))
                                .WithProperty(ConstString.PROCESSOR_MANUFACTURER, "GenuineIntel")
                                .WithProperty(ConstString.PROCESSOR_MAX_CLOCK_SPEED, uint.Parse("2601"))
                                .WithProperty(ConstString.COMPONENT_NAME, "Intel(R) Core(TM) i5-3230M CPU @ 2.60GHz")
                                .WithProperty(ConstString.PROCESSOR_NUMBER_OF_CORES, uint.Parse("2"))
                                .WithProperty(ConstString.PROCESSOR_NUMBER_OF_LOGICAL_PROCESSORS, uint.Parse("4"))
                                .WithProperty(ConstString.PROCESSOR_ID, "BFEBFBFF000306A9")
                                .WithProperty(ConstString.PROCESSOR_SERIAL_NUMBER, "To Be Filled By O.E.M")
                                .WithProperty(ConstString.PROCESSOR_SOCKET_DESIGNATION, "U3E1")
                                .WithProperty(ConstString.COMPONENT_STATUS, "OK")
                                .WithProperty(ConstString.PROCESSOR_STEPPING, "9")
                                .WithProperty(ConstString.PROCESSOR_THREAD_COUNT, uint.Parse("4"))
                                .WithProperty(ConstString.PROCESSOR_UNIQUE_ID, "BFEBFBF")
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
