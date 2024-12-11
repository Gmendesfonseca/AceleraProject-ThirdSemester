namespace InnerAPI.Models.Chat
{
    public class MessageType
    {
        public int Id { get; set; }
        public int ChatId { get; set; }
        public int SenderId { get; set; }
        public string Text { get; set; }
        public string CreatorName { get; set; }
        public string CreatorImage { get; set; }
        public AccountType CreatorAccountType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime Timestamp { get; set; }

    }
}

//public int Id { get; set; }
//public int ChatId { get; set; }
//public int SenderId { get; set; }
//public string Text { get; set; }
//public DateTime Timestamp { get; set; }
    