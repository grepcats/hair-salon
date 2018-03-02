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
    }
}
