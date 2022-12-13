using DataAccess.DAO;
using DataAccess.Mapper;
using DTO;
using DTO.Examenes;
using DTO.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{
    public class RolesCrudFactory : CrudFactory
    {
        private RolesMapper mapper;

        //Implementeamos el contrusctor del padre
        public RolesCrudFactory() : base()
        {
            mapper = new RolesMapper();
            DAO = SqlDAO.GetInstance();
        }

        public override void Create(EntidadBase entityDTO)
        {
            var rol = (Roles)entityDTO;
            var sqlOperation = mapper.GetCreateStatement(rol);

            DAO.ExecuteStoredProcedure(sqlOperation);
        }
        public override void Delete(EntidadBase entityDTO)
        {
            throw new NotImplementedException();
        }

        public void Editar(int idlab, int idrol, EntidadBase entityDTO)
        {
            var rol = (Roles)entityDTO;
            var sqlOperation = mapper.GetUpdateStatement(idlab,idrol,rol);

            DAO.ExecuteStoredProcedure(sqlOperation);
        }


        public List<T> RetrieveByRol<T>(int Idlab, int Idrol)
        {
            var list = new List<T>();

            var listResult = DAO.ExecuteStoredProcedureWithQuery(mapper.GetRetrieveByIdStatement(Idlab, Idrol));

            var Dicc = new Dictionary<string, object>();

            if (listResult.Count > 0)
            {
                var objRol = mapper.BuildObjectsID(listResult);

                foreach (var c in objRol)
                {
                    list.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return list;

        }

        public void Eliminar(int idLab, int idRol)
        {
            var sqlOperation = mapper.GetDeleteStatement(idLab,idRol);
            DAO.ExecuteStoredProcedure(sqlOperation);
        }


        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
        }
        public List<T> RetrieveAllByLab<T>(int Id)
        {
            var list = new List<T>();
            var listResult = DAO.ExecuteStoredProcedureWithQuery(mapper.GetAllRetrieveByIdStatement(Id));

            var dicc = new Dictionary<string, object>();
            if (listResult.Count > 0)
            {
                var objsDataSistema = mapper.BuildObjects(listResult);
                foreach (var dataSistema in objsDataSistema)
                {
                    list.Add((T)Convert.ChangeType(dataSistema, typeof(T)));
                }
            }
            return list;
        }
        public override T RetrieveById<T>(int Id)
        {
            throw new NotImplementedException();
        }

        public override void Update(EntidadBase entityDTO)
        {
            throw new NotImplementedException();
        }
    }
}
