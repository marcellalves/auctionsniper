using AuctionSniper.Domain;
using AuctionSniper.Fakes.XmppServer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace AuctionSniper.Tests.Unit
{
    [TestClass]
    public class AuctionMessageTranslatorTest
    {
        public readonly Chat _unusedChat = null;
        private string _sniperId = "test";
        private MockRepository _mocks;
        private IAuctionEventListener _mockListener;
        private AuctionMessageTranslator _translator;

        [TestInitialize]
        public void Initialize()
        {
            _mocks = new MockRepository();
            _mockListener = _mocks.StrictMock<IAuctionEventListener>();
            _translator = new AuctionMessageTranslator(_sniperId, _mockListener);
        }

        [TestMethod]
        public void NotifiesAuctionClosedWhenCloseMessageReceived()
        {
            var message = new Message(_unusedChat) {Body = "SOLVersion: 1.1; Event: CLOSE;"};
            var mlea = new MessageListenerEventArgs(message);

            _translator.InvokeProcessMessage(mlea);
        }
    }
}
