//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebUI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class usuarios
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string provincia { get; set; }
        public string canton { get; set; }
        public string distrito { get; set; }
        public string direccion { get; set; }
        public string celular { get; set; }
        public string email { get; set; }
        public string email_pagos { get; set; }
        public string password { get; set; }
        public string ruta_foto { get; set; }
        public string rol { get; set; }
        public Nullable<int> id_custom_rol { get; set; }
        public string permisos { get; set; }
        public System.DateTime fecha_registro { get; set; }
        public int estado { get; set; }
        public string token_recovery { get; set; }
    }
}
