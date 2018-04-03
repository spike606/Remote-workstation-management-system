using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SystemManagament.Client.WPF.WorkstationMonitorServiceReference;

namespace SystemManagament.Client.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //creating the object of WCF service client       
                WorkstationMonitorServiceClient client = new WorkstationMonitorServiceClient("NetTcpBinding_IWorkstationMonitorService");

                var dynamic1 = client.ReadDiskDynamicData();
                var dynamic2 = client.ReadMainBoardDynamicData();
                var dynamic3 = client.ReadMemoryDynamicData();
                var dynamic4 = client.ReadProcessorDynamicData();
                var dynamic5 = client.ReadVideoControllerDynamicData();
                var dynamic6 = client.ReadWindowsLogDynamicData();
                var dynamic7 = client.ReadWindowsProcessDynamicData();
                var dynamic8 = client.ReadWindowsServiceDynamicData();

                //var hardwarestatic = client.ReadHardwareStaticData();
                //var hardwaredynamic = client.ReadHardwareDynamicData();
                //var softwareStatic = client.ReadSoftwareStaticData();
                //var dynamicData = client.ReadSoftwareDynamicData();
                MessageBox.Show("ok");
            }
            catch(CommunicationException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
