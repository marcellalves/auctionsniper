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
            MessageListeners = new List<IMessageListener>();
            this.auctionId = auctionId;
            this.participant = participant;
        }

        public IList<IMessageListener> MessageListeners { get; }
        public Message Message { get; private set; }

        public void AddMessageListener(IMessageListener messageListener)
        {
            MessageListeners.Add(messageListener);
        }

        public void SendMessage(string messageBody)
        {
            Message = new Message(this) { Body = messageBody };

            foreach (IMessageListener messageListener in MessageListeners)
            {
                var mle = new MessageListenerEventArgs(Message);
                messageListener.InvokeProcessMessage(mle);
            }
        }
    }
}