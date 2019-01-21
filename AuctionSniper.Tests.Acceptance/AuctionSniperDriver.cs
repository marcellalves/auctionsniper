using System;
using AuctionSniper.UI;

namespace AuctionSniper.Tests.Acceptance
{
    public class AuctionSniperDriver : WinFormDriver
    {
        public AuctionSniperDriver(Main main, int sleepMilliseconds) : base(main, sleepMilliseconds)
        {
        }

        public void ShowsSniperStatus(string expectedStatus)
        {
            if (!_main.SniperStatus.Equals(expectedStatus))
            {
                throw new Exception("Expected status does not match AuctionStatus label.");
            }

            base.QuitApplication();
        }
    }
}