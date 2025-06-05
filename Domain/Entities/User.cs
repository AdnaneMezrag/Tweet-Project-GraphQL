namespace Getting_Started.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public ICollection<Post>? Posts { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }

}

