

using BlogNewsApp.Data.Abstract;
using BlogNewsApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;

namespace BlogNewsApp.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public IActionResult Login()
        {
            if(User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("Index", "Post");
            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {

                var isUSer = _userRepository.Users.FirstOrDefault(x=>x.Email == model.Email && x.Password == model.Password);
                if(isUSer != null)
                {
                    var userClaims = new List<Claim>();

                    userClaims.Add(new Claim(ClaimTypes.NameIdentifier, isUSer.UserId.ToString()));
                    userClaims.Add(new Claim(ClaimTypes.Name, isUSer.UserName ?? ""));
                    userClaims.Add(new Claim(ClaimTypes.GivenName, isUSer.Name ?? ""));
                    userClaims.Add(new Claim(ClaimTypes.UserData, isUSer.Image ?? ""));
                    if(isUSer.Email == "au@t.com") {
                        userClaims.Add(new Claim(ClaimTypes.Role, "admin"));
                    }
                    
                    var claimsIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties { IsPersistent= true };

                    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity), authProperties);
                    
                    return RedirectToAction("Index", "Post");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanici adi veya parola yanlis");
                }
            }
            return View(model);
        }
    }
}