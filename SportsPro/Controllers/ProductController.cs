using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;
using System.Collections.Generic;
using System.Linq;

namespace SportsPro.Controllers
{
    public class ProductController : Controller
    {
        private SportsProContext context;
        public ProductController(SportsProContext ctx)
        {
            context = ctx;
        }



        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            Product product = new Product();
            return View("AddEdit", product);
        }
        public IActionResult Edit(int id)
        {
            Product product = context.Products.Find(id);
            ViewBag.Action = "Edit";
            return View("AddEdit", product);
        }



        [HttpPost]
        public IActionResult AddEdit(Product product)
        {
            if (ModelState.IsValid)
            {
                if (product.ProductID == 0)
                {
                    context.Products.Add(product);
                }
                // the product from database have to Added
                else
                {
                    context.Products.Update(product);
                }
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                return View("AddEdit", product);
            }
        }





        public IActionResult ProductManager()
        {
            List<Product> products = context.Products.ToList();
            return View(products);
        }






    }
}
