using AuctionSniper.Domain;
using AuctionSniper.Fakes.XmppServer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
            _connection = XmppConnection.CreateXmppConnection(SharedConstants.XMPP_HOSTNAME);
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
            _currentChat = ((ChatManager)sender).CurrentChat;
            _currentChat.AddMessageListener(_singleMessageListener);
            _singleMessageListener.ProcessMessage += MessageListenerProcessMessage;
        }

        private void MessageListenerProcessMessage(object sender, MessageListenerEventArgs mle)
        {
            var messageListener = (IMessageListener)sender;
            messageListener.Message = mle.Message;
        }

        public void HasReceivedJoinRequestFromSniper(string sniperId)
        {
            ReceivesAMessageMatching(sniperId, new MatcherCustom(MatcherCustom.MatchVia.EqualTo, SharedConstants.STATUS_JOINING));
        }

        public void AnnouncesClosed()
        {
            _currentChat.SendMessage("SOLVersion: 1.1; Event: CLOSE;");
        }

        private void ReceivesAMessage()
        {

        }

        public void ReportPrice(int price, int increment, string bidder)
        {
            _currentChat.SendMessage($"SOL Version: 1.1; Event: PRICE; CurrentPrice: {price}; Increment: {increment}; Bidder: {bidder}");
        }

        public void HasReceivedBid(int bid, string sniperId)
        {
            ReceivesAMessageMatching(sniperId, new MatcherCustom(MatcherCustom.MatchVia.EqualTo, $"amount{SharedConstants.BID_COMMAND_FORMAT}"));
        }

        private void ReceivesAMessageMatching(string sniperId, MatcherCustom matcher)
        {
            _singleMessageListener.ReceivesAMessage(matcher);
            Assert.AreEqual(_singleMessageListener.Message.Chat.Participant, sniperId);
        }
    }
}