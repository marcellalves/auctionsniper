namespace AuctionSniper.Fakes.XmppServer
{
    public class Message
    {
        public Message(Chat chat)
        {
            Chat = chat;
        }

        public Chat Chat { get; }

        public string Body { get; set; }
    }
}