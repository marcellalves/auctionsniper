namespace AuctionSniper.Domain
{
    public class AuctionSniper
    {
        private IAuction auction;
        private ISniperListener sniperStateDisplayer;

        public AuctionSniper(IAuction auction, ISniperListener sniperStateDisplayer)
        {
            this.auction = auction;
        }
    }
}