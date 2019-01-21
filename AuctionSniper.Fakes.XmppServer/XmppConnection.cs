using System;

namespace AuctionSniper.Fakes.XmppServer
{
    public class XmppConnection
    {
        public ChatManager ChatManager { get; set; }
        public object UserName { get; internal set; }
        public object ServiceName { get; set; }

        public static XmppConnection CreateXmppConnection(string hostName)
        {
            throw new NotImplementedException();
        }

        public void Connect()
        {
            throw new NotImplementedException();
        }

        public void Login(string userName, string password, string auctionResource)
        {
            throw new NotImplementedException();
        }
    }
}