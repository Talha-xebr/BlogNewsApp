using BlogNewsApp.Data.Abstract;
using BlogNewsApp.Entity;

namespace BlogNewsApp.Data.Concrete.EFCore
{
    public class EfUserRepository : IUserRepository
    {

        private BlogNewsContext _blogNewsContext;
        public EfUserRepository(BlogNewsContext blogNewsContext)
        {
            this._blogNewsContext = blogNewsContext;
        }
        public IQueryable<User> Users => _blogNewsContext.Users;

        public void createUser(User user)
        {
            _blogNewsContext.Users.Add(user);
            _blogNewsContext.SaveChanges();
        }
    }
}
