using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Monitor.HardwareStatic.Model.Components.Abstract;
using SystemManagament.Monitor.HardwareStatic.Model.Components.Interface;
using SystemManagament.Monitor.HardwareStatic.Model.CustomProperties;
using SystemManagament.Monitor.HardwareStatic.Model.CustomProperties.Attributes;
using SystemManagament.Monitor.HardwareStatic.Model.CustomProperties.Enums;
using SystemManagament.Shared.WMI;

namespace SystemManagament.Monitor.HardwareStatic.Model.Components
{
    [DataContract]
    public class NetworkAdapter : HardwareStaticComponent, IHardwareStaticComponent<NetworkAdapter>
    {
        // based on docs: https://msdn.microsoft.com/en-us/library/hh968170(v=vs.85).aspx
        [DataMember]
        public UnitULongValue ActiveMaximumTransmissionUnit { get; private set; }

        [DataMember]
        public string ComponentID { get; private set; }

        [DataMember]
        public string ConnectorPresent { get; private set; }

        [DataMember]
        public string DeviceID { get; private set; }

        [DataMember]
        public string DeviceName { get; private set; }

        [DataMember]
        public string DriverDate { get; private set; }

        [DataMember]
        public string DriverDescription { get; private set; }

        [DataMember]
        public string DriverName { get; private set; }

        [DataMember]
        public string DriverProvider { get; private set; }

        [DataMember]
        public string DriverVersionString { get; private set; }

        [DataMember]
        public string InterfaceDescription { get; private set; }

        [DataMember]
        public string InterfaceName { get; private set; }

        [DataMember]
        public string NdisMedium { get; private set; }

        [DataMember]
        public string NdisPhysicalMedium { get; private set; }

        [DataMember]
        public string PermanentAddress { get; private set; }

        [DataMember]
        public string Virtual { get; private set; }

        public List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstString.WMI_NAMESPACE_ROOT_STANDARD_CIMV2, ConstString.WMI_QUERY_NETWORK_ADAPTER);
        }

        public List<NetworkAdapter> ExtractData(List<ManagementObject> managementObjectList)
        {
            List<NetworkAdapter> staticData = new List<NetworkAdapter>();

            foreach (var managementObject in managementObjectList)
            {
                NetworkAdapter networkAdapter = new NetworkAdapter();
                networkAdapter.ActiveMaximumTransmissionUnit = managementObject[ConstString.NETWORK_ADAPTER_MAXIMUM_MTU].TryGetUnitULongValue(Unit.B);
                networkAdapter.Caption = managementObject[ConstString.COMPONENT_CAPTION].TryGetStringValue();
                networkAdapter.ComponentID = managementObject[ConstString.NETWORK_ADAPTER_COMPONENT_ID].TryGetStringValue();
                networkAdapter.ConnectorPresent = managementObject[ConstString.NETWORK_ADAPTER_CONNECTOR_PRESENT].TryGetStringValue();
                networkAdapter.Description = managementObject[ConstString.COMPONENT_DESCRIPTION].TryGetStringValue();
                networkAdapter.DeviceID = managementObject[ConstString.NETWORK_ADAPTER_DEVICE_ID].TryGetStringValue();
                networkAdapter.DeviceName = managementObject[ConstString.NETWORK_ADAPTER_DRIVER_NAME].TryGetStringValue();
                networkAdapter.DriverDate = managementObject[ConstString.NETWORK_ADAPTER_DRIVER_DATE].TryGetStringValue();
                networkAdapter.DriverDescription = managementObject[ConstString.NETWORK_ADAPTER_DRIVER_DESCRIPTION].TryGetStringValue();
                networkAdapter.DriverName = managementObject[ConstString.NETWORK_ADAPTER_DRIVER_NAME].TryGetStringValue();
                networkAdapter.DriverProvider = managementObject[ConstString.NETWORK_ADAPTER_DRIVER_PROVIDER].TryGetStringValue();
                networkAdapter.DriverVersionString = managementObject[ConstString.NETWORK_ADAPTER_DRIVER_VERSION_STRING].TryGetStringValue();
                networkAdapter.InterfaceDescription = managementObject[ConstString.NETWORK_ADAPTER_INTERFACE_DESCRIPTION].TryGetStringValue();
                networkAdapter.InterfaceName = managementObject[ConstString.NETWORK_ADAPTER_INTERFACE_NAME].TryGetStringValue();
                networkAdapter.Name = managementObject[ConstString.COMPONENT_NAME].TryGetStringValue();

                if (managementObject[ConstString.NETWORK_ADAPTER_NDIS_MEDIUM] != null)
                {
                    networkAdapter.NdisMedium = ((NdisMediumEnum)((uint)managementObject[ConstString.NETWORK_ADAPTER_NDIS_MEDIUM])).GetEnumDescription();
                }
                else
                {
                    networkAdapter.NdisMedium = string.Empty;
                }

                if (managementObject[ConstString.NETWORK_ADAPTER_NDIS_PHYSICAL_MEDIUM] != null)
                {
                    networkAdapter.NdisPhysicalMedium = ((NdisPhysicalMediumEnum)((uint)managementObject[ConstString.NETWORK_ADAPTER_NDIS_PHYSICAL_MEDIUM])).ToString();
                }
                else
                {
                    networkAdapter.NdisPhysicalMedium = string.Empty;
                }

                networkAdapter.PermanentAddress = managementObject[ConstString.NETWORK_ADAPTER_PERMANENT_ADDRESS].TryGetStringValue();
                networkAdapter.Status = managementObject[ConstString.COMPONENT_STATUS].TryGetStringValue();
                networkAdapter.Virtual = managementObject[ConstString.NETWORK_ADAPTER_VIRTUAL].TryGetStringValue();

                staticData.Add(networkAdapter);
            }

            return staticData;
        }
    }
}
