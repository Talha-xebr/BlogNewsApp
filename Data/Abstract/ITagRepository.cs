using BlogNewsApp.Entity;

namespace BlogNewsApp.Data.Abstract
{
	public interface ITagRepository
	{
		IQueryable<Tag> Tags { get; }
		void createTag(Tag tag);
	}
}
