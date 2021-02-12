using DnDIMDataManager.Library.Internal.DataAcess;
using DnDIMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDIMDataManager.Library.DataAccess
{
    public class RegisterUserData
    {
        public void SaveRegisteredUser(RegisterUserModel userInfo)
        {
            SqlDataAccess sql = new SqlDataAccess();

            sql.SaveData<RegisterUserModel>("dbo.spRegisterUser_Insert", userInfo, "DnDIMData");
            
        }
    }
}
