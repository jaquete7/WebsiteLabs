using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class CitasController : Controller
    {
        // GET: Citas
        public ActionResult CitasLaboratorio()
        {
            return View();
        }
        public ActionResult Proximas()
        {
            return View();
        }
        public ActionResult AgendarCita()
        {
            return View();
        }
        public ActionResult ReAgendarCita()
        {
            return View();
        }
       
        public ActionResult Anteriores()
        {
            return View();
        }
    }
}