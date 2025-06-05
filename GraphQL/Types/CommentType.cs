using Getting_Started.Domain.Entities;

namespace Getting_Started.GraphQL.Types
{
    public class CommentType : ObjectType<Comment>
    {
        protected override void Configure(IObjectTypeDescriptor<Comment> descriptor)
        {
            descriptor.Field(c => c.Id).Type<NonNullType<IdType>>();
            descriptor.Field(c => c.Text).Type<NonNullType<StringType>>();
            descriptor.Field(c => c.UserId).Type<NonNullType<IdType>>();
            descriptor.Field(c => c.PostId).Type<IdType>();

            descriptor.Field(c => c.User)
                .Type<UserType>(); 

            descriptor.Field(c => c.Post)
                .Type<NonNullType<PostType>>();
        }

    }
}
