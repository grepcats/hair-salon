using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class StylistsController : Controller
    {
        [Route("/")]
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
            Stylist newStylist = new Stylist(Request.Form["s-first-name"], Request.Form["s-last-name"], Request.Form["specialty"]);
            newStylist.Save();
            return RedirectToAction("Index");
        }

        [HttpGet("/stylists/details/{id}")]
        public ActionResult Details()
        {
            List<Client> clients = new List<Client>{};
            return View("Details", clients);
        }
    }
}
