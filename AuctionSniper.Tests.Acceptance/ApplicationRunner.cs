using AuctionSniper.Domain;
using AuctionSniper.UI;

namespace AuctionSniper.Tests.Acceptance
{
    public class ApplicationRunner
    {
        public const string SniperXmppId = "sniper@localhost/Auction";
        private readonly string SniperPassword = "sniper";
        private AuctionSniperDriver _driver;

        public void StartBiddingIn(FakeAuctionServer auction)
        {
            _driver = new AuctionSniperDriver(new Main(), 1000);
            var main = new MainPresenter(_driver.Main);
            main.Main(SharedConstants.XMPP_HOSTNAME, SniperXmppId, SniperPassword, auction.ItemId);
            _driver.LaunchApplicationInItsOwnThread();
            _driver.ShowsSniperStatus(SharedConstants.STATUS_JOINING);
        }

        public void ShowsSniperHasLostAuction()
        {
            _driver?.ShowsSniperStatus(SharedConstants.STATUS_LOST);
        }

        public void HasShownSniperIsBidding()
        {
            throw new System.NotImplementedException();
        }
    }
}
