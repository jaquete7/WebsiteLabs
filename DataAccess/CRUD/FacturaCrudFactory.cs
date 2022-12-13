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
    public class FacturaCrudFactory : CrudFactory
    {

        private FacturaMapper mapper;

        //Implementeamos el contrusctor del padre
        public FacturaCrudFactory() : base()
        {
            mapper = new FacturaMapper();
            DAO = SqlDAO.GetInstance();
        }
        public override void Create(EntidadBase entityDTO)
        {
            var f = (Factura)entityDTO;
            var sqlOperation = mapper.GetCreateStatement(f);

            DAO.ExecuteStoredProcedure(sqlOperation);
        }

        public List<T> RetrieveAllByUser<T>(int idUsuario)
        {
            var list = new List<T>();
            var listResult = DAO.ExecuteStoredProcedureWithQuery(mapper.GetRetrieveByIdStatement(idUsuario));
            if (listResult.Count > 0)
            {
                var objf = mapper.BuildObjectsID(listResult);

                foreach (var c in objf)
                {
                    list.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }
            return list;
        }

        public override void Delete(EntidadBase entityDTO)
        {
            throw new NotImplementedException();
        }

        public override List<T> RetrieveAll<T>()
        {
            throw new NotImplementedException();
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
