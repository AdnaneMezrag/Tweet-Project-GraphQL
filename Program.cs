
using Getting_Started.Application;
using Getting_Started.Domain.IRepositories;
using Getting_Started.GraphQL;
using Getting_Started.GraphQL.Types;
using Getting_Started.Infrastructure;
using Getting_Started.Infrastructure.Data_Loaders;
using Getting_Started.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace Getting_Started
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<TweetContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
                );

            builder.Services.AddScoped<UserService>(); // Add this line
            builder.Services.AddScoped<PostService>(); // Add this line
            builder.Services.AddScoped<CommentService>(); // Add this line

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IPostRepository, PostRepository>();
            builder.Services.AddScoped<ICommentRepository, CommentRepository>();

            // Register GraphQL with the query type
            builder.Services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddType<PostType>()
                .AddType<UserType>()
                .AddType<CommentType>()
                .AddProjections()
                .AddFiltering()
                .AddSorting()
                .AddMutationType<Mutation>()
                .ModifyRequestOptions(opt =>
                {
                     opt.IncludeExceptionDetails = true; // Show detailed errors
                })
                .AddDataLoader<UserPostsDataLoader>(); // Register DataLoaders


            var app = builder.Build();

            // Enable the GraphQL endpoint
            app.MapGraphQL(); // default path: /graphql

            app.Run();

        }
    }
}
