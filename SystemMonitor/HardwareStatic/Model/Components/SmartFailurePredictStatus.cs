﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.Components.Abstract;
using SystemMonitor.Shared.WMI;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class SmartFailurePredictStatus : HardwareStaticComponent
    {
        public string PredictFailure { get; set; }

        public string InstanceName { get; set; }

        public override HardwareStaticComponent ExtractData(ManagementObject managementObject)
        {
            SmartFailurePredictStatus smartFailurePredictStatus = new SmartFailurePredictStatus();
            smartFailurePredictStatus.Caption = string.Empty;
            smartFailurePredictStatus.Description = string.Empty;
            smartFailurePredictStatus.InstanceName = managementObject[ConstString.SMART_INSTANCE_NAME]?.ToString() ?? string.Empty;
            smartFailurePredictStatus.Name = string.Empty;
            smartFailurePredictStatus.PredictFailure = managementObject[ConstString.SMART_PREDICT_FAILURE]?.ToString() ?? string.Empty;
            smartFailurePredictStatus.Status = string.Empty;
            return smartFailurePredictStatus;
        }

        public override List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstString.WMI_NAMESPACE_ROOT_WMI, ConstString.WMI_QUERY_SMART_STATUS);
        }
    }
}
