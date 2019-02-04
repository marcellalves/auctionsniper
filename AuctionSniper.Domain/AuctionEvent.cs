using System;
using System.Collections.Generic;

namespace AuctionSniper.Domain
{
    public class AuctionEvent
    {
        private readonly IDictionary<string, string> _fieldPairs = new Dictionary<string, string>();

        public string Type => Get("Event");
        public int CurrentPrice => GetInt("CurrentPrice");

        public int Increment => GetInt("Increment");

        private string Get(string fieldName)
        {
            _fieldPairs.TryGetValue(fieldName, out var result);
            return result;
        }

        private int GetInt(string fieldName)
        {
            return Convert.ToInt32(Get(fieldName));
        }

        private AuctionEvent()
        {}

        public static AuctionEvent From(string messageBody)
        {
            var auctionEvent = new AuctionEvent();
            foreach (var field in GenerateFieldPairs(messageBody))
            {
                auctionEvent.AddField(field);
            }

            return auctionEvent;
        }

        private void AddField(string field)
        {
            if (field.Contains(":"))
            {
                var pair = field.Split(':');
                _fieldPairs.Add(pair[0].Trim(), pair[1].Trim());
            }
        }

        private static IEnumerable<string> GenerateFieldPairs(string messageBody)
        {
            return messageBody.Split(';');
        }

        public Enums.PriceSource IsFrom(string sniperId)
        {
            var bidderName = Get("Bidder");
            return sniperId.Equals(bidderName) ? Enums.PriceSource.FromSniper : Enums.PriceSource.FromOtherBidder;
        }
    }
}