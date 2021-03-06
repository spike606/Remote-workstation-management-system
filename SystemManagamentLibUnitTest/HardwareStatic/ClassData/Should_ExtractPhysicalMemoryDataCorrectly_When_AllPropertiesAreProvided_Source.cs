﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.HardwareStatic;
using SystemManagament.Monitor.HardwareStatic.Model.CustomProperties;
using SystemManagament.Monitor.HardwareStatic.Model.CustomProperties.Enums;
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
                                .WithProperty(ConstString.MEMORY_BANK_LABEL, "BANK 0")
                                .WithProperty(ConstString.MEMORY_CAPACITY, ulong.Parse("4294967296"))
                                .WithProperty(ConstString.COMPONENT_CAPTION, "Pamięć fizyczna")
                                .WithProperty(ConstString.MEMORY_CONFIGURED_CLOCK_SPEED, uint.Parse("1600"))
                                .WithProperty(ConstString.MEMORY_CONFIGURED_VOLTAGE, uint.Parse("0"))
                                .WithProperty(ConstString.MEMORY_DATA_WIDTH, ushort.Parse("64"))
                                .WithProperty(ConstString.COMPONENT_DESCRIPTION, "Pamięć fizyczna")
                                .WithProperty(ConstString.MEMORY_DEVICE_LOCATOR, "DIMM0")
                                .WithProperty(ConstString.MEMORY_MANUFACTURER, "Unknown")
                                .WithProperty(ConstString.MEMORY_MAX_VOLTAGE, uint.Parse("0"))
                                .WithProperty(ConstString.MEMORY_MEMORY_TYPE, ushort.Parse("24"))
                                .WithProperty(ConstString.MEMORY_MIN_VOLTAGE, uint.Parse("0"))
                                .WithProperty(ConstString.COMPONENT_NAME, "Pamięć fizyczna")
                                .WithProperty(ConstString.MEMORY_PART_NUMBER, "RMT3160ED58E9W1600")
                                .WithProperty(ConstString.MEMORY_SERIAL_NUMBER, "43752667")
                                .WithProperty(ConstString.COMPONENT_STATUS, "OK")
                                .WithProperty(ConstString.MEMORY_TOTAL_WIDTH, ushort.Parse("64"))
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
