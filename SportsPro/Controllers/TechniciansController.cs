using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SportsPro.Controllers
{
    public class TechniciansController : Controller
    {
        private SportsProContext context { get; set; }
        public TechniciansController(SportsProContext ctx)
        {
            context = ctx;
        }


        [Route("Technicians")]
        public IActionResult List()
        {
            List<Technician> technicians;
            technicians = context.Technicians.ToList();
            return View(technicians);

        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Technician());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var technician = context.Technicians.Find(id);
            return View(technician);
        }
        [HttpPost]
        public IActionResult Edit(Technician technician)
        {
            if (ModelState.IsValid)
            {
                if (technician.TechnicianID == 0)
                    context.Technicians.Add(technician);
                else
                    context.Technicians.Update(technician);
                context.SaveChanges();
                return RedirectToAction("List", technician);
            }
            else
            {
                ViewBag.Action = (technician.TechnicianID == 0) ? "Add" : "Edit";
                return View(technician);
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var technician = context.Technicians.Find(id);
            return View(technician);
        }
        [HttpPost]
        public IActionResult Delete(Technician technician)
        {
            context.Technicians.Remove(technician);
            context.SaveChanges();
            return RedirectToAction("List", technician);
        }

    }
}

