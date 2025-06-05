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

            // Resolve Posts using DataLoader
            descriptor.Field("posts")
                .Type<ListType<ObjectType<Post>>>()
                .Resolve(async ctx =>
                {
                    var user = ctx.Parent<User>();
                    return await ctx.DataLoader<UserPostsDataLoader>()
                        .LoadAsync(user.Id, ctx.RequestAborted);
                });

            descriptor.Field(u => u.Comments).UseProjection();

            //descriptor.Field(u => u.Comments)
            //    .UseProjection()
            //    .UseFiltering()
            //    .UseSorting()
            //    .ResolveWith<Resolvers>(r => r.GetComments(default!, default!));
        }

        //private class Resolvers
        //{
        //    public IQueryable<Comment> GetComments([Parent] User user, [Service] TweetContext dbContext)
        //    {
        //        return dbContext.Comments.Where(c => c.UserId == user.Id);
        //    }
        //}

    }

}
