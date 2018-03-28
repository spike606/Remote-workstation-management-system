using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.HardwareStatic.Model.CustomProperties.Attributes;
using SystemManagament.Monitor.HardwareStatic.Model.CustomProperties.Enums;

namespace SystemManagament.Monitor.HardwareStatic.Model.CustomProperties
{
    [DataContract]
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

        [DataMember]
        public string AttributeName { get; set; }

        [DataMember]
        public int Current { get; set; }

        [DataMember]
        public int Worst { get; set; }

        [DataMember]
        public int Threshold { get; set; }

        [DataMember]
        public int Raw { get; set; }

        [DataMember]
        public string RawIdeal { get; set; } = RawIdealEnum.NONE.GetEnumDescription();

        [DataMember]
        public bool IsCriticalAttribute { get; set; }

        [DataMember]
        public SmartDataAttributeStatusEnum Status { get; set; }

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

            SmartDataAttribute other = (SmartDataAttribute)obj;

            return this.AttributeName.Equals(other.AttributeName) &&
                this.Current.Equals(other.Current) &&
                this.Worst.Equals(other.Worst) &&
                this.Threshold.Equals(other.Threshold) &&
                this.Raw.Equals(other.Raw) &&
                this.RawIdeal.Equals(other.RawIdeal) &&
                this.IsCriticalAttribute.Equals(other.IsCriticalAttribute) &&
                this.Status.Equals(other.Status);
        }

        public override int GetHashCode()
        {
            return new
            {
                this.AttributeName,
                this.Current,
                this.Worst,
                this.Threshold,
                this.Raw,
                this.RawIdeal,
                this.IsCriticalAttribute,
                this.Status
            }.GetHashCode();
        }
    }
}
