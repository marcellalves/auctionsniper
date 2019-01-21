using AuctionSniper.Fakes.XmppServer;

namespace AuctionSniper.Domain
{
    public class AuctionMessageTranslator : IMessageListener
    {
        private object userName;
        private Domain.AuctionSniper auctionSniper;

        public AuctionMessageTranslator(object userName, AuctionSniper auctionSniper)
        {
            this.userName = userName;
            this.auctionSniper = auctionSniper;
        }

        public Message Message { get; set; }
        public event IMessageListenerEventHandler ProcessMessage;
        public void InvokeProcessMessage(MessageListenerEventArgs mle)
        {
            throw new System.NotImplementedException();
        }
    }
}