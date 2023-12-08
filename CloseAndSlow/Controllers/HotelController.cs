using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CloseAndSlow.Controllers
{
    public class HotelController : Controller
    {
        // GET: Hotel
        public ActionResult HotelVilan()
        {
           //pasamos los datos directamente por ViewBag
            ViewBag.Id = 1;
            ViewBag.Nombre = "Cabo Vilán";
            return View();
        }
    }
}