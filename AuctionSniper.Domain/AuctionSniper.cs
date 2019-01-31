namespace AuctionSniper.Domain
{
    public class AuctionSniper : IAuctionEventListener
    {
        private IAuction _auction;
        private ISniperListener _sniperListener;

        public AuctionSniper(IAuction auction, ISniperListener sniperListener)
        {
            _auction = auction;
            _sniperListener = sniperListener;
        }

        public void AuctionClosed()
        {
            throw new System.NotImplementedException();
        }

        public void CurrentPrice(int currentPrice, int increment, Enums.PriceSource fromOtherBidder)
        {
            throw new System.NotImplementedException();
        }

        public void JoiningAuction()
        {
            _sniperListener.SniperJoining();
        }
    }
}