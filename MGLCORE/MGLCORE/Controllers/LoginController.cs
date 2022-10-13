using Core.JWT;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace MGLCORE.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthApiService authApiService;
        private readonly IUserService person;
        public LoginController(IAuthApiService _authApiService, IUserService _person)
        {
            authApiService = _authApiService;
            person = _person;
        }
        public IActionResult Index()
        {
            authApiService.DeleteToken();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Giris([FromForm] Login user)
        {

            string jsonToken = authApiService.GetToken(user).Result;
            AccessToken token = JsonConvert.DeserializeObject<AccessToken>(jsonToken);
            authApiService.SetToken(token);
            Users usr = new Users();
            usr.Id = token.UserId;
            usr.Name_Surname = token.Name;
            usr.Email = token.Email;

            //usr = person.GetUserByID(usr).data;


            if (user != null)
            {
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, user.Email),                        
                        new Claim(ClaimTypes.Role, "Admin")
                    };

                var claimsIdentity = new ClaimsIdentity(claims, "Giris");

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                //CookieOptions options = new CookieOptions();
                //options.Expires = DateTime.Now.AddDays(2);
                //Response.Cookies.Append("email", user.Email, options);
                //Response.Cookies.Append("sifre", user.Password, options);

                return RedirectToAction("Page", "Login",usr);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }




            //if (token != null)
            //{
            //    return RedirectToAction("page", token);
            //}

            //return RedirectToAction("index");


        }
        //[HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            authApiService.DeleteToken();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Page(Users usr)

        {

            return View(usr);

            //if (HttpContext.Session.GetString("token")!=null)
            //{
            //if (User.Identity.IsAuthenticated)
            //{

            //}
            //else
            //{
            //     return RedirectToAction("Index", "Home");
            //}

            //}
            //else
            //{

            //    return RedirectToAction("index");
            //}

        }
    }
}
    
