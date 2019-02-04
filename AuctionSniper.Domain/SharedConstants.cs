using System.Diagnostics.Contracts;

namespace AuctionSniper.Domain
{
    public class SharedConstants
    {
        public const string XMPP_HOSTNAME = "localhost";
        public const string STATUS_JOINING = "joining";
        public const string STATUS_LOST = "lost";
        public const string STATUS_BIDDING = "bidding";
        public const string STATUS_WINNING = "winning";
        public const string STATUS_WON = "won";

        public const string MAIN_WINDOW_TITLE = "Auction Sniper Main";
        public const string BID_COMMAND_FORMAT = "BID_NOW";
    }
}