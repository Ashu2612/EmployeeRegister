using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeRegister.Models
{
    public static class DapperORM
    {
        private static string connectionstring = @"Data Source=(localdb)\mssqllocaldb;Database=EmployeeDB;Integrated Security=true;";
        public static void ExecuteWithoutReturn(string procedureName,DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionstring))
            {
                sqlCon.Open();
                sqlCon.Execute(procedureName, param, commandType: CommandType.StoredProcedure);
            }
        }

  
        public static T ExecuteReturnScalar<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionstring))
            {
                sqlCon.Open();
                return (T)Convert.ChangeType(sqlCon.Execute(procedureName, param, commandType:
                    CommandType.StoredProcedure),typeof(T));    
            }
        }
       

        public static IEnumerable<T> ReturnList<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionstring))
            {
                sqlCon.Open();
                return sqlCon.Query<T>(procedureName, param, commandType: CommandType.StoredProcedure);
            }
        }

        

    }
}
