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
    //Internal so that nothing outside of the library can access it
    /// <summary>
    /// Access SQL server and sets the load and save methods for data trasmissions
    /// </summary>
    internal class SqlDataAccess
    {
        public string GetConnectionString (string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        /// <summary>
        /// Takes in Model Class <T> & <U> and loads the data into a list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="storedProcedures"></param>
        /// <param name="paramaters"></param>
        /// <param name="connectionStringName"></param>
        /// <returns> list of queried rows of type T</returns>
        public List<T> LoadData<T, U>(string storedProcedures, U paramaters, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);
            using(IDbConnection connecton = new SqlConnection(connectionString))
            {
                List<T> rows = connecton.Query<T>(storedProcedures, paramaters, commandType: CommandType.StoredProcedure).ToList();

                return rows;
            }
        }
        /// <summary>
        /// Takes in a model class <T> and sends the data to be saved via a stored procedure
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storedProcedures"></param>
        /// <param name="paramaters"></param>
        /// <param name="connectionStringName"></param>
        public void SaveData<T>(string storedProcedures, T paramaters, string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);
            using (IDbConnection connecton = new SqlConnection(connectionString))
            {
                connecton.Execute(storedProcedures, paramaters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
