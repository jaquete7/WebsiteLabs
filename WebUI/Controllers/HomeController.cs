using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{

    public class HomeController : Controller
    {
        string urlDomain = "https://nolimits.azurewebsites.net/";
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Login page.";

            return View();
        }
        public ActionResult Producto()
        {
            ViewBag.Message = "Login page.";

            return View();
        }

        [HttpPost]
        public string EnviarQR (string nom, string id, string lab, string con, string exa, string tel, string email, string dir, string correoUsuario)
        {
            try {
                string EmailOrigen = "nolimitsolutionscr92@gmail.com";
                string Contraseña = "eqqrzaqbhpylvdor";
                string URL = "https://nolimits.azurewebsites.net/ConfirmacionQR/ConfirmacionQR?" +
                    "nom=" + nom + "&" +
                    "id=" + id + "&" +
                    "lab=" + lab + "&" +
                    "con=" + con + "&" +
                    "exa=" + exa + "&" +
                    "tel=" + tel + "&" +
                    "email=" + email + "&" +
                    "dir=" + dir;
                string ContenidoHTML =
                                       // "<script src=\"https://cdn.rawgit.com/davidshimjs/qrcodejs/gh-pages/qrcode.min.js\"></script>"+
                                       // "<script>function generar(){let qrcodeContainer = document.getElementById(\"qrcode\");qrcodeContainer.innerHTML = \"\";new QRCode(qrcodeContainer, '" +URL+"');}</script>"+
                                        "<body>" +
                                        "<div>" +
                                        "<b>Datos de la cita: </b><br/>" +
                                        "<b>Nombre:" + nom + "</b><br/>" +
                                        "<b>Id:" + id + "</b><br/>" +
                                        "<b>Laboratorio:" + lab + "</b><br/>" +
                                        "<b>Fecha:" + con + "</b><br/>" +
                                        "<b>Examen:" + exa + "</b><br/>" +
                                        "<b>Telefono:" + tel + "</b><br/>" +
                                        "<b>Correo:" + email + "</b><br/>" +
                                        "<b>Direccion:" + dir + "</b><br/>" +
                                        "</div>" +
                                        "<a href=\""+URL+"\">Confirmar Cita</a>"+
                                        //"<div id='qrcode'></div>" +
                                        "</body>";
                MailMessage oMailMessage = new MailMessage(EmailOrigen, correoUsuario, "Confirmación de su cita", ContenidoHTML );
                oMailMessage.IsBodyHtml = true;

                SmtpClient oSmtpClient = new SmtpClient("smtp.gmail.com");
                oSmtpClient.EnableSsl = true;
                oSmtpClient.UseDefaultCredentials = false;
                oSmtpClient.Port = 587;
                oSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                oSmtpClient.Credentials = new System.Net.NetworkCredential(EmailOrigen, Contraseña);

                oSmtpClient.Send(oMailMessage);

                oSmtpClient.Dispose();

                return "enviado";

            } catch (Exception ex) {

                return ex.Message;
            }
            
        }

        [HttpGet]
        public ActionResult StartRecovery()
        {
            Models.ViewModel.RecoveryViewModel model = new Models.ViewModel.RecoveryViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult StartRecovery(Models.ViewModel.RecoveryViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                string token = GetSha256(Guid.NewGuid().ToString());

                using (Models.Entities db = new Models.Entities())
                {
                    //aqui valido que el correo del usuario en data sea igual al que traigo en mi model
                    var oUser = db.usuarios.Where(d => d.email == model.Email).FirstOrDefault();
                    if (oUser != null)
                    {
                        // aqui editamos el token
                        oUser.token_recovery = token;
                        db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        //enviar mail
                        
                        SendEmail(oUser.email, token);

                    }
                }
                ViewBag.Message = "Se ha enviado un enlace a su correo Electrónico";
                return View();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        //cuando recibo un correo de parte de mi sistema e ingreso new password
        //el recovery va a recibir el token
        [HttpGet]
        public ActionResult Recovery(string token)
        {
            Models.ViewModel.RecoveryPasswordViewModel model = new Models.ViewModel.RecoveryPasswordViewModel();
            model.token = token;
            using (Models.Entities db = new Models.Entities())
            {

                //aqui hacemos que el token una vez utilizado sea null y ya no se pueda recuperar contraseña con el mismo token
                if (model.token == null || model.token.Trim().Equals(""))
                {
                    return View("Login");
                }
                //en caso que el token exista, va a ir al usuario a buscarlo
                var oUser = db.usuarios.Where(d => d.token_recovery == model.token).FirstOrDefault();
                if (oUser == null)
                {
                    ViewBag.Error = "Token Expirado";
                    return View("Login");
                }
            }

            return View(model);
        }
        [HttpPost]
        public ActionResult Recovery(Models.ViewModel.RecoveryPasswordViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                using (Models.Entities db = new Models.Entities())
                {
                    var oUser = db.usuarios.Where(d => d.token_recovery == model.token).FirstOrDefault();

                    if (oUser != null)
                    {
                        oUser.password = model.Password;
                        oUser.token_recovery = null;
                        db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


           
            return View("Login");
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }


        [HttpPost]
        public string SendFactura(string destino, int clave, string detalle, string descuento, float impuesto, float total, string fecha)
        {
            SendEmailFactura(destino, clave, detalle, descuento, impuesto, total, fecha);
            return "success";
        }

        [HttpPost]
        public string SendResultado(string destino, string descripcion, string evaluacion, int idCita)
        {
            SendEmailResultado(destino, descripcion, evaluacion, idCita);
            return "success";
        }


        #region Helpers
        private string GetSha256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        //aqui envio el correow

        private void SendEmail(string EmailDestino, string token)
        {
            string EmailOrigen = "nolimitsolutionscr92@gmail.com"; 
            string Contraseña = "eqqrzaqbhpylvdor";
            string url = urlDomain + "Home/Recovery/?token=" + token;
            MailMessage oMailMessage = new MailMessage(EmailOrigen, EmailDestino, "Recuperacion de contraseña",
                "<p>Recibimos una solicitud para restablecer la contraseña" +
                "de su cuenta NoLimitsApp, utilice el siguiente enlace" +
                "de autenticación para restablecer su contraseña.</p><br>" +
                "<a href='" + url + "' >Click para recuperar</a>");
            oMailMessage.IsBodyHtml = true;

            SmtpClient oSmtpClient = new SmtpClient("smtp.gmail.com");
            oSmtpClient.EnableSsl = true;
            oSmtpClient.UseDefaultCredentials = false;
            oSmtpClient.Port = 587;
            oSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            oSmtpClient.Credentials = new System.Net.NetworkCredential(EmailOrigen, Contraseña);

            oSmtpClient.Send(oMailMessage);

            oSmtpClient.Dispose();

        }

        private void SendEmailFactura(string destino, int clave, string detalle, string descuento, float impuesto, float total, string fecha )
        {
            string ruta = "https://nolimits.azurewebsites.net";
            string EmailOrigen = "nolimitsolutionscr92@gmail.com";
            string Contraseña = "eqqrzaqbhpylvdor";
            string url = ruta + "/Factura?clave="+ clave + "&detalle="+ detalle + "&descuento="+ descuento + "&impuesto="+ impuesto + "&total="+ total + "&fecha="+ fecha;
            
            MailMessage oMailMessage = new MailMessage(EmailOrigen, destino, "Factura NoLimitsSolutions",
            "<div> <h1>Factura NoLimitsSolutions</h1> <table> <caption>Gracias por tu compra</caption>  <tr> <th>Tipo:</th> <th>Clave numerica:</th> <th>Condición de Venta</th> <th>Medio de pago</th> <th>Detalle</th>  <th>Descuento</th> <th>Impuesto</th> <th>Total</th> <th>Fecha y Hora</th> </tr> <tr> "
            + "<td> Factura Electrónica </td>"
            + "<td>" + clave + "</td>"
            + "<td> Al contado </td>"
            + "<td> Tarjeta </td>"
            + "<td>" + detalle + "</td>"
            + "<td>" + descuento + "</td>"
            + "<td> $" + impuesto + "</td>"
            + "<td> $" + total + "</td>"
            + "<td>" + fecha + "</td>"
            + "</tr>  </table>  <strong> <a href='"+ url + "'> Accede aqui para descargar en PDF o XML</a> </strong> </div>"
            );
            oMailMessage.IsBodyHtml = true;

            SmtpClient oSmtpClient = new SmtpClient("smtp.gmail.com");
            oSmtpClient.EnableSsl = true;
            oSmtpClient.UseDefaultCredentials = false;
            oSmtpClient.Port = 587;
            oSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            oSmtpClient.Credentials = new System.Net.NetworkCredential(EmailOrigen, Contraseña);

            oSmtpClient.Send(oMailMessage);

            oSmtpClient.Dispose();

        }

        private void SendEmailResultado(string destino, string descripcion, string evaluacion, int idCita)
        {
            string ruta = "https://nolimits.azurewebsites.net";
            string EmailOrigen = "nolimitsolutionscr92@gmail.com";
            string Contraseña = "eqqrzaqbhpylvdor";
            string url = ruta + "/Resultado?descripcion=" + descripcion + "&evaluacion=" + evaluacion + "&idCita=" + idCita;

            MailMessage oMailMessage = new MailMessage(EmailOrigen, destino, "Resultado Examen NoLimitsSolutions",
            /*
            "<div> <h1>Resultado Examen NoLimitsSolutions</h1> <table> <caption>Gracias por preferirnos</caption>  <tr> <th>Descripción</th>  <th>Evaluación</th> </tr> <tr> "
            
            + "<td>" + descripcion + "</td>"
            + "<td>" + evaluacion + "</td>"
            */
            
            "</tr>  </table>  <strong> <a href='" + url + "'> Accede aqui para descargar en PDF o XML</a> </strong> </div>"
            );
            oMailMessage.IsBodyHtml = true;

            SmtpClient oSmtpClient = new SmtpClient("smtp.gmail.com");
            oSmtpClient.EnableSsl = true;
            oSmtpClient.UseDefaultCredentials = false;
            oSmtpClient.Port = 587;
            oSmtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            oSmtpClient.Credentials = new System.Net.NetworkCredential(EmailOrigen, Contraseña);

            oSmtpClient.Send(oMailMessage);

            oSmtpClient.Dispose();

        }
        #endregion
    }
}