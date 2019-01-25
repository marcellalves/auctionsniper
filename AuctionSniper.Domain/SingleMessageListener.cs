using AuctionSniper.Fakes.XmppServer;

namespace AuctionSniper.Domain
{
    public class SingleMessageListener : IMessageListener
    {
        public Message Message { get; set; }

        public event IMessageListenerEventHandler ProcessMessage;
        
        public void InvokeProcessMessage(MessageListenerEventArgs mle)
        {
            var handler = ProcessMessage;
            if (handler != null) handler(this, mle);
        }
    }
}