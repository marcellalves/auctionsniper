using AuctionSniper.Domain;

namespace AuctionSniper.UI
{
    public class SniperStateDisplayer : ISniperListener
    {
        private MainPresenter mainPresenter;

        public SniperStateDisplayer(MainPresenter mainPresenter)
        {
            this.mainPresenter = mainPresenter;
        }

        public void SniperLost()
        {
            throw new System.NotImplementedException();
        }

        public void SniperBidding()
        {
            throw new System.NotImplementedException();
        }

        public void SniperJoining()
        {
            throw new System.NotImplementedException();
        }

        public void SniperWinning()
        {
            throw new System.NotImplementedException();
        }

        public void SniperWon()
        {
            throw new System.NotImplementedException();
        }
    }
}