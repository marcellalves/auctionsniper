using System;
using System.Collections.Generic;

namespace AuctionSniper.Fakes.XmppServer
{
    public class XmppConnection
    {
        private static readonly IList<XmppConnection> _xmppConnections = new List<XmppConnection>();

        public XmppConnection(string xmppHostName)
        {
            XmppHostName = xmppHostName;
            ChatManager = new ChatManager(this);
        }

        public ChatManager ChatManager { get; set; }
        public string UserName { get; private set; }
        public object ServiceName { get; set; }

        public static XmppConnection CreateXmppConnection(string xmppHostName)
        {
            foreach (XmppConnection xmppConnection in _xmppConnections)
            {
                if(xmppConnection.XmppHostName == xmppHostName)
                {
                    return xmppConnection;
                }
            }

            var newConnection = new XmppConnection(xmppHostName);
            _xmppConnections.Add(newConnection);
            return newConnection;
        }

        public string XmppHostName { get; private set; }

        public void Connect()
        {
        }

        public void Login(string userName, string auctionPassword, string auctionResource)
        {
            UserName = userName;
        }
    }
}