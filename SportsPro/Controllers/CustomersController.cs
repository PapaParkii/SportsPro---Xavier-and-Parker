using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;
using System.Linq;

namespace SportsPro.Controllers
{
    public class CustomersController : Controller
    {

        private SportsProContext context;
        public CustomersController(SportsProContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("Customers")]
        public ViewResult Customer()
        {
            var customers = context.Customers.ToList();
            return View(customers);
        }



    }
}
