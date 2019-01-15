using System;
using System.Collections.Concurrent;
using SharpXMPP;
using SharpXMPP.XMPP;
using SharpXMPP.XMPP.Client.Elements;

namespace AuctionSniper.Tests
{
    public class SingleMessageListener
    {
        private XmppClient _xmppClient;
        private readonly ConcurrentQueue<XMPPMessage> _messages = new ConcurrentQueue<XMPPMessage>();

        public SingleMessageListener(string user, string domain, string password, string resource)
        {
            var jid = new JID()
            {
                User = user,
                Domain = domain,
                Resource = resource
            };
            _xmppClient = new XmppClient(jid, password);
            _xmppClient.Message += ProcessMessage;
        }

        public void Connect()
        {
            _xmppClient.Connect();
        }

        public void ProcessMessage(XmppConnection sender, XMPPMessage message)
        {
            _messages.Enqueue(message);
        }

        public void ReceivesAMessage()
        {
            throw new NotImplementedException();
        }

        public void SendMessage(XMPPMessage xmppMessage)
        {
            //_xmppClient.SendMessage();
        }
    }
}