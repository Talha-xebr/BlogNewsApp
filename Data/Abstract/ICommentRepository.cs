using BlogNewsApp.Entity;

namespace BlogNewsApp.Data.Abstract
{
    public interface ICommentRepository
    {
        IQueryable<Comment> Comments { get; }
        void createComment(Comment comment);
    }
}
