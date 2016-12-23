namespace Domain.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string WebsiteUrl { get; set; }
        public string Bio { get; set; }
        public string PathAvatar { get; set; }
    }
}