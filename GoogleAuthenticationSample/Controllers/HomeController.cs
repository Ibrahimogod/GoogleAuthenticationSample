using Microsoft.AspNetCore.Mvc;

namespace GoogleAuthenticationSample.Controllers
{
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            return await  Task.FromResult(View());
        }
    }
}
