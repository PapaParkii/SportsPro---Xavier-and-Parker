using Microsoft.AspNetCore.Mvc;

namespace SportsPro.Controllers
{
    public class CustomerController : Controller
    {

        private readonly SportsProContext _context;

        public CustomerController(SportsProContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            var customers = _context.Customers.ToList();
            return View("Customers/List", customers);
        }


        public IActionResult AddEdit(int? id)
        {
            /
            var customer = id.HasValue ? _context.Customers.Find(id) : new Customer();

            
            ViewBag.Countries = _context.Countries.ToList();

            return View(customer);

            [HttpPost]
            public IActionResult AddEdit(Customer customer)
            {
                if (ModelState.IsValid)
                {
                    if (customer.CustomerID == 0)
                        _context.Customers.Add(customer);
                    else
                        _context.Customers.Update(customer);

                    _context.SaveChanges();
                    return RedirectToAction("List");
                }

                
                ViewBag.Countries = _context.Countries.ToList();
                return View(customer);

            }

            public IActionResult Delete(int id)
            {
                var customer = _context.Customers.Find(id);
                return View(customer);
            }


            [HttpPost]
            public IActionResult ConfirmDelete(int id)
            {
                var customer = _context.Customers.Find(id);

                if (customer != null)
                {
                    _context.Customers.Remove(customer);
                    _context.SaveChanges();
                }

                return RedirectToAction("List");
            }




        }




    }
}
