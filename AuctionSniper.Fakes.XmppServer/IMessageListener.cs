namespace AuctionSniper.Fakes.XmppServer
{
    public interface IMessageListener
    {
        Message Message { get; set; }
        event IMessageListenerEventHandler ProcessMessage;
        void InvokeProcessMessage(MessageListenerEventArgs mle);
    }
}