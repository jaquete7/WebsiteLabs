using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class ContactanosController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Contacto";
            return View();
        }
    }
}