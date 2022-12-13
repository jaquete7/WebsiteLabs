using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Mapper
{
    public interface IObjectMapper
    {
        EntidadBase BuildObject(Dictionary<string, object> row);
        List<EntidadBase> BuildObjects(List<Dictionary<string, object>> listRows);
    }
}
