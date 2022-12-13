using DataAccess.DAO;
using DataAccess.Mapper;
using DataAccess.Mapper.Usuarios;
using DTO;
using DTO.Examenes;
using DTO.Usuarios;
using System;
using System.Collections.Generic;

namespace DataAccess.CRUD
{
    public class UsuarioCrudFactory
    {
        private UsuarioMapper mapper;
        private SqlDAO DAO;
        //Implementeamos el contrusctor del padre
        public UsuarioCrudFactory() : base()
        {
            mapper = new UsuarioMapper();
            DAO = SqlDAO.GetInstance();
        }


        public List<Dictionary<string, object>> Validar(EntidadBase entityDTO)
        {
            var usuario = (Usuario)entityDTO;
            var sqlOperation = mapper.GetLoginStatement(usuario);
            return DAO.ExecuteStoredProcedureWithQuery(sqlOperation);

        }

        public List<Dictionary<string, object>> MostrarCitasPendientes(EntidadBase entityDTO)
        {
            var usuario = (Usuario)entityDTO;
            var sqlOperation = mapper.GetMostrarCitaPendiente(usuario);
            return DAO.ExecuteStoredProcedureWithQuery(sqlOperation);

        }
        public List<Dictionary<string, object>> MostrarCitasAgendadas(EntidadBase entityDTO)
        {
            var usuario = (Usuario)entityDTO;
            var sqlOperation = mapper.GetMostrarCitaAgendada(usuario);
            return DAO.ExecuteStoredProcedureWithQuery(sqlOperation);

        }

        public List<Dictionary<string, object>> AgendarCita(EntidadBase entityDTO)
        {
            try {
                var cita = (Citas)entityDTO;
                var sqlOperation = mapper.GetAgendarCitaPendiente(cita);
                return DAO.ExecuteStoredProcedureWithQuery(sqlOperation);
            } catch (Exception ex) {
                return null;
            }
        }
        public List<Dictionary<string, object>> ReAgendarCita(EntidadBase entityDTO)
        {
            try
            {
                var cita = (Citas)entityDTO;
                var sqlOperation = mapper.GetReAgendarCitaAgendada(cita);
                return DAO.ExecuteStoredProcedureWithQuery(sqlOperation);
                
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<T> RetrieveAll<T>()
        {
            var list = new List<T>();

            var listResult = DAO.ExecuteStoredProcedureWithQuery(mapper.GetRetrieveAllStatement());

            var Dicc = new Dictionary<string, object>();

            if (listResult.Count > 0)
            {
                var objUsuario = mapper.BuildObjects(listResult);

                foreach (var c in objUsuario)
                {
                    list.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return list;
        }

        public List<T> RetrievebyUser<T>(int Id)
        {
            var list = new List<T>();

            var listResult = DAO.ExecuteStoredProcedureWithQuery(mapper.RetrieveByIdStatement(Id));

            var Dicc = new Dictionary<string, object>();

            if (listResult.Count > 0)
            {
                var objUser = mapper.BuildObjectsID(listResult);

                foreach (var c in objUser)
                {
                    list.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return list;

        }

        public void Editar(int id, EntidadBase entityDTO)
        {
            var usuario = (Usuario)entityDTO;
            var sqlOperation = mapper.GetUpdateStatement(id, usuario);

            DAO.ExecuteStoredProcedure(sqlOperation);
        }

        public void Eliminar(int id)
        {
            var sqlOperation = mapper.GetDeleteStatement(id);
            DAO.ExecuteStoredProcedure(sqlOperation);
        }

    }
}
