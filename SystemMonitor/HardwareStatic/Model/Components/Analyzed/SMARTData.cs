using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.Components.Abstract;
using SystemMonitor.HardwareStatic.Model.CustomProperties;
using SystemMonitor.HardwareStatic.Model.CustomProperties.Attributes;
using SystemMonitor.HardwareStatic.Model.CustomProperties.Enums;
using SystemMonitor.HardwareStatic.WMI;

namespace SystemMonitor.HardwareStatic.Model.Components.Analyzed
{
    public class SMARTData
    {
        public string InstanceName { get; set; }

        public string PredictFailure { get; set; }

        public Dictionary<int, SmartDataAttribute> Attributes { get; set; } = new Dictionary<int, SmartDataAttribute>();

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            SMARTData other = (SMARTData)obj;

            return this.InstanceName.Equals(other.InstanceName) &&
                this.PredictFailure.Equals(other.PredictFailure) &&
                this.Attributes.All(e => other.Attributes.Contains(e)) &&
                other.Attributes.All(e => this.Attributes.Contains(e));
        }

        public override int GetHashCode()
        {
            return new { this.InstanceName, this.PredictFailure, this.Attributes }.GetHashCode();
        }
    }
}
