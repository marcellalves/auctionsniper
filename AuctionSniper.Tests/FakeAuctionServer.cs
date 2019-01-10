using System;
using System.Threading.Tasks;

namespace AuctionSniper.Tests
{
    internal class FakeAuctionServer
    {
        private string v;

        public FakeAuctionServer(string v)
        {
            this.v = v;
        }

        internal Task StartSellingItem()
        {
            throw new NotImplementedException();
        }

        internal Task HasReceivedJoinRequestFromSniper()
        {
            throw new NotImplementedException();
        }

        internal Task AnnounceClosed()
        {
            throw new NotImplementedException();
        }

        internal void Stop()
        {
            throw new NotImplementedException();
        }
    }
}