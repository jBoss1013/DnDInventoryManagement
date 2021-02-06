using DnDIMDataManager.Library.Internal.DataAcess;
using DnDIMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDIMDataManager.Library.DataAccess
{
    public class UserData
    {
        public List<UserModel> GetUserById(string Id)
        {
            //TODO look into Autofac for Dependancy Inejection
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { Id = Id };

            var output =sql.LoadData<UserModel, dynamic>("dbo.spUserLookup", p, "DnDIMData");

            return output;
        }

    }
}
