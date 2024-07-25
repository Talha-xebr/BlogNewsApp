using BlogNewsApp.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogNewsApp.Data.Concrete
{
    public class SeedData
    {
        public static void seedTestingData(IApplicationBuilder app) {
            var ctx = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogNewsContext>();
            if(ctx != null)
            {
                if (ctx.Database.GetPendingMigrations().Any())
                    ctx.Database.Migrate();
                // Tags
                if(!ctx.Tags.Any())
                {
                    ctx.Tags.AddRange (
                        new Entity.Tag { TagName = "Teknoloji", Url = "teknoloji"},
						new Entity.Tag { TagName = "Bilim", Url = "bilim" },
						new Entity.Tag { TagName = "Oyun", Url = "oyun" },
						new Entity.Tag { TagName = "Eglence", Url = "eglence" },
						new Entity.Tag { TagName = "Muzik", Url = "muzik" },
						new Entity.Tag { TagName = "Anime", Url = "anime" },
						new Entity.Tag { TagName = "Kitap", Url = "kitap" }
						);
                    ctx.SaveChanges();
                }
                // Users
                if(!ctx.Users.Any())
                {
                    ctx.Users.AddRange(
                        new Entity.User { UserName="testUser1", Name="Test User 1", Email="tu@t.com", Password="tu123", Image="ptest.jpg", AboutMe="Test User Please Ingore", isAdmin=false},
                        new Entity.User { UserName="adminUser", Name="Admin User", Email="au@t.com", Password="au123", Image="ptest.jpg", AboutMe="Admin User Please Ingore", isAdmin=true},
                        new Entity.User { UserName="EmreSimsek", Name="Emre Simsek", Email="es@t.com", Password="es123", Image="ptest.jpg", AboutMe="Avg Anime Enjoyer", isAdmin=false }
                        );
                    ctx.SaveChanges();
                }
                // Posts
                if(!ctx.Posts.Any())
                {

                    ctx.Posts.AddRange(
                        new Entity.Post {
                            Title="Amd Duyuru", 
                            Content="Amd yeni teknoloji hakkında duyuru yaptı", 
                            Description="Amd yeni Çip hakkında Duyuru", 
                            Image="amdciptek.jpg", Url="amd-cip-teknolojisi", 
                            PostDate=DateTime.Now.AddDays(-1), isActive=true, UserId=2, 
                            Tags=ctx.Tags.Take(1).ToList(),
                            Comments= new List<Comment>{
                                new Comment{ Text="guzel bir teknolojiye benziyor", CommentDate=DateTime.Now, UserId=1},
                                new Comment{ Text="intel ne yapacak acaba", CommentDate=DateTime.Now, UserId=3},
                                }
                            },
                            new Entity.Post {
                            Title="Nasa Duyuru", 
                            Content="Nasa yeni yayın akışı Nasa+'i duyurdu", 
                            Description="Nasa+ Geliyor", 
                            Image="nasaduyuru.jpg", Url="nasa-yayın-akisi-duyuru", 
                            PostDate=DateTime.Now.AddDays(-4), isActive=true, UserId=2, 
                            Tags=ctx.Tags.Take(2).ToList(),
                            Comments= new List<Comment>{
                                new Comment{ Text="harika", CommentDate=DateTime.Now, UserId=3},
                                new Comment{ Text="ne gibi seyler yayinlayacaklar acaba", CommentDate=DateTime.Now, UserId=1},
                                }
                            }
                    );
                    ctx.SaveChanges();
                }
                // We don't need to add Comments here
                // When we add a Comment in Post seeding area
                // It'll add to the comment table as well.
            }
        }
    }
}