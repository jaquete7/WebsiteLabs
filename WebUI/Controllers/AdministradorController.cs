using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class AdministradorController : Controller
    {
        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult ActualizarAdministrador()
        {
            return View();
        }
    }
}