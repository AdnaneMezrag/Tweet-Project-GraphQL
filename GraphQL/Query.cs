using Getting_Started.Application;
using Getting_Started.Domain.Entities;
using Getting_Started.Infrastructure;

public class Query
{
    [UseProjection]
    public IQueryable<Post> GetPosts([Service] PostService postService)
    {
        return postService.GetAllPosts();
    }

    [UseProjection]
    public IQueryable<User> GetUsers([Service] UserService userService)
    {
        return userService.GetAll();
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