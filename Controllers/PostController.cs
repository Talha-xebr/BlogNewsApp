using BlogNewsApp.Data.Abstract;
using BlogNewsApp.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BlogNewsApp.Controllers
{
    public class PostController : Controller
    {

        private IPostRepository _postRepository;
        private ICommentRepository _commentRepository;
        public PostController(IPostRepository postRepository, ICommentRepository commentRepository)
        {
            this._postRepository = postRepository;
            this._commentRepository = commentRepository;
        }


        public async Task<IActionResult> Index(string tagUrl)
        {
            var posts = _postRepository.Posts;
            if (!string.IsNullOrEmpty(tagUrl))
            {
                posts = posts.Where(x => x.Tags.Any(t => t.Url == tagUrl));
            }
            return View(await posts.ToListAsync());
        }

        public async Task<IActionResult> Details(string url)
        {
            return View(await _postRepository.Posts.Include(x => x.Tags).Include(x => x.Comments).ThenInclude(x => x.user).FirstOrDefaultAsync(p => p.Url == url));
        }

        [HttpPost]
        public JsonResult AddComment(int postId, string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var userName = User.FindFirstValue(ClaimTypes.Name);
                var avatar = User.FindFirstValue(ClaimTypes.UserData);

                var entity = new Comment
                {
                    Text = text,
                    CommentDate = DateTime.Now,
                    PostId = postId,
                    UserId = int.Parse(userId ?? "")
                };

                _commentRepository.createComment(entity);

                return Json(new
                {
                    userName,
                    text,
                    entity,
                    entity.CommentDate,
                    avatar
                });
            } else {
                return null;
            }

        }

    }
}