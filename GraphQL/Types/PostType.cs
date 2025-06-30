using Getting_Started.Domain.Entities;
using Getting_Started.Infrastructure;
using System;

namespace Getting_Started.GraphQL.Types
{
    public class PostType : ObjectType<Post>
    {
        protected override void Configure(IObjectTypeDescriptor<Post> descriptor)
        {
            descriptor.Field(p => p.Id).Type<NonNullType<IdType>>();
            descriptor.Field(p => p.Title).Type<NonNullType<StringType>>();
            descriptor.Field(p => p.Content).Type<NonNullType<StringType>>();
            descriptor.Field(p => p.UserId).Type<NonNullType<IdType>>();


            descriptor.Field(p => p.Comments)
                .ResolveWith<PostResolvers>(r => r.GetComments(default!, default!))  // custom resolver
                .UseFiltering()
                .UseSorting()
                ;

            descriptor.Field(p => p.User)
                .UseProjection();
        }
    
    }

    public class PostResolvers
    {
        public IQueryable<Comment> GetComments([Parent] Post post, [Service] TweetContext context)
        {
            return context.Comments
                .Where(c => c.PostId == post.Id)
                .AsQueryable();
        }
    }


}
