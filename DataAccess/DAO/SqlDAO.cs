using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DataAccess.DAO
{
    public class SqlDAO
    {
        private string connectionString = String.Empty;
        private static SqlDAO instance = new SqlDAO();

        public SqlDAO()
        {   
            //Falta agregar cadena de conexion en el web.config
            connectionString = ConfigurationManager.ConnectionStrings["NoLimits-DB"].ConnectionString;
        }

        //Se crea el metodo para manejar la instancia unica
        public static SqlDAO GetInstance()
        {
            if (instance == null)
                instance = new SqlDAO();
            return instance;
        }

        public void ExecuteStoredProcedure(SqlOperation operation)
        {

            var connection = new SqlConnection(this.connectionString);
            var command = new SqlCommand();

            command.Connection = connection;
            command.CommandText = operation.ProcedureName;
            command.CommandType = CommandType.StoredProcedure;

            foreach (var param in operation.Parameters)
            {
                command.Parameters.Add(param);
            }

            connection.Open();
            command.ExecuteNonQuery();

        }
        public List<Dictionary<string, object>> ExecuteStoredProcedureWithQuery(SqlOperation operation)
        {
            var listResult = new List<Dictionary<string, object>>();

            var connection = new SqlConnection(this.connectionString);
            var command = new SqlCommand();

            command.Connection = connection;
            command.CommandText = operation.ProcedureName;
            command.CommandType = CommandType.StoredProcedure;

            foreach (var param in operation.Parameters)
            {
                command.Parameters.Add(param);
            }

            connection.Open();

            var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var dic = new Dictionary<string, object>();
                    for (var i = 0; i < reader.FieldCount; i++)
                    {
                        dic.Add(reader.GetName(i), reader.GetValue(i));
                    }
                    listResult.Add(dic);
                }
            }


            return listResult;
        }
    }
}
