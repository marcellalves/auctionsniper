using System.Collections.Concurrent;
using SharpXMPP;
using SharpXMPP.XMPP.Client.Elements;

namespace AuctionSniper.Tests
{
    public class SingleMessageListener
    {
        private readonly ConcurrentQueue<XMPPMessage> _messages = new ConcurrentQueue<XMPPMessage>();

        public void ProcessMessage(XmppConnection sender, XMPPMessage message)
        {
            _messages.Enqueue(message);
        }
    }
}