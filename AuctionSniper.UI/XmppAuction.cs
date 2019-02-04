using AuctionSniper.Domain;
using AuctionSniper.Fakes.XmppServer;

namespace AuctionSniper.UI
{
    public class XmppAuction : IAuction
    {
        private readonly Chat _chat;

        public XmppAuction(Chat chat)
        {
            _chat = chat;
        }

        public void Bid(int bidAmount)
        {
            _chat.SendMessage($"amount{SharedConstants.BID_COMMAND_FORMAT}");
        }

        public void Join()
        {
            _chat.SendMessage(SharedConstants.STATUS_JOINING);
        }
    }
}