﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AuctionSniper.Tests.Acceptance
{
    [TestClass]
    public class AuctionSniperEndToEndTest
    {
        private ApplicationRunner _application;
        private FakeAuctionServer _auction;

        [TestInitialize]
        public void Setup()
        {
            _auction = new FakeAuctionServer("item-54321");
            _application = new ApplicationRunner();
        }

        [TestMethod]
        public void SniperJoinsAuctionUntilAuctionCloses()
        {
            _auction.StartSellingItem();
            _application.StartBiddingIn(_auction);
            _auction.HasReceivedJoinRequestFromSniper(ApplicationRunner.SniperXmppId);
            _auction.AnnouncesClosed();
            _application.ShowsSniperHasLostAuction();
        }

        [TestMethod]
        public void SniperMakesABidButLoses()
        {
            _auction.StartSellingItem();
            _application.StartBiddingIn(_auction);
            _auction.HasReceivedJoinRequestFromSniper(ApplicationRunner.SniperXmppId);
            _auction.ReportPrice(1000, 98, "other bidder");
            _application.HasShownSniperIsBidding();
            _auction.HasReceivedBid(1098, ApplicationRunner.SniperXmppId);
            _auction.AnnouncesClosed();
            _application.ShowsSniperHasLostAuction();
        }
    }
}
