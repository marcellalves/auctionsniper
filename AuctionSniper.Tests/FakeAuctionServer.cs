using System;
using System.Threading.Tasks;

namespace AuctionSniper.Tests
{
    public class FakeAuctionServer
    {
        private string v;

        public FakeAuctionServer(string v)
        {
            this.v = v;
        }

        public string ItemId { get; set; }

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