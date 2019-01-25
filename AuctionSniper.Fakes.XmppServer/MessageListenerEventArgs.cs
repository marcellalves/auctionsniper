using System;

namespace AuctionSniper.Fakes.XmppServer
{
    public class MessageListenerEventArgs : EventArgs
    {
        public MessageListenerEventArgs(Message message)
        {
            Message = message;
        }

        public Message Message { get; }
    }
}