using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using SystemMonitor;
using SystemMonitor.HardwareDynamic.Model;
using SystemMonitor.HardwareStatic.Model;
using System.ServiceProcess;
using Microsoft.Win32;
using SystemMonitor.SoftwareStatic.Model;
using SystemMonitor.SoftwareStatic.Model.Components;
using System.Diagnostics;
using SystemMonitor.SoftwareDynamic.Model;

namespace SystemMonitorLibTest
{
    class Program
    {
        public static WorkstationMonitor monitor = new WorkstationMonitor();

        static void Main(string[] args)
        {
            HardwareDynamicData hardwareDynamicData = monitor.GetHardwareDynamicData();
            HardwareStaticData hardwareStaticData = monitor.GetHardwareStaticData();
            SoftwareStaticData softwareStaticData = monitor.GetSoftwareStaticData();
            SoftwareDynamicData softwareDynamicData = monitor.GetSoftwareDynamicData();
            //foreach (var item in softwareStaticData.InstalledProgram)
            //{
            //    Console.WriteLine(item.Name);
            //}

            //PrintProperties(data);
            Timer aTimer = new Timer();
            //aTimer.Elapsed += new ElapsedEventHandler(OnTimedEventProcessor);
            //aTimer.Elapsed += new ElapsedEventHandler(OnTimedEventProcess);
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEventGPU);
            aTimer.Interval = 500;
            aTimer.Enabled = true;
            while (Console.Read() != 'q') ;
            //Console.ReadLine();
        }

        private static void OnTimedEventProcessor(object source, ElapsedEventArgs e)
        {
            var data = monitor.GetHardwareDynamicData();
            Console.WriteLine("Load: value: " + data.Processor.First().Load.First().Value + data.Processor.First().Load.First().Unit);
            //Console.WriteLine("Clock: value: " + data.Processor.First().Clock.First().Value + "max: " + data.Processor.First().Clock.First().MaxValue);
        }

        private static void OnTimedEventProcess(object source, ElapsedEventArgs e)
        {
            var data = monitor.GetSoftwareDynamicData();
            Console.WriteLine("Process memory size: " + data.WindowsProcess.First().MemorySize.Value + data.WindowsProcess.First().MemorySize.Unit);
            //Console.WriteLine("Clock: value: " + data.Processor.First().Clock.First().Value + "max: " + data.Processor.First().Clock.First().MaxValue);
        }

        private static void OnTimedEventGPU(object source, ElapsedEventArgs e)
        {
            var data = monitor.GetHardwareDynamicData();
            Console.WriteLine("Clock: " + data.VideoController.First().Clock.First().Value +
                data.VideoController.First().Clock.First().Unit);
            Console.WriteLine("Temp: " + data.VideoController.First().Temperature.First().Value +
                data.VideoController.First().Temperature.First().Unit);
        }

        public static void PrintProperties(object obj)
        {
            PrintProperties(obj, 0);
        }
        public static void PrintProperties(object obj, int indent)
        {
            if (obj == null)
                return;
            string indentString = new string(' ', indent);
            Type objType = obj.GetType();
            if (objType.Name == "UnitValue")
            {
                var unit = objType.GetField("Unit");
                var value = objType.GetField("Value");
                Console.WriteLine("{0} {1}", value.GetValue(obj), unit.GetValue(obj));
            }

            PropertyInfo[] properties = objType.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                object propValue = property.GetValue(obj, null);
                if (property.PropertyType.Assembly == objType.Assembly && !property.PropertyType.IsEnum)
                {
                    Console.WriteLine("{0}{1}:", indentString, property.Name);
                    PrintProperties(propValue, indent + 2);
                }
                else
                {
                    Console.WriteLine("{0}{1}: {2}", indentString, property.Name, propValue);
                }
            }
        }
    }
}
