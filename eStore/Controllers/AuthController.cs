using BusinessObject;
using DataAccess.Repository;
using eStore.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace eStore.Controllers
{
    public class AuthController : Controller
    {
        IMemberRepository _memberRepository = new MemberRepository();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(MemberObject user)
        {
            try
            {
                _memberRepository.InsertMember(user);
                return Redirect("/home");
            }
            catch (Exception)
            {
                TempData["Error"] = "Invalid Id/Password";
                return RedirectToAction("Signup");
            }
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/home");
        }

        [HttpGet("login")]
        public IActionResult Login(string returnUrl)
        {
            TempData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Validate(MemberObject user, string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (user.Email == "admin@gmail.com" && user.Password == "admin")
            {
                var claims = new List<Claim>();
                claims.Add(new Claim("email", user.Email));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Email));
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults
                    .AuthenticationScheme);
                var claimsPricipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPricipal);
                return Redirect(returnUrl);
            }else if (_memberRepository.GetMembers().FirstOrDefault(m=>m.Email==user.Email && m.Password == user.Password) !=null)
            {
                var claims = new List<Claim>();
                claims.Add(new Claim("email", user.Email));
                claims.Add(new Claim("id", user.MemberId.ToString()));
                claims.Add(new Claim(ClaimTypes.Role, "member"));
                claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Email));
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults
                    .AuthenticationScheme);
                var claimsPricipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPricipal);
                if (returnUrl == null)
                {
                    return Redirect("/home");
                }
                return Redirect(returnUrl);
            }
            TempData["Error"] = "Error. Username or password is invalid";
            return View("login");
        }
    }
}
