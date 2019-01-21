using AuctionSniper.Domain;
using AuctionSniper.Fakes.XmppServer;

namespace AuctionSniper.UI
{
    public class MainPresenter
    {
        private const string AuctionResource = "Auction";
        private const string AuctionIdFormat = "auction-{0}@{1}/Auction";
        private string _itemId;
        private string _sniperId;
        private string _sniperPassword;
        private string _xmppHostName;

        public MainPresenter(IPickerMainView pickerMainView)
        {
            PickerMainview = pickerMainView;
        }

        public IPickerMainView PickerMainview { get; }

        public void Main(string xmppHostName, string sniperId, string sniperPassword, string itemId)
        {
            _xmppHostName = xmppHostName;
            _sniperId = sniperId;
            _sniperPassword = sniperPassword;
            _itemId = itemId;

            PickerMainview.WindowTitle = SharedConstants.MAIN_WINDOW_TITLE;

            var connection = ConnectTo(_xmppHostName, _sniperId, _sniperPassword);

            JoinAuction(connection, itemId);
        }

        private void JoinAuction(XmppConnection connection, string itemId)
        {
            var formattedAuctionId = AuctionId(itemId, connection);
            var chat = connection.ChatManager.CreateChat(formattedAuctionId, null);

            const int bidAmount = 35;
            IAuction auction = new XmppAuction(chat);
            chat.AddMessageListener(
                new AuctionMessageTranslator(connection.UserName, new Domain.AuctionSniper(auction, new SniperStateDisplayer(this))));
            auction.Join();
        }

        private XmppConnection ConnectTo(string hostName, string userName, string password)
        {
            var connection = XmppConnection.CreateXmppConnection(hostName);
            connection.Connect();
            connection.Login(userName, password, AuctionResource);

            return connection;
        }

        private static string AuctionId(string itemId, XmppConnection connection)
        {
            return string.Format(AuctionIdFormat, itemId, connection.ServiceName);
        }
    }
}