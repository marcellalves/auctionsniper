using AuctionSniper.Domain;

namespace AuctionSniper.UI
{
    public class XmppAuction : IAuction
    {
        private object chat;

        public XmppAuction(object chat)
        {
            this.chat = chat;
        }

        public void Join()
        {
            throw new System.NotImplementedException();
        }
    }
}