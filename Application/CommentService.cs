using Getting_Started.Domain.Entities;
using Getting_Started.Domain.IRepositories;

namespace Getting_Started.Application
{
    public class CommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<Comment> GetCommentByIdAsync(int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            if (comment == null)
                throw new InvalidOperationException("Comment not found");

            return comment;
        }

        public async Task<int> CreateCommentAsync(Comment comment)
        {
            await _commentRepository.AddAsync(comment);
            return comment.Id;
        }

        public async Task UpdateCommentAsync(Comment comment)
        {
            var existingComment = await _commentRepository.GetByIdAsync(comment.Id);
            if (existingComment == null)
                throw new InvalidOperationException("Comment not found");

            existingComment.Text = comment.Text;
            await _commentRepository.UpdateAsync(existingComment);
        }

        public async Task DeleteCommentAsync(int id)
        {
            var comment = await _commentRepository.GetByIdAsync(id);
            if (comment == null)
                throw new InvalidOperationException("Comment not found");

            await _commentRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Comment>> GetCommentsByPostAsync(int postId)
        {
            return await _commentRepository.GetCommentsByPostAsync(postId);
        }

    }
}
