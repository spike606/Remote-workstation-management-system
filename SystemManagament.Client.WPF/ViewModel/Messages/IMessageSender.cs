namespace SystemManagament.Client.WPF.ViewModel.Messages
{
    public interface IMessageSender
    {
        void SendErrorMessageTimeout();

        void SendErrorMessageEndpointNotFound();

        void SendErrorMessage(string message);

        void SendCancelCommandMessage(string machineIdentifier);
    }
}