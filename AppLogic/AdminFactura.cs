using DataAccess.CRUD;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
    public class AdminFactura
    {
        public string Registrar(Factura factura)
        {
            FacturaCrudFactory crud = new FacturaCrudFactory();
            crud.Create(factura);

            return "Success";
        }
        public List<Factura> ObtenerFacturas(int usuario)
        {
            FacturaCrudFactory crud = new FacturaCrudFactory();
            return crud.RetrieveAllByUser<Factura>(usuario);
        }
    }
}
