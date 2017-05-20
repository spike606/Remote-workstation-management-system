using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic;
using SystemMonitor.HardwareStatic.Model.CustomProperties.Enum;
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
                                .WithProperty(ConstStringHardwareStatic.PROCESSOR_ADDRESS_WIDTH, ushort.Parse("64"))
                                .WithProperty(ConstStringHardwareStatic.PROCESSOR_ARCHITECTURE, ushort.Parse("9"))
                                .WithProperty(ConstStringHardwareStatic.PROCESSOR_CAPTION, "Intel64 Family 6 Model 58 Stepping 9")
                                .WithProperty(ConstStringHardwareStatic.PROCESSOR_DATA_WIDTH, ushort.Parse("64"))
                                .WithProperty(ConstStringHardwareStatic.PROCESSOR_DESCRIPTION, "Intel64 Family 6 Model 58 Stepping 9")
                                .WithProperty(ConstStringHardwareStatic.PROCESSOR_BUS_SPEED, uint.Parse("100"))
                                .WithProperty(ConstStringHardwareStatic.PROCESSOR_MANUFACTURER, "GenuineIntel")
                                .WithProperty(ConstStringHardwareStatic.PROCESSOR_MAX_CLOCK_SPEED, uint.Parse("2601"))
                                .WithProperty(ConstStringHardwareStatic.PROCESSOR_NAME, "Intel(R) Core(TM) i5-3230M CPU @ 2.60GHz")
                                .WithProperty(ConstStringHardwareStatic.PROCESSOR_NUMBER_OF_CORES, uint.Parse("2"))
                                .WithProperty(ConstStringHardwareStatic.PROCESSOR_NUMBER_OF_LOGICAL_PROCESSORS, uint.Parse("4"))
                                .WithProperty(ConstStringHardwareStatic.PROCESSOR_ID, "BFEBFBFF000306A9")
                                //.WithProperty(ConstStringHardwareStatic.PROCESSOR_SERIAL_NUMBER, "To Be Filled By O.E.M")
                                .WithProperty(ConstStringHardwareStatic.PROCESSOR_SOCKET_DESIGNATION, "U3E1")
                                .WithProperty(ConstStringHardwareStatic.PROCESSOR_STEPPING, "9")
                                //.WithProperty(ConstStringHardwareStatic.PROCESSOR_THREAD_COUNT, uint.Parse("4"))
                                .WithProperty(ConstStringHardwareStatic.PROCESSOR_UNIQUE_ID, "BFEBFBF")
                                .Build(),
                           new List<ManagementObject>()
                            {
                               new ManagamentObjectBuilder()
                                .WithPathNamespace(@"\\.\root\cimv2")
                                .WithPathClassName("Win32_CacheMemory")
                                .PrepareManagamentObject()
                                .WithProperty(ConstStringHardwareStatic.PROCESSOR_CACHE_SIZE, uint.Parse("32"))
                                .WithProperty(ConstStringHardwareStatic.PROCESSOR_CACHE_SPEED, uint.Parse("2601"))
                                .WithProperty(ConstStringHardwareStatic.PROCESSOR_CACHE_LEVEL, CacheLevelEnum.L1)
                                .Build(),
                               new ManagamentObjectBuilder()
                                .WithPathNamespace(@"\\.\root\cimv2")
                                .WithPathClassName("Win32_CacheMemory")
                                .PrepareManagamentObject()
                                .WithProperty(ConstStringHardwareStatic.PROCESSOR_CACHE_SIZE, uint.Parse("32"))
                                .WithProperty(ConstStringHardwareStatic.PROCESSOR_CACHE_SPEED, uint.Parse("2601"))
                                .WithProperty(ConstStringHardwareStatic.PROCESSOR_CACHE_LEVEL, CacheLevelEnum.L1)
                                .Build(),
                               new ManagamentObjectBuilder()
                                .WithPathNamespace(@"\\.\root\cimv2")
                                .WithPathClassName("Win32_CacheMemory")
                                .PrepareManagamentObject()
                                .WithProperty(ConstStringHardwareStatic.PROCESSOR_CACHE_SIZE, uint.Parse("256"))
                                .WithProperty(ConstStringHardwareStatic.PROCESSOR_CACHE_SPEED, uint.Parse("2601"))
                                .WithProperty(ConstStringHardwareStatic.PROCESSOR_CACHE_LEVEL, CacheLevelEnum.L2)
                                .Build(),
                               new ManagamentObjectBuilder()
                                .WithPathNamespace(@"\\.\root\cimv2")
                                .WithPathClassName("Win32_CacheMemory")
                                .PrepareManagamentObject()
                                .WithProperty(ConstStringHardwareStatic.PROCESSOR_CACHE_SIZE, uint.Parse("4096"))
                                .WithProperty(ConstStringHardwareStatic.PROCESSOR_CACHE_SPEED, uint.Parse("2601"))
                                .WithProperty(ConstStringHardwareStatic.PROCESSOR_CACHE_LEVEL, CacheLevelEnum.L3)
                                .Build()
                           },
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
