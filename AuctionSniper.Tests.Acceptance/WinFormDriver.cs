using System;
using AuctionSniper.UI;

namespace AuctionSniper.Tests.Acceptance
{
    public class WinFormDriver
    {
        private Main main;
        private int sleepMilliseconds;

        public WinFormDriver(Main main, int sleepMilliseconds)
        {
            this.main = main;
            this.sleepMilliseconds = sleepMilliseconds;
        }

        internal void QuitApplication()
        {
            throw new NotImplementedException();
        }
    }
}