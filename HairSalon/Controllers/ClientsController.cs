using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;
using System;

namespace HairSalon.Controllers
{
    public class ClientsController : Controller
    {
        [HttpGet("/clients")]
        public ActionResult Index()
        {
            List<Client> allClients = Client.GetAllClients();
            return View("Index", allClients);
        }

        [HttpGet("/stylists/{stylistId}/clients/new")]
        public ActionResult CreateClientForm(int stylistId)
        {
             Stylist foundStylist = Stylist.Find(stylistId);
             return View(foundStylist);
        }

        [HttpGet("/clients/{id}/delete")]
        public ActionResult DeleteClient(int id)
        {
            Client foundClient = Client.Find(id);
            int stylistId = foundClient.GetStylistId();
            foundClient.Delete();
            return RedirectToAction("Details", "stylists", new{Id=stylistId});
        }

        [HttpGet("/clients/delete")]
        public ActionResult DeleteAllClients()
        {
            Client.DeleteAll();
            return RedirectToAction("Index");
        }

        [HttpGet("/clients/{id}")]
        public ActionResult Details(int id)
        {
            Client foundClient = Client.Find(id);
            Stylist foundStylist = Stylist.Find(foundClient.GetStylistId());
            Dictionary<string, object> model = new Dictionary<string, object>();
            model.Add("client", foundClient);
            model.Add("stylist", foundStylist);

            return View("Details", model);
        }

        [HttpGet("/clients/{id}/update")]
        public ActionResult UpdateClientForm(int id)
        {
            Client foundClient = Client.Find(id);
            List<Stylist> allStylists = Stylist.GetAllStylists();
            Dictionary<string, object> model = new Dictionary<string, object>();
            model.Add("client", foundClient);
            model.Add("stylists", allStylists);
            return View("UpdateClientForm", model);
        }

        [HttpPost("/clients/{id}/update")]
        public ActionResult UpdateClient(int id)
        {
            int stylistId = Int32.Parse(Request.Form["stylist"]);
            Client foundClient = Client.Find(id);
            foundClient.Edit(Request.Form["c-first-name"], Request.Form["c-last-name"], Request.Form["phone-number"], stylistId);

            return RedirectToAction("Index");
        }

    }
}
