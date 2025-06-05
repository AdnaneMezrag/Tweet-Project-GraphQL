using Getting_Started.Domain.Entities;

namespace Getting_Started.Domain.IRepositories
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<IEnumerable<Comment>> GetCommentsByUserAsync(int userId);
        Task<IEnumerable<Comment>> GetCommentsByPostAsync(int postId);
    }
}
