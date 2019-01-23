namespace AuctionSniper.Domain
{
    public class AuctionSniper : IAuctionEventListener
    {
        private IAuction auction;
        private ISniperListener sniperStateDisplayer;

        public AuctionSniper(IAuction auction, ISniperListener sniperStateDisplayer)
        {
            this.auction = auction;
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
            throw new System.NotImplementedException();
        }
    }
}