using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDIMDataManager.Library.Internal.DataAcess
{
    public class SqlDataAccess
    {
        public string GetConnectionString (string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public List<T> LoadData<T, U>(string storedProcedures, U paramaters, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);
            using(IDbConnection connecton = new SqlConnection(connectionString))
            {
                List<T> rows = connecton.Query<T>(storedProcedures, paramaters, commandType: CommandType.StoredProcedure).ToList();

                return rows;
            }
        }

        public void SaveData<T>(string storedProcedures, T Paramaters, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);
            using (IDbConnection connecton = new SqlConnection(connectionString))
            {
                connecton.Execute(storedProcedures, Paramaters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
