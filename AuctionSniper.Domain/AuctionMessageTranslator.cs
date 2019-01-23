using AuctionSniper.Fakes.XmppServer;

namespace AuctionSniper.Domain
{
    public class AuctionMessageTranslator : IMessageListener
    {
        private readonly  string _sniperId;
        private readonly IAuctionEventListener _auctionEventListener;

        public AuctionMessageTranslator(string sniperId, IAuctionEventListener auctionEventListener)
        {
            _sniperId = sniperId;
            _auctionEventListener = auctionEventListener;
        }

        public Message Message { get; set; }
        public event IMessageListenerEventHandler ProcessMessage;
        public void InvokeProcessMessage(MessageListenerEventArgs mle)
        {
            throw new System.NotImplementedException();
        }
    }
}