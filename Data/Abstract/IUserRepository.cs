using BlogNewsApp.Entity;

namespace BlogNewsApp.Data.Abstract
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }
        void createUser(User user);
    }
}
