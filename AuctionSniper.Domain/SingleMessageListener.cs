using AuctionSniper.Fakes.XmppServer;

namespace AuctionSniper.Domain
{
    public class SingleMessageListener : IMessageListener
    {
        public Message Message { get; set; }
        public event IMessageListenerEventHandler ProcessMessage;
        public void InvokeProcessMessage(MessageListenerEventArgs mle)
        {
            throw new System.NotImplementedException();
        }
    }
}