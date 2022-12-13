using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class LaboratorioController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Laboratorios Registrados";

            return View();
        }
        public ActionResult Registrar()
        {
            return View();
        }
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Informacion()
        {
            return View();
        }
        public ActionResult Examenes()
        {
            return View();
        }
        public ActionResult EditarLaboratorio()
        {
            return View();
        }
    }
}