namespace InnerAPI.Models.Chat
{
    public class UserType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public AccountType AccountType { get; set; }

    }
}
