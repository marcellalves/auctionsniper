using System;
using Xunit;

namespace AuctionSniper.Test
{
    public class AuctionSniperEndToEndTest : IDisposable
    {
        private readonly FakeAuctionServer _auction = new FakeAuctionServer("item-54321");
        private readonly ApplicationRunner _application = new ApplicationRunner();

        [Fact]
        public void SniperJoinsAuctionUntilAuctionCloses()
        {
            Assert.ThrowsAsync<Exception>(() => _auction.StartSellingItem());
            Assert.ThrowsAsync<Exception>(() => _application.StartBiddingIn(_auction));
            Assert.ThrowsAsync<Exception>(() => _auction.HasReceivedJoinRequestFromSniper());
            Assert.ThrowsAsync<Exception>(() => _auction.AnnounceClosed());
            Assert.ThrowsAsync<Exception>(() => _application.ShowsSniperHasLostAuction());
        }

        public void Dispose()
        {
            _auction.Stop();
            _application.Stop();
        }
    }
}
