using System;
using Getting_Started.Domain.Entities;

namespace Getting_Started.Domain.IRepositories
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<IEnumerable<Comment>> GetPostCommentsAsync(int postId);
        IQueryable<Post> GetAll();
    }
}
