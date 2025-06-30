using System;
using Getting_Started.Domain.Entities;
using Getting_Started.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Getting_Started.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly TweetContext _context;

        public PostRepository(TweetContext context)
        {
            _context = context;
        }

        public async Task<Post?> GetByIdAsync(int id)
        {
            return await _context.Posts
                .Include(p => p.User)
                .Include(p => p.Comments)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await _context.Posts
                .Include(p => p.User)  // Include post author
                .Include(p => p.Comments)  // Include comments
                    .ThenInclude(c => c.User)  // Include comment authors
                .AsNoTracking()  // Better performance for read-only
                .ToListAsync();
        }

        public async Task AddAsync(Post post)
        {
            await _context.Posts.AddAsync(post);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Post post)
        {
            _context.Posts.Update(post);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var post = await GetByIdAsync(id);
            if (post != null)
            {
                _context.Posts.Remove(post);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Posts.AnyAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Comment>> GetPostCommentsAsync(int postId)
        {
            return await _context.Comments
                .Where(c => c.PostId == postId)
                .Include(c => c.User)
                .ToListAsync();
        }

        public IQueryable<Post> GetAll()
        {
            return _context.Posts
                .Include(p => p.User)  // Include post author
                .Include(p => p.Comments)  // Include comments
                    .ThenInclude(c => c.User)  // Include comment authors
                .AsNoTracking();
        }

    }
}
