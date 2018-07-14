using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using SystemManagament.Client.WPF.ViewModel.Messages;

namespace SystemManagament.Client.WPF.ViewModel
{
    public class NewMachineViewModel : ViewModelBase
    {
        private string newMachineUri = "net.tcp://localhost:8001/WorkstationMonitorService";
        private string newMachineName = "My local machine";
        private string newMachineCertificateSubjectName = "Certificate subject name";
        private string newMachineCertificateDnsName = "Certificate dns name";

        private NewMachineWindow newMachineWindow;

        public NewMachineViewModel()
        {
            Messenger.Default.Register<NotificationMessage>(this, this.NotificationMessageReceived);
            this.SendNewMachineMessageCommand = new RelayCommand(this.SendNewMachineMessage);
            this.CloseWindowCommand = new RelayCommand<Window>(this.CloseWindow);
        }

        public ICommand SendNewMachineMessageCommand { get; private set; }

        public RelayCommand<Window> CloseWindowCommand { get; private set; }

        public string NewMachineUri
        {
            get
            {
                return this.newMachineUri;
            }

            set
            {
                this.Set(() => this.NewMachineUri, ref this.newMachineUri, value);
            }
        }

        public string NewMachineName
        {
            get
            {
                return this.newMachineName;
            }

            set
            {
                this.Set(() => this.NewMachineName, ref this.newMachineName, value);
            }
        }

        public string NewMachineCertificateSubjectName
        {
            get
            {
                return this.newMachineCertificateSubjectName;
            }

            set
            {
                this.Set(() => this.NewMachineCertificateSubjectName, ref this.newMachineCertificateSubjectName, value);
            }
        }

        public string NewMachineCertificateDnsName
        {
            get
            {
                return this.newMachineCertificateDnsName;
            }

            set
            {
                this.Set(() => this.NewMachineCertificateDnsName, ref this.newMachineCertificateDnsName, value);
            }
        }

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "ShowNewMachineWindow")
            {
                this.newMachineWindow = new NewMachineWindow();
                this.newMachineWindow.DataContext = this;
                this.newMachineWindow.ShowDialog();
                this.newMachineWindow.Focus();
            }
        }

        private void SendNewMachineMessage()
        {
            Messenger.Default.Send(new NewMachineMessage()
            {
                MachineIdentifier = Guid.NewGuid().ToString(),
                MachineUri = this.NewMachineUri,
                MachineName = this.NewMachineName,
                NewMachineCertificateDnsName = this.NewMachineCertificateDnsName,
                NewMachineCertificateSubjectName = this.NewMachineCertificateSubjectName,
            });

            this.newMachineWindow.Close();
        }

        private void CloseWindow(Window window)
        {
            if (window != null)
            {
                window.Close();
            }
        }
    }
}
