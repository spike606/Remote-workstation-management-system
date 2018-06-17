using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.HardwareStatic.Analyzer;
using SystemManagament.Monitor.HardwareStatic.Model.Components.Abstract;
using SystemManagament.Monitor.HardwareStatic.Model.Components.Interface;
using SystemManagament.Shared.WMI;

namespace SystemManagament.Monitor.HardwareStatic.Model.Components
{
    [DataContract]
    public class PnPEntity : HardwareStaticComponent, IHardwareStaticComponent<PnPEntity>
    {
        // based on docs: https://msdn.microsoft.com/en-us/library/aa394353(v=vs.85).aspx
        [DataMember]
        public string DeviceID { get; private set; }

        [DataMember]
        public string Manufacturer { get; private set; }

        [DataMember]
        public string ConfigManagerErrorCodeString { get; private set; }

        [DataMember]
        public uint ConfigManagerErrorCode { get; private set; }

        public List<PnPEntity> ExtractData(List<ManagementObject> managementObjectList)
        {
            List<PnPEntity> staticData = new List<PnPEntity>();

            foreach (var managementObject in managementObjectList)
            {
                PnPEntity pnPEntity = new PnPEntity();
                pnPEntity.Caption = managementObject[ConstString.COMPONENT_CAPTION].TryGetStringValue();
                pnPEntity.Description = managementObject[ConstString.COMPONENT_DESCRIPTION].TryGetStringValue();
                pnPEntity.DeviceID = managementObject[ConstString.PNP_ENTITY_DEVICE_ID].TryGetStringValue();
                pnPEntity.Manufacturer = managementObject[ConstString.PNP_ENTITY_MANUFACTURER].TryGetStringValue();
                pnPEntity.Name = managementObject[ConstString.COMPONENT_NAME].TryGetStringValue();
                pnPEntity.Status = managementObject[ConstString.COMPONENT_STATUS].TryGetStringValue();

                if (managementObject[ConstString.PNP_ERROR_CODE] != null)
                {
                    pnPEntity.ConfigManagerErrorCode = (uint)managementObject[ConstString.PNP_ERROR_CODE];

                    string errorCodeDescription;
                    if (PnPConfigManagerErrorCodeDictionary.Erros.TryGetValue(pnPEntity.ConfigManagerErrorCode, out errorCodeDescription))
                    {
                        pnPEntity.ConfigManagerErrorCodeString = errorCodeDescription;
                    }
                    else
                    {
                        pnPEntity.ConfigManagerErrorCodeString = string.Empty;
                    }
                }
                else
                {
                    pnPEntity.ConfigManagerErrorCodeString = string.Empty;
                }

                staticData.Add(pnPEntity);
            }

            return staticData;
        }

        public List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstString.WMI_NAMESPACE_ROOT_CIMV2, ConstString.WMI_QUERY_PNP_ENTITY);
        }
    }
}
