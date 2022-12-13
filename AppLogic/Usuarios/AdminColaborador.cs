using DataAccess.CRUD;
using DataAccess.CRUD.Examenes;
using DTO.Examenes;
using DTO.Usuarios;
using System.Collections.Generic;

namespace AppLogic
{
    public class AdminColaborador
    {
        public string Registrar(Colaborador colaborador)
        {
            ColaboradorCrudFactory crud = new ColaboradorCrudFactory();
            crud.Create(colaborador);

            return "Colaborador registrado con éxito";
        }

        public List<Colaborador> DevolverTodosColaboradores(int id)
        {
            ColaboradorCrudFactory Crud = new ColaboradorCrudFactory();
            return Crud.RetrieveAll<Colaborador>(id);
        }
    }
}
