using Microsoft.AspNetCore.Mvc;
using SportsPro.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SportsPro.Controllers
{
    public class IncidentsController : Controller
    {
        private SportsProContext context { get; set; }
        public IncidentsController(SportsProContext ctx)
        {
            context = ctx;
        }
        [Route("Incidents")]
        public IActionResult List()
        {
            List<Incident> incidents;
            incidents = context.Incidents.ToList();
            return View(incidents);

        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("Edit", new Incident());
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            var incident = context.Incidents.Find(id);
            return View(incident);
        }
        [HttpPost]
        public IActionResult Edit(Incident incident)
        {
            if (ModelState.IsValid)
            {
                if (incident.IncidentID == 0)
                    context.Incidents.Add(incident);
                else
                    context.Incidents.Update(incident);
                context.SaveChanges();
                return RedirectToAction("List", incident);
            }
            else
            {
                ViewBag.Action = (incident.IncidentID == 0) ? "Add" : "Edit";
                return View(incident);
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var incident = context.Incidents.Find(id);
            return View(incident);
        }
        [HttpPost]
        public IActionResult Delete(Incident incident)
        {
            context.Incidents.Remove(incident);
            context.SaveChanges();
            return RedirectToAction("List", incident);
        }

    }
}

