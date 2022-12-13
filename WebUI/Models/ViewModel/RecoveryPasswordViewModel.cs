using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.Models.ViewModel
{
    public class RecoveryPasswordViewModel
    {
        public string token { get; set; }
        //quiero que sea obligatorio
        [Required]
        public string Password { get; set; }

        [Compare ("Password")]
        [Required]
        public string Password2 { get; set; }

    }
}
