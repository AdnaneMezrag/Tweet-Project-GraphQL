using Getting_Started.Domain.Entities;
using Getting_Started.Domain.IRepositories;

namespace Getting_Started.Application
{
    public class PostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<Post> GetPostByIdAsync(int id)
        {
            return await _postRepository.GetByIdAsync(id);        }

        public async Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            return await _postRepository.GetAllAsync();
        }

        public IQueryable<Post> GetAllPosts()
        {
            return _postRepository.GetAll();
        }


        public async Task<int> CreatePostAsync(Post post)
        {
            await _postRepository.AddAsync(post);
            return post.Id;
        }

        public async Task UpdatePostAsync(Post post)
        {
            var existingPost = await _postRepository.GetByIdAsync(post.Id);
            if (existingPost == null)
                return;

            existingPost.Title = post.Title;
            existingPost.Content = post.Content;

            await _postRepository.UpdateAsync(existingPost);
        }

        public async Task DeletePostAsync(int id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            if (post == null)
                return;

            await _postRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Comment>> GetPostCommentsAsync(int postId)
        {
            return await _postRepository.GetPostCommentsAsync(postId);
        }

    }
}
