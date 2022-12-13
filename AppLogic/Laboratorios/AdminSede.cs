using DataAccess.CRUD.Examenes;
using DataAccess.CRUD.Laboratorios;
using DTO;
using System.Collections.Generic;

namespace AppLogic.Laboratorios
{
    public class AdminSede
    {
        public string Registrar(Sede sede)
        {
            SedeCrudFactory crud = new SedeCrudFactory();
            crud.Create(sede);

            return "Laboratorio registrado con exito";
        }

        public List<Sede> Obtener(int id)
        {
            SedeCrudFactory crud = new SedeCrudFactory();
            //Es aqui donde se transforma el objeto tipo T a tipo Pedido
            return crud.RetrieveAllBySede<Sede>(id);
        }

        public string EditarSede(int idSede, int idLab, Sede sede)
        {
            SedeCrudFactory crud = new SedeCrudFactory();
            crud.Editar(idSede, idLab, sede);

            return "Sede Editada con exito";
        }
        public string EliminarSede(int idSede, int idLab)
        {
            SedeCrudFactory crud = new SedeCrudFactory();
            crud.Eliminar(idSede, idLab);

            return "Sede Eliminada con exito";
        }

        public List<Sede> ObtenerSede(int idSede, int idLab)
        {
            SedeCrudFactory crud = new SedeCrudFactory();
            return crud.RetrieveBySede<Sede>(idSede, idLab);
        }
    }
}
