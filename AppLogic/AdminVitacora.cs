using DataAccess.CRUD;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
    public class AdminVitacora
    {
        public List<Vitacora> Obtener() {
            VitacoraCrudFactory crud = new VitacoraCrudFactory();
            return crud.RetrieveAll<Vitacora>();
        }
    }
}
