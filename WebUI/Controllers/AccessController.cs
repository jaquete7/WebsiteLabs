/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class AccessController : Controller
    {
        string urlDomain = "https://localhost:44378";
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        //Inicio de recuperar contraseña
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
                    var oUser = db.usuarios.Where(d=> d.email == model.Email).FirstOrDefault();
                    if (oUser == null)
                    {
                        // aqui editamos el token
                        oUser.token_recovery = token;
                        db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                        //enviar mail

                        SendEmail(oUser.email, token);

                    }
                }

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
            using (Models.Entities db= new Models.Entities())
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
                    var oUser = db.usuarios.Where(d=> d.token_recovery == model.token).FirstOrDefault();
                    
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


            ViewBag.Message = "Contraseña modificada con éxito";
            return View("Login");
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

        //aqui envio el correo

        private void SendEmail(string EmailDestino, string token)
        {
            string EmailOrigen = "nolimitsolutionscr92@gmail.com";
            string Contraseña = "Cenfo123";
            string url = urlDomain + "/Recovery/?token="+token;
            MailMessage oMailMessage = new MailMessage(EmailOrigen, EmailDestino, "Recuperacion de contraseña",
                "<p>Correo para recuperación de contraseña</p><br>"+
                "<a href='"+url+ "' >Click para recuperar</a>");
            oMailMessage.IsBodyHtml = true;

            SmtpClient oSmtpClient = new SmtpClient("smtp.gmail.com");
            oSmtpClient.EnableSsl = true;
            oSmtpClient.UseDefaultCredentials = false;
            oSmtpClient.Port = 587;
            oSmtpClient.Credentials = new System.Net.NetworkCredential(EmailOrigen, Contraseña);

            oSmtpClient.Send(oMailMessage);

            oSmtpClient.Dispose();

        }
        #endregion
    }
}
*/