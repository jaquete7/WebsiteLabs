using DataAccess.CRUD;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLogic
{
    public class AdminRepresentante
    {
        public List<Representante> Obtener(int idLab)
        {
            RepresentanteCrudFactory crud = new RepresentanteCrudFactory();
            return crud.RetrieveAllByLab<Representante>(idLab);
        }
    }
}
