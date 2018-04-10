using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
        private WorkstationMonitorServiceClient client;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //creating the object of WCF service client       
                //client = new WorkstationMonitorServiceClient("NetTcpBinding_IWorkstationMonitorService");

                //var dynamic1 = client.ReadDiskDynamicData();
                //var dynamic2 = client.ReadMainBoardDynamicData();
                //var dynamic3 = client.ReadMemoryDynamicData();
                //var dynamic4 = client.ReadProcessorDynamicData();
                //var dynamic5 = client.ReadVideoControllerDynamicData();
                //var dynamic6 = client.ReadWindowsLogDynamicData();
                //var dynamic7 = client.ReadWindowsProcessDynamicData();
                //var dynamic8 = client.ReadWindowsServiceDynamicData();
                var hardwarestatic = client.ReadHardwareStaticData();
                //var hardwaredynamic = client.ReadHardwareDynamicData();
                //var softwareStatic = client.ReadSoftwareStaticData();
                //var dynamicData = client.ReadSoftwareDynamicData();


                Timer aTimer = new Timer();
                //aTimer.Elapsed += new ElapsedEventHandler(OnTimedEventProcessor);
                //aTimer.Elapsed += new ElapsedEventHandler(OnTimedEventProcess);
                //aTimer.Elapsed += new ElapsedEventHandler(OnTimedEventProcessor);
                aTimer.Interval = 500;
                aTimer.Enabled = true;
                //while (Console.Read() != 'q') ;


                //MessageBox.Show("ok");
            }
            catch(CommunicationException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //private void OnTimedEventProcessor(object source, ElapsedEventArgs e)
        //{


        //    var data = new WorkstationMonitorServiceClient("NetTcpBinding_IWorkstationMonitorService").ReadMemoryDynamicData();

        //    this.Dispatcher.Invoke(() =>
        //    {
        //        this.textBlock1.Text += "Temperature: value: " + data.First().Data.First().MaxValue + data.First().Data.First().Unit + "\n";
        //        //this.textBlock1.Text += "Clock: value: " + data.First().Clock.First().MaxValue + data.First().Clock.First().Unit + "\n";

        //    });


        //}
    }
}
