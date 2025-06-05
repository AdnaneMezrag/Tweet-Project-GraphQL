using Getting_Started.Application;
using Getting_Started.Domain.Entities;
using Getting_Started.Infrastructure;

public class Query
{
    public async Task<IEnumerable<Post>> GetPosts([Service] PostService postService)
    {
        return await postService.GetAllPostsAsync();
    }   

    public async Task <IEnumerable<User>> GetUsers([Service] UserService userService)
    {
        return await userService.GetAllUsersAsync();
    }
    
    public async Task <IEnumerable<Comment>> GetCommentsByPostID(int id, [Service] CommentService commentService)
    {
        return await commentService.GetCommentsByPostAsync(id);
    }   

    public async Task <Post> GetPostById(int id, [Service] PostService postService)
    {
        return await postService.GetPostByIdAsync(id);
    }


}