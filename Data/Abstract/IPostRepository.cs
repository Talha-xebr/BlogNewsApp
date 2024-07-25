using BlogNewsApp.Entity;

namespace BlogNewsApp.Data.Abstract
{
	public interface IPostRepository
	{
		IQueryable<Post> Posts { get; }
		void createPost(Post post);
	}
}
