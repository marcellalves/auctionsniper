using System;

namespace AuctionSniper.Fakes.XmppServer
{
    public class ChatManager
    {
        public event EventHandler ChatCreated;

        public Chat CreateChat(object formattedAuctionId, object o)
        {
            throw new System.NotImplementedException();
        }
    }
}