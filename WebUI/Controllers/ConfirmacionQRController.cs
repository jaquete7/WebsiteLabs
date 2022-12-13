using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class ConfirmacionQRController : Controller
    {

        public ActionResult ConfirmacionQR(string nom, string id, string lab, string con, string exa, string tel, string email, string dir, string correoUsuario)
        {

            return View();
        }
    }
}
