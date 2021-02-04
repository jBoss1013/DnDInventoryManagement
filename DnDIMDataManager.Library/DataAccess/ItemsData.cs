using DnDIMDataManager.Library.Internal.DataAcess;
using DnDIMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDIMDataManager.Library.DataAccess
{
    public class ItemsData
    {
        public List<ItemsModel> GetItems()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var output = sql.LoadData<ItemsModel, dynamic>("dbo.spItem_GetAll", new { }, "DnDIMData");

            return output;
        }
    }
}
