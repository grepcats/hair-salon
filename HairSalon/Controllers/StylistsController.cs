using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;
using System;

namespace HairSalon.Controllers
{
    public class StylistsController : Controller
    {
        [HttpGet("/stylists")]
        public ActionResult Index()
        {
            List<Stylist> allStylists = Stylist.GetAllStylists();
            return View("Index", allStylists);
        }

        [HttpGet("/stylists/new")]
        public ActionResult CreateStylistForm()
        {
            return View();
        }

        [HttpPost("/stylists")]
        public ActionResult CreateNewStylist()
        {
            Stylist newStylist = new Stylist(Request.Form["s-first-name"], Request.Form["s-last-name"]);
            newStylist.Save();
            return RedirectToAction("Index");
        }

        [HttpGet("/stylists/{id}")]
        public ActionResult Details(int id)
        {
            Stylist foundStylist = Stylist.Find(id);
            List<Client> clients = foundStylist.GetClients();
            List<Specialty> specialties = foundStylist.GetSpecialties();
            List<Specialty> allSpecialties = Specialty.GetAllSpecialties();
            Dictionary<string, object> model = new Dictionary<string,object>();
            model.Add("stylist", foundStylist);
            model.Add("clients", clients);
            model.Add("specialties", specialties);
            model.Add("allSpecialties", allSpecialties);

            return View("Details", model);
        }

        [HttpPost("/stylists/{id}/clients")]
        public ActionResult CreateNewClient(int id)
        {
            Client newClient = new Client(Request.Form["c-first-name"], Request.Form["c-last-name"], Request.Form["phone-number"]);
            newClient.SetStylistId(id);
            newClient.Save();
            return RedirectToAction("Details");
        }

        [HttpGet("/stylists/{id}/delete")]
        public ActionResult DeleteStylist(int id)
        {
            Stylist foundStylist = Stylist.Find(id);
            foundStylist.Delete();
            return RedirectToAction("Index");
        }

        [HttpGet("/stylists/delete")]
        public ActionResult DeleteAllStylists()
        {
            Stylist.DeleteAll();

            return RedirectToAction("Index");
        }

        [HttpGet("/stylists/{id}/update")]
        public ActionResult UpdateStylistForm(int id)
        {
            Stylist foundStylist = Stylist.Find(id);
            return View("UpdateStylistForm", foundStylist);
        }

        [HttpPost("/stylists/{id}/update")]
        public ActionResult UpdateStylist(int id)
        {
            Stylist foundStylist = Stylist.Find(id);
            foundStylist.Edit(Request.Form["s-first-name"], Request.Form["s-last-name"]);
            return RedirectToAction("Index");
        }

        [HttpPost("/stylists/{id}/add-specialty")]
        public ActionResult AddSpecialty(int id)
        {
            int specialtyId = Int32.Parse(Request.Form["add-specialty"]);
            Stylist foundStylist = Stylist.Find(id);
            Specialty foundSpecialty = Specialty.Find(specialtyId);
            foundStylist.AddSpecialty(foundSpecialty);

            return RedirectToAction("Details");
        }





    }
}
