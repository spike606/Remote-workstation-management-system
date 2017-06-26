using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.CustomProperties.Attributes;
using SystemMonitor.HardwareStatic.Model.CustomProperties.Enums;

namespace SystemMonitor.HardwareStatic.Model.CustomProperties
{
    public class SmartDataAttribute
    {
        public SmartDataAttribute(string attributeName, bool isCriticalAttribute = false)
        {
            this.AttributeName = attributeName;
            this.IsCriticalAttribute = isCriticalAttribute;
        }

        public SmartDataAttribute(string attributeName, RawIdealEnum rawIdeal, bool isCriticalAttribute = false)
        {
            this.AttributeName = attributeName;
            this.RawIdeal = rawIdeal.GetEnumDescription();
            this.IsCriticalAttribute = isCriticalAttribute;
        }

        public string AttributeName { get; set; }

        public int Current { get; set; }

        public int Worst { get; set; }

        public int Threshold { get; set; }

        public int Raw { get; set; }

        public string RawIdeal { get; set; } = RawIdealEnum.NONE.GetEnumDescription();

        public bool IsCriticalAttribute { get; set; }

        public SmartDataAttributeStatusEnum Status { get; set; }

        public bool HasData
        {
            get
            {
                if (this.Current == 0 && this.Worst == 0 && this.Threshold == 0 && this.Raw == 0)
                {
                    return false;
                }

                return true;
            }
        }
    }
}
