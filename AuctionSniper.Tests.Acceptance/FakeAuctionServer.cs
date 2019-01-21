using System;
using AuctionSniper.Domain;
using AuctionSniper.Fakes.XmppServer;

namespace AuctionSniper.Tests.Acceptance
{
    public class FakeAuctionServer
    {
        private const string ItemIdAsLogin = "auction-{0}";
        private const string AuctionResource = "Auction";
        private const string AuctionPassword = "auction";

        private readonly XmppConnection _connection;
        private readonly SingleMessageListener _singleMessageListener = new SingleMessageListener();
        private Chat _currentChat;

        public FakeAuctionServer(string itemId)
        {
            ItemId = itemId;
        }

        public string ItemId { get; }

        public void StartSellingItem()
        {
            _connection.Connect();
            _connection.Login(string.Format(ItemIdAsLogin, ItemId), AuctionPassword, AuctionResource);
            _connection.ChatManager.ChatCreated += ChatManager_ChatCreated;
        }

        private void ChatManager_ChatCreated(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void HasReceivedJoinRequestFromSniper(string sniperId)
        {
            ReceivesAMessage();
        }

        public void AnnouncesClosed()
        {
            _currentChat.SendMessage("SOLVersion: 1.1; Event: CLOSE;");
        }

        private void ReceivesAMessage()
        {

        }
    }
}