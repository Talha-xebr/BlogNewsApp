using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BlogNewsApp.ViewComponents
{
    public class TwitterEmbed : ViewComponent
    {
        public IViewComponentResult Invoke() {
            return View();
        }
    }
}