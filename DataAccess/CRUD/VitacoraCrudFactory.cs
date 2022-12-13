using DataAccess.DAO;
using DataAccess.Mapper;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.CRUD
{
    public class VitacoraCrudFactory : CrudFactory
    {
        private VitacoraMapper mapper;

        //Implementeamos el contrusctor del padre
        public VitacoraCrudFactory() : base()
        {
            mapper = new VitacoraMapper();
            DAO = SqlDAO.GetInstance();
        }

        public override void Create(EntidadBase entityDTO)
        {
            throw new NotImplementedException();
        }

        public override void Delete(EntidadBase entityDTO)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            var list = new List<T>();
            var listResult = DAO.ExecuteStoredProcedureWithQuery(mapper.GetAllRetrieve());
            if (listResult.Count > 0)
            {
                var objs = mapper.BuildObjects(listResult);
                foreach (var obj in objs)
                {
                    list.Add((T)Convert.ChangeType(obj, typeof(T)));
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
