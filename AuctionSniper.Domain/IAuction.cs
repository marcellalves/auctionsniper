namespace AuctionSniper.Domain
{
    public interface IAuction
    {
        void Join();
        void Bid(int bidAmount);
    }
}