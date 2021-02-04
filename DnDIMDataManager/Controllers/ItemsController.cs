using DnDIMDataManager.Library.DataAccess;
using DnDIMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DnDIMDataManager.Controllers
{   
    [Authorize]
    public class ItemsController : ApiController
    {
        public List<ItemsModel> Get()
        {
            ItemsData data = new ItemsData();

            return data.GetItems();
        }
    }
}
