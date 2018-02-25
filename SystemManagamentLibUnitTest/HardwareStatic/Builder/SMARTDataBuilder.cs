using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.HardwareStatic.Analyzer;
using SystemManagament.Monitor.HardwareStatic.Model.Components.Analyzed;
using SystemManagament.Monitor.HardwareStatic.Model.CustomProperties.Enums;

namespace SystemMonitorLibUnitTest.HardwareStatic.Builder
{
    public class SMARTDataBuilder
    {
        private SMARTData smartData;

        public SMARTDataBuilder()
        {
            this.smartData = new SMARTData();
        }

        public static implicit operator SMARTData(SMARTDataBuilder smartDataBuilder)
        {
            return smartDataBuilder.Build();
        }

        public SMARTDataBuilder WithInstanceName(string instanceName)
        {
            this.smartData.InstanceName = instanceName;
            return this;
        }

        public SMARTDataBuilder WithPredictFailure(string predictFailure)
        {
            this.smartData.PredictFailure = predictFailure;
            return this;
        }

        public SMARTDataBuilder WithAttribute(int attributeKey, int current, int worst, int threshold, int raw, SmartDataAttributeStatusEnum status)
        {
            SmartAttributesDictionary smartAttributesDictionary = new SmartAttributesDictionary();

            var newAttribute = smartAttributesDictionary.Attributes.Where(x => x.Key == attributeKey).First();
            this.smartData.Attributes.Add(newAttribute.Key, newAttribute.Value);
            var attribute = this.smartData.Attributes[newAttribute.Key];
            attribute.Current = current;
            attribute.Worst = worst;
            attribute.Threshold = threshold;
            attribute.Raw = raw;
            attribute.Status = status;

            return this;
        }

        public SMARTData Build()
        {
            return this.smartData;
        }
    }
}
