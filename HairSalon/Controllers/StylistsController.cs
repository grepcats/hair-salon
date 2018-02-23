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
            List<Stylist> testList = new List<Stylist>{};
            return View("Index", testList);
        }
    }
}
