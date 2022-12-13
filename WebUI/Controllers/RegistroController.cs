using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class RegistroController : Controller
    {
        // GET: Registro
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Paciente()
        {
            ViewBag.Message = "Registro Usuarios";

            return View();
        }

        public ActionResult Proveedor()
        {
            ViewBag.Message = "Registro Proveedor";
            return View();
        }

        public ActionResult Laboratorio()
        {
            ViewBag.Message = "Registro Laboratorios";

            return View();
        }
        public ActionResult VerificacionOTP()
        {
            ViewBag.Message = "Verificacion OTP";

            return View();
        }
    }
}