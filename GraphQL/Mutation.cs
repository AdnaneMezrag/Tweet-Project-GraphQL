using Getting_Started.Domain.Entities;

namespace Getting_Started.GraphQL
{
    public class Mutation
    {
        // We'll simulate a database using a static list
        private static List<User> _users = new()
        {
            new User { Id = 1, Name = "Alice" },
            new User { Id = 2, Name = "Bob" }
        };

        public User CreateUser(int id, string name)
        {
            var newUser = new User { Id = id, Name = name };
            _users.Add(newUser);
            return newUser;
        }
    }
}
