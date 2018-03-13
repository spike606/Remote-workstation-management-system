using System;
using System.Collections.Generic;
using System.Linq;
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
            //creating the object of WCF service client       
            WorkstationMonitorServiceClient client = new WorkstationMonitorServiceClient("NetTcpBinding_IWorkstationMonitorService");

            //var softwareStatic = client.ReadSoftwareStaticData();
            var dynamicData = client.ReadSoftwareDynamicData();
            MessageBox.Show("ok");
        }
    }
}
