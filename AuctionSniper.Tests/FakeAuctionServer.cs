using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SharpXMPP;

namespace AuctionSniper.Tests
{
    public class FakeAuctionServer
    {
        private const string _itemIdAsLogin = "auction-{0}";
        private const string _auctionResource = "Auction";
        private const string _xmppHostName = "SQEST284.squadra.com.br";
        private const string _auctionPassword = "auction";

        private readonly string _itemId;
        private readonly XmppConnection _connection;

        public FakeAuctionServer(string itemId)
        {
            _itemId = itemId;
        }

        public Task StartSellingItem()
        {
            throw new NotImplementedException();
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