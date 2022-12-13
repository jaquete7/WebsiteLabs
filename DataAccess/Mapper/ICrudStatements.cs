using DataAccess.DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public interface ICrudStatements
    {
        SqlOperation GetCreateStatement(EntidadBase entidadDTO);
        SqlOperation GetUpdateStatement(EntidadBase entidadDTO);
        SqlOperation GetDeleteStatement(EntidadBase entidadDTO);
        SqlOperation GetRetrieveByIdStatement(int id);
    }
}
