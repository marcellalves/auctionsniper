using System.Net.Http;
using AuctionSniper.Web;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace AuctionSniper.Tests
{
    public class AuctionSniperDriver : IClassFixture<WebApplicationFactory<Startup>>
    {
        private string _xmppHostName;
        private string _sniperId;
        private string _sniperPassword;
        private string _itemId;
        private string _statusText;

        protected readonly HttpClient _client;

        public AuctionSniperDriver(string xmppHostName, string sniperId, string sniperPassword, string itemId)
        {
            var factory = new WebApplicationFactory<Startup>();
            _client = factory.CreateClient();
            
            _xmppHostName = xmppHostName;
            _sniperId = sniperId;
            _sniperPassword = sniperPassword;
            _itemId = itemId;
        }
        
        public void ShowsSniperStatus(string statusText)
        {
            _statusText = statusText;
        }

        [Fact]
        public async void ShowsSniperStatusCorrectValue()
        {
            var response = await _client.GetAsync("/auction");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();

            Assert.Contains(_statusText, stringResponse);
        }
    }
}