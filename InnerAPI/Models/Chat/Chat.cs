namespace InnerAPI.Models.Chat
{
    public class Chat
    {
        public int Id { get; set; }
        public uint UserId1 { get; set; }
        public uint UserId2 { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<MessageType> Messages { get; set; } = new();
        public string Image { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DateCreation { get; set; }

    }
}
