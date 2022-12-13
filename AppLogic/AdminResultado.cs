using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Data;
using System.Net;
using System.Net.Mail;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Xml.Linq;
using System.Web.UI;
using DataAccess.CRUD;
using DTO;

namespace AppLogic
{
    public class AdminResultado
    {
        public string Registrar(Resultado resultado)
        {
            ResultadoCrudFactory crud = new ResultadoCrudFactory();
            crud.Create(resultado);

            return "Success";
        }
        public List<Resultado> ObtenerResultados(int usuario)
        {
            ResultadoCrudFactory crud = new ResultadoCrudFactory();
            return crud.RetrieveAllByUser<Resultado>(usuario);
        }
    }

}
