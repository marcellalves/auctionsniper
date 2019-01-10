using System;
using Xunit;

namespace AuctionSniper.Tests
{
    public class AuctionSniperEndToEndTest : IDisposable
    {
        private readonly FakeAuctionServer _auction = new FakeAuctionServer("item-54321");
        private readonly ApplicationRunner _application = new ApplicationRunner();

        [Fact]
        public void SniperJoinsAuctionUntilAuctionCloses()
        {
            _auction.StartSellingItem();
            _application.StartBiddingIn(_auction);
            _auction.HasReceivedJoinRequestFromSniper();
            _auction.AnnounceClosed();
            _application.ShowsSniperHasLostAuction();
        }

        public void Dispose()
        {
            _auction.Stop();
            _application.Stop();
        }
    }
}
