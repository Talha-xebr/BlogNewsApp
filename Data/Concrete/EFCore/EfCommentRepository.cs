using BlogNewsApp.Data.Abstract;
using BlogNewsApp.Entity;

namespace BlogNewsApp.Data.Concrete.EFCore
{
    public class EfCommentRepository : ICommentRepository
    {

        private BlogNewsContext _blogNewsContext;
        public EfCommentRepository(BlogNewsContext blogNewsContext)
        {
            this._blogNewsContext = blogNewsContext;
        }
        public IQueryable<Comment> Comments => _blogNewsContext.Comments;

        public void createComment(Comment comment)
        {
            _blogNewsContext.Comments.Add(comment);
            _blogNewsContext.SaveChanges();
        }
    }
}
