using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;
using System;

namespace HairSalon.Controllers
{
    public class SpecialtiesController : Controller
    {
        [HttpGet("/specialties")]
        public ActionResult Index()
        {
            List<Specialty> allSpecialties = Specialty.GetAllSpecialties();
            return View("Index", allSpecialties);
        }

        [HttpGet("/specialties/new")]
        public ActionResult CreateSpecialtyForm()
        {
            return View("CreateSpecialtyForm");
        }

        [HttpPost("/specialties/new")]
        public ActionResult CreateSpecialty()
        {
            Specialty newSpecialty = new Specialty(Request.Form["name"]);
            newSpecialty.Save();

            return RedirectToAction("Index");
        }

        [HttpGet("/specialties/{id}")]
        public ActionResult Details(int id)
        {
            Specialty newSpecialty = Specialty.Find(id);
            List<Stylist> stylists = newSpecialty.GetStylists();
            Dictionary<string,object> model = new Dictionary<string,object>();
            model.Add("specialty", newSpecialty);
            model.Add("stylists", stylists);

            return View("Details", model);
        }
    }
}
