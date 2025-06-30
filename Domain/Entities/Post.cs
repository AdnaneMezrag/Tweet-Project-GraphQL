namespace Getting_Started.Domain.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Content { get; set; } = default!;
        public int UserId { get; set; }
        public User User { get; set; } = default!;
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }

}

