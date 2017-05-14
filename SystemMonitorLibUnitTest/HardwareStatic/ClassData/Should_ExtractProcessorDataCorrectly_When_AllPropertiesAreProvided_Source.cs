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
    public class Should_ExtractProcessorDataCorrectly_When_AllPropertiesAreProvided_Source : IEnumerable<object[]>
    {
        private readonly List<object[]> data = new List<object[]>
        {
            new object[] { new ManagamentObjectBuilder()
                                .WithProperty(ConstStringHardwareStatic.PROCESSOR_NAME, "Intel(R) Core(TM) i5-3230M CPU @ 2.60GHz")
                                .Build(),
                           new ManagamentObjectBuilder()
                                .WithProperty(ConstStringHardwareStatic.PROCESSOR_L1_CACHE_SIZE, uint.Parse("32"))
                                .Build()
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
