using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Logging;
using SharpXMPP;
using SharpXMPP.XMPP;
using SharpXMPP.XMPP.Client.Elements;

namespace AuctionSniper.Tests
{
    public class FakeAuctionServer
    {
        private const string _itemIdAsLogin = "auction-{0}";
        private const string _auctionResource = "Auction";
        private const string _xmppHostName = "SQEST284.squadra.com.br";
        private const string _auctionPassword = "auction";

        private XmppClient _client;
        private readonly SingleMessageListener _messageListener = new SingleMessageListener();

        public string ItemId { private set; get; }

        public FakeAuctionServer(string itemId)
        {
            ItemId = itemId;
        }

        public void StartSellingItem()
        {
            var jid = new JID(string.Format(_itemIdAsLogin, ItemId))
            {
                Domain = _xmppHostName,
                Resource = _auctionResource
            };
            _client = new XmppClient(jid, _auctionPassword);
            _client.Connect();
            _client.Message += _messageListener.ProcessMessage;
        }

        public Task HasReceivedJoinRequestFromSniper()
        {
            throw new NotImplementedException();
        }

        public Task AnnounceClosed()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}