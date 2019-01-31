namespace AuctionSniper.Domain
{
    public class AuctionSniper : IAuctionEventListener
    {
        private IAuction _auction;
        private ISniperListener _sniperListener;
        private bool _isWinning;

        public AuctionSniper(IAuction auction, ISniperListener sniperListener)
        {
            _auction = auction;
            _sniperListener = sniperListener;
        }

        public void AuctionClosed()
        {
            if (_isWinning)
            {
                _sniperListener.SniperWon();
            }
            else
            {
                _sniperListener.SniperLost();
            }
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