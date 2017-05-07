using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HardwareMonitor;
using SystemMonitor.HardwareStatic.Model;

namespace SystemMonitorLibTest
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkstationMonitor monitor = new WorkstationMonitor();

            HardwareStaticData data = monitor.GetHardwareStaticData();

            Console.WriteLine(data.Processor.AddressWidth.Unit);
            Console.WriteLine(data.Processor.AddressWidth.Value);

            Console.ReadLine();
        }
    }
}
