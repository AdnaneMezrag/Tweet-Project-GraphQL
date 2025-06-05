using Getting_Started.Domain.Entities;

namespace Getting_Started.Domain.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<Post>> GetUserPostsAsync(int userId);
        Task<IEnumerable<Comment>> GetUserCommentsAsync(int userId);
    }
}
