using DataAccess.CRUD;
using DataAccess.CRUD.Cupones;
using DTO;
using DTO.Cupones;
using System.Collections.Generic;

namespace AppLogic.Cupones
{
    public class AdminCupon
    {
        public string Registrar(Cupon cupon)
        {
            CuponCrudFactory crud = new CuponCrudFactory();
            crud.Create(cupon);

            return "Cupon registrado con exito";
        }

        public List<Cupon> Obtener(int idLab)
        {
            CuponCrudFactory crud = new CuponCrudFactory();
            return crud.RetrieveAllByLab<Cupon>(idLab);
        }

        public string EditarCupon(int idCup, int idLab, Cupon cupon)
        {
            CuponCrudFactory crud = new CuponCrudFactory();
            crud.Editar(idCup, idLab, cupon);

            return "Cupon Editado con exito";
        }

        public List<Cupon> ObtenerCupon(int idCup, int idLab)
        {
            CuponCrudFactory crud = new CuponCrudFactory();
            return crud.RetrieveByCupon<Cupon>(idCup, idLab);
        }

        public string EliminarCupon(int idCup, int idLab)
        {
            CuponCrudFactory crud = new CuponCrudFactory();
            crud.Eliminar(idCup, idLab);

            return "Cupon Eliminado con exito";
        }
    }
}
