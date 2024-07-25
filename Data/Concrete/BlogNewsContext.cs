using BlogNewsApp.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;


namespace BlogNewsApp.Data.Concrete
{
    public class BlogNewsContext : DbContext
    {
        // DBSets for Entity Classes
        public BlogNewsContext(DbContextOptions<BlogNewsContext> options): base(options){}
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<Post> Posts => Set<Post>();
        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<User> Users => Set<User>();
        
    }
}