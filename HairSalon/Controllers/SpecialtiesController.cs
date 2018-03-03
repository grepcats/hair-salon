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
            return View();
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
            List<Stylist> allStylists = Stylist.GetAllStylists();
            Dictionary<string,object> model = new Dictionary<string,object>();
            model.Add("specialty", newSpecialty);
            model.Add("stylists", stylists);
            model.Add("allStylists", allStylists);

            return View("Details", model);
        }

        [HttpPost("/specialties/{id}/add-stylist")]
        public ActionResult AddStylist(int id)
        {
            int stylistId = Int32.Parse(Request.Form["add-stylist"]);
            Stylist foundStylist = Stylist.Find(stylistId);
            Specialty foundSpecialty = Specialty.Find(id);
            foundSpecialty.AddStylist(foundStylist);

            return RedirectToAction("Details");
        }

        [HttpGet("/specialties/{id}/delete")]
        public ActionResult Delete(int id)
        {
            Specialty foundSpecialty = Specialty.Find(id);
            foundSpecialty.Delete();

            return RedirectToAction("Index");
        }
    }
}
