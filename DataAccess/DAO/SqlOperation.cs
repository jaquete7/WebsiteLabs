using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class SqlOperation
    {
        public string ProcedureName { get; set; }
        public List<SqlParameter> Parameters;

        public SqlOperation()
        {
            Parameters = new List<SqlParameter>();
        }
        public void AddVarcharParam(string ParamName, string ParamValue)
        {
            Parameters.Add(new SqlParameter("@" + ParamName, ParamValue));
        }
        public void AddIntegerParam(string ParamName, int ParamValue)
        {
            Parameters.Add(new SqlParameter("@" + ParamName, ParamValue));
        }
        public void AddFloatParam(string ParamName, float ParamValue)
        {
            Parameters.Add(new SqlParameter("@" + ParamName, ParamValue));
        }

    }
}
