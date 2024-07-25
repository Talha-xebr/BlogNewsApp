using BlogNewsApp.Data.Abstract;
using BlogNewsApp.Entity;

namespace BlogNewsApp.Data.Concrete.EFCore
{
	public class EfTagRepository : ITagRepository
	{
		private BlogNewsContext _context;
		public EfTagRepository(BlogNewsContext context)
		{
			_context = context;
		}

		public IQueryable<Tag> Tags => _context.Tags;

		public void createTag(Tag tag)
		{
			_context.Tags.Add(tag);
			_context.SaveChanges();
		}
	}
}
