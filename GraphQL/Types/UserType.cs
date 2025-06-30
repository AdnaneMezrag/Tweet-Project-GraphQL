using Getting_Started.Domain.Entities;
using Getting_Started.Infrastructure;
using Getting_Started.Infrastructure.Data_Loaders;

namespace Getting_Started.GraphQL.Types
{
    public class UserType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor.Field(u => u.Id).Type<NonNullType<IdType>>();
            descriptor.Field(u => u.Name).Type<NonNullType<StringType>>();

            // Prefer either DataLoader or EF IQueryable — not both
            descriptor.Field("posts")
                .Type<ListType<NonNullType<PostType>>>()
                .Resolve(async ctx =>
                {
                    var user = ctx.Parent<User>();
                    return await ctx.DataLoader<UserPostsDataLoader>()
                                    .LoadAsync(user.Id, ctx.RequestAborted);
                });

            descriptor.Field("comments")
                .Type<ListType<NonNullType<CommentType>>>()
                .ResolveWith<Resolvers>(r => r.GetComments(default!, default!))
                .UseFiltering()
                .UseSorting();
        }

        private class Resolvers
        {
            public IQueryable<Comment> GetComments([Parent] User user, [Service] TweetContext dbContext)
            {
                return dbContext.Comments.Where(c => c.UserId == user.Id);
            }
        }

    }

}
