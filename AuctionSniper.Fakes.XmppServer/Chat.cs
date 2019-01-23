using System;
using System.Collections.Generic;

namespace AuctionSniper.Fakes.XmppServer
{
    public class Chat
    {
        private string auctionId;
        private string participant;

        public Chat(string auctionId, string participant)
        {
            this.auctionId = auctionId;
            this.participant = participant;
        }

        public IList<IMessageListener> MessageListeners { get; }

        public void AddMessageListener(IMessageListener messageListener)
        {
            MessageListeners.Add(messageListener);
        }

        public void SendMessage(string v)
        {
            throw new NotImplementedException();
        }
    }
}