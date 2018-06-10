using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemManagament.Client.WPF.WorkstationMonitorService;

namespace SystemManagament.Client.WPF.Comparer
{
    public class NetworkAdapterStaticComparer : IEqualityComparer<NetworkAdapter>
    {
        public bool Equals(NetworkAdapter x, NetworkAdapter y)
        {
            return x.Caption == y.Caption
                && x.Description == y.Description
                && x.Name == y.Name
                && x.Status == y.Status
                && x.ActiveMaximumTransmissionUnit.Value == y.ActiveMaximumTransmissionUnit.Value
                && x.ComponentID == y.ComponentID
                && x.ConnectorPresent == y.ConnectorPresent
                && x.DeviceID == y.DeviceID
                && x.DeviceName == y.DeviceName
                && x.DriverDate == y.DriverDate
                && x.DriverDescription == y.DriverDescription
                && x.DriverName == y.DriverName
                && x.DriverProvider == y.DriverProvider
                && x.DriverVersionString == y.DriverVersionString
                && x.InterfaceDescription == y.InterfaceDescription
                && x.NdisMedium == y.NdisMedium
                && x.NdisPhysicalMedium == y.NdisPhysicalMedium
                && x.PermanentAddress == y.PermanentAddress
                && x.Virtual == y.Virtual
                && x.InterfaceName == y.InterfaceName;
        }

        public int GetHashCode(NetworkAdapter obj)
        {
            return obj.GetHashCode();
        }
    }
}
