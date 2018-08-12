using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;

namespace SystemManagament.Client.WPF.ViewModel.Messages
{
    public class MessageSender : IMessageSender
    {
        private string connectionError = "Can't connect to remote machine.";
        private string endpointNotFoundError = "Can't connect to remote machine. The remote endpoint could not be found. The endpoint may not be found or reachable because the remote endpoint is down, the remote endpoint is unreachable, or because the remote network is unreachable. ";
        private string timeoutError = "Cant't connect remote machine. Timeout was reached.";

        public void SendErrorMessageTimeout()
        {
            Messenger.Default.Send(new ErrorMessage()
            {
                Message = this.timeoutError
            });
        }

        public void SendErrorMessageEndpointNotFound()
        {
            Messenger.Default.Send(new ErrorMessage()
            {
                Message = this.endpointNotFoundError
            });
        }

        public void SendErrorMessage(string message)
        {
            Messenger.Default.Send(new ErrorMessage()
            {
                Message = this.connectionError + message
            });
        }

        public void SendCancelCommandMessage(string machineIdentifier)
        {
            Messenger.Default.Send(new CancelCommandMessage()
            {
                RecipientIdentifier = machineIdentifier,
            });
        }
    }
}
