using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;
using System.Collections.Generic;
using System.Linq;

namespace SportsPro.Controllers
{
    public class ProductsController : Controller
    {
        private SportsProContext context;
        public ProductsController(SportsProContext ctx)
        {
            context = ctx;
        }



      //  public IActionResult Index()
      //  {
      //      return View();
      //  }


        [HttpGet]
        public ViewResult Add()
        {
            ViewBag.Action = "Add";
            Product product = new Product();
            TempData["message"] =
            $"{product.Name} successfully added.";
            return View("AddEdit", product);
        }
        public ViewResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            Product product = context.Products.Find(id);
            TempData["message"] =
            $"{product.Name} successfully edited.";


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
                
                else
                {
                    context.Products.Update(product);
                }
                context.SaveChanges();
                return RedirectToAction("Product");
            }
            else
            {
                return View("AddEdit", product);
            }
        }




        [Route("Products")]
        public ViewResult Product()
        {
            var products = context.Products.ToList();
            return View(products);
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            var products = context.Products.Find(id);
            return View(products);
        }

        [HttpPost]
        public RedirectToActionResult Delete(Product products)
        {
            context.Products.Remove(products);
            context.SaveChanges();
            TempData["message"] =
    $"{products.Name} successfully deleted.";
            return RedirectToAction("Product", "Products");
        }






    }
}
