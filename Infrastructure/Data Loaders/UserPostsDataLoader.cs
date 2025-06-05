using Getting_Started.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Getting_Started.Infrastructure.Data_Loaders
{
    public class UserPostsDataLoader : BatchDataLoader<int, List<Post>>
    {
        private readonly TweetContext _context;

        public UserPostsDataLoader(TweetContext context,IBatchScheduler batchScheduler,
            DataLoaderOptions? options = null) // Optional options
            : base(batchScheduler, options ?? new DataLoaderOptions()) // Handle null options
        {
            _context = context;
        }

        protected override async Task<IReadOnlyDictionary<int, List<Post>>> LoadBatchAsync(
            IReadOnlyList<int> userIds,
            CancellationToken cancellationToken)
        {
            return await _context.Posts
                .Where(p => userIds.Contains(p.UserId))
                .Include(p => p.Comments) // Include comments
                .ThenInclude(c => c.User) // Optionally include user for each comment
                .AsNoTracking() // Recommended for read-only queries
                .GroupBy(p => p.UserId)
                .ToDictionaryAsync(
                    g => g.Key,
                    g => g.ToList(),
                    cancellationToken
                );
        }

    }
}
