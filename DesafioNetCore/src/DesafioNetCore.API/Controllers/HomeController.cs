using Microsoft.AspNetCore.Mvc;

namespace DesafioNetCore.API.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
