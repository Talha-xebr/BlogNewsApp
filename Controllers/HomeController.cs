using BlogNewsApp.Data.Abstract;
using BlogNewsApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogNewsApp.Controllers
{
    public class HomeController : Controller
    {
        public  IActionResult Index() {
            return View();
        }
    }
}