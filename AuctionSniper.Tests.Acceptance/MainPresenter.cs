using System;

namespace AuctionSniper.Tests.Acceptance
{
    internal class MainPresenter
    {
        private object main;

        public MainPresenter(object main)
        {
            this.main = main;
        }

        internal void Main(object xMPP_HOSTNAME, string sniperXmppId, string sniperPassword, object itemId)
        {
            throw new NotImplementedException();
        }
    }
}