using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.HardwareStatic.Model.CustomProperties;

namespace SystemManagament.Monitor.HardwareStatic.Model.Components.Analyzed
{
    [DataContract]
    public class SMARTData
    {
        [DataMember]
        public string InstanceName { get; set; }

        [DataMember]
        public string PredictFailure { get; set; }

        [DataMember]
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
