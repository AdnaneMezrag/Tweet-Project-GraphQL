using System;
using Getting_Started.Domain.Entities;
using Getting_Started.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Getting_Started.Infrastructure
{
    public class TweetContext : DbContext
    {
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<Post> Posts { get; set; } = default!;
        public DbSet<Comment> Comments { get; set; } = default!;
        public TweetContext(DbContextOptions<TweetContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuring relationships
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new CommentConfiguration());
        }
    }

}
