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

        private readonly SingleMessageListener _messageListener;

        public string ItemId { private set; get; }

        public FakeAuctionServer(string itemId)
        {
            ItemId = itemId;
            _messageListener = new SingleMessageListener(string.Format(_itemIdAsLogin, ItemId), _xmppHostName,
                _auctionPassword, _auctionResource);
        }

        public void StartSellingItem()
        {
            _messageListener.Connect();
        }

        public void HasReceivedJoinRequestFromSniper()
        {
            _messageListener.ReceivesAMessage();
        }

        public void AnnounceClosed()
        {
            _messageListener.SendMessage(new XMPPMessage());
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}