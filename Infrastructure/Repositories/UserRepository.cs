using Getting_Started.Domain.Entities;
using Getting_Started.Domain.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Getting_Started.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TweetContext _context;

        public UserRepository(TweetContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            //return await _context.Users
            //    .Include(u => u.Posts)
            //    .Include(u => u.Comments)
            //    .FirstOrDefaultAsync(u => u.Id == id);
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.Include(u => u.Posts).Include
                (u => u.Comments).ToListAsync();
            //return await _context.Users.ToListAsync();
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var user = await GetByIdAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Users.AnyAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<Post>> GetUserPostsAsync(int userId)
        {
            return await _context.Posts
                .Where(p => p.UserId == userId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Comment>> GetUserCommentsAsync(int userId)
        {
            return await _context.Comments
                .Where(c => c.UserId == userId)
                .ToListAsync();
        }

    }
}
