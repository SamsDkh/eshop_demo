using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace eShop.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        [Route("/authenticate")]
        public async Task<IActionResult> Authenticate([FromQuery]string usr, [FromQuery]string pwd)
        {
            if (usr.Equals("admin") && pwd.Equals("adminadmin"))
            {
                var userClaims = new List<Claim>()
                {
                    new(ClaimTypes.Name, usr),
                    new(ClaimTypes.Email, "admin@eshop.com"),
                    new(ClaimTypes.HomePhone, "0146587856")
                };

                var userIdentity = new ClaimsIdentity(userClaims, "eShop.CookieAuth");
                var userPrincipal = new ClaimsPrincipal(userIdentity);

                await HttpContext.SignInAsync("eShop.CookieAuth", userPrincipal);
            }
            return Redirect("/outstandingorders");
        }

        [Route("/logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return Redirect("/");
        }
    }
}
