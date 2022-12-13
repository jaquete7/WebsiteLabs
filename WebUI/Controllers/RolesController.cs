using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class RolesController : Controller
    {
        public ActionResult RegistrarRolLaboratorio()
        {
            return View();
        }
        public ActionResult RegistrarRolAdmin()
        {
            return View();
        }
        public ActionResult ListarRolesAdmin()
        {
            return View();
        }
        public ActionResult ListarRolesProveedor()
        {
            return View();
        }
        public ActionResult EditarRolProveedor()
        {
            return View();
        }
        public ActionResult EditarRolAdmin()
        {
            return View();
        }
    }
}