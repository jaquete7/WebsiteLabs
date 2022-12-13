using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.Models.ViewModel
{
    public class RecoveryViewModel
    {
        //esto va a validar que exista el correo electronico, que sea valido su formato
        [EmailAddress]
        //quiero que sea obligatorio
        [Required]
        public string Email{get; set; }
    }
}