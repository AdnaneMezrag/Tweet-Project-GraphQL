namespace Getting_Started.Domain.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; } = default!;
        public int UserId { get; set; }
        public int PostId { get; set; }
        public User User { get; set; } = default!;
        public Post Post { get; set; } = default!;

    }

}

