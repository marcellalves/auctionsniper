using System;

namespace AuctionSniper.Domain
{
    public class MatcherCustom
    {
        public enum MatchVia
        {
            EqualTo
        }

        private readonly string _baseString;
        private readonly MatchVia _matchVia;

        public MatcherCustom(MatchVia matchVia, string baseString)
        {
            _matchVia = matchVia;
            _baseString = baseString;
        }

        public void AssertThat(string stringToCompare)
        {
            switch (_matchVia)
            {
                case MatchVia.EqualTo:
                    if (_baseString.Equals(stringToCompare))
                    {
                    }
                    else
                    {
                        var message = $"string1: {_baseString} not equal to stringToCompare: {stringToCompare}";

                        throw new Exception(message);
                    }

                    break;

            }
        }
    }
}
