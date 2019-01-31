using System;
using AuctionSniper.Fakes.XmppServer;

namespace AuctionSniper.Domain
{
    public class AuctionMessageTranslator : IMessageListener
    {
        private readonly  string _sniperId;
        private readonly IAuctionEventListener _auctionEventListener;

        public AuctionMessageTranslator(string sniperId, IAuctionEventListener auctionEventListener)
        {
            _sniperId = sniperId;
            _auctionEventListener = auctionEventListener;
        }

        public Message Message { get; set; }
        public event IMessageListenerEventHandler ProcessMessage;
        public void InvokeProcessMessage(MessageListenerEventArgs mle)
        {
            if (MessageHasPairedValues(mle))
            {
                var auctionEvent = AuctionEvent.From(mle.Message.Body);

                switch (auctionEvent.Type)
                {
                    case "CLOSE":
                        _auctionEventListener.AuctionClosed();
                        break;
                    case "PRICE":
                        _auctionEventListener.CurrentPrice(auctionEvent.CurrentPrice, auctionEvent.Increment, auctionEvent.IsFrom(_sniperId));
                        break;
                    default:
                        string messageDetail =
                            $"Message type: {auctionEvent.Type} not handled, from message {mle.Message.Body}";
                        throw new Exception(messageDetail);
                }
            }
            else
            {
                if (mle.Message.Body.Contains(SharedConstants.STATUS_JOINING))
                {
                    _auctionEventListener.JoiningAuction();
                }
            }
        }

        private bool MessageHasPairedValues(MessageListenerEventArgs mle)
        {
            return mle.Message.Body.Contains(";");
        }
    }
}