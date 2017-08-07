using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HardwareMonitor;
using SystemMonitor.HardwareDynamic.Model;
using SystemMonitor.HardwareStatic.Model;

namespace SystemMonitorLibTest
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkstationMonitor monitor = new WorkstationMonitor();
            HardwareDynamicData dynamicData = monitor.GetHardwareDynamicData();

            //HardwareStaticData data = monitor.GetHardwareStaticData();
            //PrintProperties(data);
            Console.ReadLine();
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
