using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogNewsApp.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogNewsApp.ViewComponents
{
    public class PopularPosts : ViewComponent
    {
        // db context
        private IPostRepository _postRepository;
        public PopularPosts(IPostRepository postRepository)
        {
            this._postRepository = postRepository;
        }

        // make async later when we add db context
        public async Task<IViewComponentResult> InvokeAsync() {
            return View(await _postRepository.Posts.OrderByDescending(p => p.Comments.Count()).Take(2).Include(x=>x.Comments).ToListAsync());
        }
    }
}