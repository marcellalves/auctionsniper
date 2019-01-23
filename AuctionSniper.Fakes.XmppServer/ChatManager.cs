using System;
using System.Collections.Generic;

namespace AuctionSniper.Fakes.XmppServer
{
    public class ChatManager
    {
        private XmppConnection xmppConnection;

        public ChatManager(XmppConnection xmppConnection)
        {
            XmppConnection = xmppConnection;
        }

        public XmppConnection XmppConnection { get; private set; }
        public Chat CurrentChat { get; private set; }
        public IList<Chat> Chats { get; }

        public event EventHandler ChatCreated;

        public Chat CreateChat(string auctionId, string participant, IMessageListener messageListener)
        {
            CurrentChat = new Chat(auctionId, participant);
            CurrentChat.AddMessageListener(messageListener);
            Chats.Add(CurrentChat);
            OnChatCreated(EventArgs.Empty);
            return CurrentChat;
        }

        public Chat CreateChat(string auctionId, IMessageListener messageListener)
        {
            CurrentChat = new Chat(auctionId, XmppConnection.UserName);
            if (messageListener != null)
            {
                CurrentChat.AddMessageListener(messageListener);
            }

            Chats.Add(CurrentChat);
            OnChatCreated(EventArgs.Empty);
            return CurrentChat;
        }

        private void OnChatCreated(EventArgs e)
        {
            ChatCreated?.Invoke(this, e);
        }
    }
}