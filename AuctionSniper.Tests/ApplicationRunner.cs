using System;
using System.Threading.Tasks;

namespace AuctionSniper.Tests
{
    public class ApplicationRunner
    {
        public static readonly string _sniperId = "sniper";
        public static readonly string _sniperPassword = "sniper";
        private AuctionSniperDriver _driver;

        public void StartBiddingIn(FakeAuctionServer auction)
        {
            _driver = new AuctionSniperDriver("", _sniperId, _sniperPassword, auction.ItemId);
            _driver.ShowsSniperStatus(Main.STATUS_JOINING);
        }

        public Task ShowsSniperHasLostAuction()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}