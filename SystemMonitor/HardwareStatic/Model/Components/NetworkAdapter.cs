using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using SystemMonitor.HardwareStatic.Model.Components.Abstract;
using SystemMonitor.HardwareStatic.Model.CustomProperties;
using SystemMonitor.HardwareStatic.Model.CustomProperties.Enum;
using SystemMonitor.HardwareStatic.WMI;

namespace SystemMonitor.HardwareStatic.Model.Components
{
    public class NetworkAdapter : HardwareComponent
    {
        // based on docs: https://msdn.microsoft.com/en-us/library/aa394216(v=vs.85).aspx
        public UnitValue ActiveMaximumTransmissionUnit { get; private set; }

        public string ComponentID { get; private set; }

        public string ConnectorPresent { get; private set; }

        public string DeviceID { get; private set; }

        public string DeviceName { get; private set; }

        public string DriverDate { get; private set; }

        public string DriverDescription { get; private set; }

        public string DriverName { get; private set; }

        public string DriverProvider { get; private set; }

        public string DriverVersionString { get; private set; }

        public string InterfaceDescription { get; private set; }

        public string InterfaceName { get; private set; }

        public string NdisMedium { get; private set; }

        public string NdisPhysicalMedium { get; private set; }

        public string PermanentAddress { get; private set; }

        public string Virtual { get; private set; }

        public override List<ManagementObject> GetManagementObjectsForHardwareComponent(IWMIClient wMIClient)
        {
            return wMIClient.RetriveListOfObjectsByExecutingWMIQuery(ConstStringHardwareStatic.WMI_NAMESPACE_ROOT_STANDARD_CIMV2, ConstStringHardwareStatic.WMI_QUERY_NETWORK_ADAPTER);
        }

        public override HardwareComponent ExtractData(ManagementObject managementObject)
        {
            NetworkAdapter networkAdapter = new NetworkAdapter();
            networkAdapter.ActiveMaximumTransmissionUnit = new UnitValue(Unit.B, managementObject[ConstStringHardwareStatic.NETWORK_ADAPTER_MAXIMUM_MTU]?.ToString() ?? string.Empty);
            networkAdapter.Caption = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_CAPTION]?.ToString() ?? string.Empty;
            networkAdapter.ComponentID = managementObject[ConstStringHardwareStatic.NETWORK_ADAPTER_COMPONENT_ID]?.ToString() ?? string.Empty;
            networkAdapter.ConnectorPresent = managementObject[ConstStringHardwareStatic.NETWORK_ADAPTER_CONNECTOR_PRESENT]?.ToString() ?? string.Empty;
            networkAdapter.Description = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_DESCRIPTION]?.ToString() ?? string.Empty;
            networkAdapter.DeviceID = managementObject[ConstStringHardwareStatic.NETWORK_ADAPTER_DEVICE_ID]?.ToString() ?? string.Empty;
            networkAdapter.DeviceName = managementObject[ConstStringHardwareStatic.NETWORK_ADAPTER_DRIVER_NAME]?.ToString() ?? string.Empty;
            networkAdapter.DriverDate = managementObject[ConstStringHardwareStatic.NETWORK_ADAPTER_DRIVER_DATE]?.ToString() ?? string.Empty;
            networkAdapter.DriverDescription = managementObject[ConstStringHardwareStatic.NETWORK_ADAPTER_DRIVER_DESCRIPTION]?.ToString() ?? string.Empty;
            networkAdapter.DriverName = managementObject[ConstStringHardwareStatic.NETWORK_ADAPTER_DRIVER_NAME]?.ToString() ?? string.Empty;
            networkAdapter.DriverProvider = managementObject[ConstStringHardwareStatic.NETWORK_ADAPTER_DRIVER_PROVIDER]?.ToString() ?? string.Empty;
            networkAdapter.DriverVersionString = managementObject[ConstStringHardwareStatic.NETWORK_ADAPTER_DRIVER_VERSION_STRING]?.ToString() ?? string.Empty;
            networkAdapter.InterfaceDescription = managementObject[ConstStringHardwareStatic.NETWORK_ADAPTER_INTERFACE_DESCRIPTION]?.ToString() ?? string.Empty;
            networkAdapter.InterfaceName = managementObject[ConstStringHardwareStatic.NETWORK_ADAPTER_INTERFACE_NAME]?.ToString() ?? string.Empty;
            networkAdapter.Name = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_NAME]?.ToString() ?? string.Empty;

            if (managementObject[ConstStringHardwareStatic.NETWORK_ADAPTER_NDIS_MEDIUM] != null)
            {
                networkAdapter.NdisMedium = ((NdisMediumEnum)((uint)managementObject[ConstStringHardwareStatic.NETWORK_ADAPTER_NDIS_MEDIUM])).ToString();
            }
            else
            {
                networkAdapter.NdisMedium = string.Empty;
            }

            if (managementObject[ConstStringHardwareStatic.NETWORK_ADAPTER_NDIS_PHYSICAL_MEDIUM] != null)
            {
                networkAdapter.NdisPhysicalMedium = ((NdisPhysicalMediumEnum)((uint)managementObject[ConstStringHardwareStatic.NETWORK_ADAPTER_NDIS_PHYSICAL_MEDIUM])).ToString();
            }
            else
            {
                networkAdapter.NdisPhysicalMedium = string.Empty;
            }

            networkAdapter.PermanentAddress = managementObject[ConstStringHardwareStatic.NETWORK_ADAPTER_PERMANENT_ADDRESS]?.ToString() ?? string.Empty;
            networkAdapter.Status = managementObject[ConstStringHardwareStatic.HARDWARE_COMPONENT_STATUS]?.ToString() ?? string.Empty;
            networkAdapter.Virtual = managementObject[ConstStringHardwareStatic.NETWORK_ADAPTER_VIRTUAL]?.ToString() ?? string.Empty;

            return networkAdapter;
        }
    }
}
