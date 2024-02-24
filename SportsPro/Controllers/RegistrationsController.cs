using Microsoft.AspNetCore.Mvc;

namespace SportsPro.Controllers
{
    public class RegistrationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
