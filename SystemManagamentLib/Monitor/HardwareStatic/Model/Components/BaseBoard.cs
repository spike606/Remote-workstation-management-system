using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.HardwareStatic.Model.Components.Abstract;
using SystemManagament.Monitor.HardwareStatic.Model.Components.Interface;
using SystemManagament.Shared.WMI;

namespace SystemManagament.Monitor.HardwareStatic.Model.Components
{
    [DataContract]
    public class BaseBoard : HardwareStaticComponent, IHardwareStaticComponent<BaseBoard>
    {
        // based on docs: https://msdn.microsoft.com/en-us/library/aa394072(v=vs.85).aspx
        [DataMember]
        public string Manufacturer { get; private set; }

        [DataMember]
        public string Model { get; private set; }

        [DataMember]
        public string PartNumber { get; private set; }

        [DataMember]
        public string Product { get; private set; }

        [DataMember]
        public string SerialNumber { get; private set; }

        [DataMember]
        public string Version { get; private set; }

        public List<BaseBoard> ExtractData(List<ManagementObject> managementObjectList)
        {
            List<BaseBoard> staticData = new List<BaseBoard>();

            foreach (var managementObject in managementObjectList)
            {
                var baseBoard = new BaseBoard();
                baseBoard.Caption = managementObject[ConstString.COMPONENT_CAPTION].TryGetStringValue();
                baseBoard.Description = managementObject[ConstString.COMPONENT_DESCRIPTION].TryGetStringValue();
                baseBoard.Manufacturer = managementObject[ConstString.BASE_BOARD_MANUFACTURER].TryGetStringValue();
                baseBoard.Model = managementObject[ConstString.BASE_BOARD_MODEL].TryGetStringValue();
                baseBoard.Name = managementObject[ConstString.COMPONENT_NAME].TryGetStringValue();
                baseBoard.PartNumber = managementObject[ConstString.BASE_BOARD_PART_NUMBER].TryGetStringValue();
                baseBoard.Product = managementObject[ConstString.BASE_BOARD_PRODUCT].TryGetStringValue();
                baseBoard.SerialNumber = managementObject[ConstString.BASE_BOARD_SERIAL_NUMBER].TryGetStringValue();
                baseBoard.Status = managementObject[ConstString.COMPONENT_STATUS].TryGetStringValue();
                baseBoard.Version = managementObject[ConstString.BASE_BOARD_VERSION].TryGetStringValue();
                staticData.Add(baseBoard);
            }

            return staticData;
        }

        public List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstString.WMI_NAMESPACE_ROOT_CIMV2, ConstString.WMI_QUERY_BASE_BOARD);
        }
    }
}
