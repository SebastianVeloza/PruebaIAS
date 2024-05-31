using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    public class ApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
