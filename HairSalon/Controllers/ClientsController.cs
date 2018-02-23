using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Models;
using System;

namespace HairSalon.Controllers
{
    public class ClientsController : Controller
    {
        [HttpGet("/stylists/{stylistId}/clients/new")]
        public ActionResult CreateClientForm(int stylistId)
        {
         Stylist foundStylist = Stylist.Find(stylistId);
         return View(foundStylist);
        }
    }
}
