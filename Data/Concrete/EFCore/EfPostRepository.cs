using BlogNewsApp.Data.Abstract;
using BlogNewsApp.Entity;

namespace BlogNewsApp.Data.Concrete.EFCore
{
	public class EfPostRepository : IPostRepository
	{

		private BlogNewsContext _context;

		public EfPostRepository(BlogNewsContext context)
		{
			_context = context;
		}

		public IQueryable<Post> Posts => _context.Posts;

		public void createPost(Post post)
		{
			_context.Posts.Add(post);
			_context.SaveChanges();
		}
	}
}
