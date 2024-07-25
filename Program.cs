using BlogNewsApp.Data.Abstract;
using BlogNewsApp.Data.Concrete;
using BlogNewsApp.Data.Concrete.EFCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// for using controllers and views
builder.Services.AddControllersWithViews();


// Setting Db
builder.Services.AddDbContext<BlogNewsContext>(options=>{
    options.UseSqlite(builder.Configuration.GetConnectionString("defaultSqlite"));
});


builder.Services.AddScoped<IPostRepository,EfPostRepository>();
builder.Services.AddScoped<ITagRepository,EfTagRepository>();
builder.Services.AddScoped<ICommentRepository,EfCommentRepository>();
builder.Services.AddScoped<IUserRepository,EfUserRepository>();

// for Cookie Auth
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

var app = builder.Build();

// for wwwroot
app.UseStaticFiles();

// for Auth 
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// seeding data
SeedData.seedTestingData(app);


//app.MapGet("/", () => "Hello World!");
app.MapControllerRoute(
    name:"default",
    pattern:"{Controller=Post}/{action=Index}/{id?}"
);
app.MapControllerRoute(
    name: "posts_by_tag",
    pattern: "post/tag/{tagUrl}",
    defaults: new { controller = "Post", action = "Index" }
);
app.MapControllerRoute(
	name: "post_details",
	pattern: "post/detail/{url}",
	defaults: new { controller = "Post", action = "Details" }
);


app.Run();
