using Getting_Started.Domain.Entities;
using Getting_Started.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Getting_Started.Infrastructure.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly TweetContext _context;

        public CommentRepository(TweetContext context)
        {
            _context = context;
        }

        public async Task<Comment?> GetByIdAsync(int id)
        {
            return await _context.Comments
                .Include(c => c.User)
                .Include(c => c.Post)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task AddAsync(Comment comment)
        {
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Comment comment)
        {
            _context.Comments.Update(comment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var comment = await GetByIdAsync(id);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Comments.AnyAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Comment>> GetCommentsByUserAsync(int userId)
        {
            return await _context.Comments
                .Where(c => c.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Comment>> GetCommentsByPostAsync(int postId)
        {
            return await _context.Comments
                .Where(c => c.PostId == postId)
                .Include(c => c.User)
                .ToListAsync();
        }
    }
}
