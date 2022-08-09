using BusinessObject;
using DataAccess.Repository;
using eStore.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SendGrid;
using SendGrid.Helpers.Mail;
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
        public async Task<IActionResult> Signup(MemberObject user)
        {
            if (ModelState.IsValid && (_memberRepository.GetMemberByEmail(user.Email)==null))
            {
                try
                {
                    var code = Guid.NewGuid().ToString();
                    var client = new SendGridClient("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");
                    var from = new EmailAddress("phamsn2001@gmail.com");
                    var to = new EmailAddress(user.Email);
                    var subject = "Confirmation code";
                    var text = code;
                    var textHTML = code;
                    var msg = MailHelper.CreateSingleEmail(from, to, subject, text, textHTML);
                    var response = await client.SendEmailAsync(msg);
                    TempData["PopupMessages"] = JsonConvert.SerializeObject(user);
                    TempData["code"] = code;
                    return RedirectToAction("confirmcode");
                }
                catch (Exception)
                {
                    TempData["Error"] = "Invalid Id/Password";
                    return RedirectToAction("Signup");
                }
            }
            TempData["Error"] = "Invalid Username";
            return RedirectToAction("Signup");
        }

        public IActionResult ConfirmCode()
        {
            MemberObject tmp = JsonConvert.DeserializeObject<MemberObject>(TempData["PopupMessages"] as string);
            return View(new UserModel
            {
                user = tmp,
                confirmationCode = TempData["code"] as string
            });
        }

        [HttpPost]
        public async Task<IActionResult> Resend(MemberObject user)
        {
            var code = Guid.NewGuid().ToString();
            var client = new SendGridClient("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");
            var from = new EmailAddress("phamsn2001@gmail.com");
            var to = new EmailAddress(user.Email);
            var subject = "Confirmation code";
            var text = code;
            var textHTML = code;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, text, textHTML);
            var response = await client.SendEmailAsync(msg);
            TempData["PopupMessages"] = JsonConvert.SerializeObject(user);
            TempData["code"] = code;
            return RedirectToAction("confirmcode");
        }

        [HttpPost]
        public IActionResult ConfirmCode(MemberObject user, string confirmationCode, string inputConfirmationCode)
        {
            if(confirmationCode == inputConfirmationCode)
            {
                _memberRepository.InsertMember(user);
                return Redirect("/home");
            }
            else
            {
                TempData["Error"] = "Wrong Code";
                return RedirectToAction("ConfirmCode");
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
                return Redirect("product");
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
