using Getting_Started.Domain.Entities;

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
                .UseProjection()
                .UseFiltering()
                .UseSorting();

            descriptor.Field(p => p.User)
                .UseProjection();
        }
    }

}
