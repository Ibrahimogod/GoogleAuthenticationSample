using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;

namespace GoogleAuthenticationSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpGet]
        [Route("google-login")]
        public async Task<IActionResult> GoogleLogin(string? redirectUri)
        {
            if (string.IsNullOrWhiteSpace(redirectUri))
                redirectUri = Url.Content("/");

            var properties = new AuthenticationProperties()
            {
                RedirectUri = redirectUri
            }; 

            return await Task.FromResult(Challenge(properties, GoogleDefaults.AuthenticationScheme));
        }

        [HttpGet]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("/Home/Index");
        }
    }
}
