using DnDIMDesktopUI.Helpers.API;
using DnDIMDesktopUI.Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DnDIMDesktopUI.Library.API
{
    public class ItemEndPoint : IItemEndPoint
    {
        private IAPIHelper _apiHelper;
        public ItemEndPoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<List<ItemsModel>> GetAll()
        {

            using (HttpResponseMessage response = await _apiHelper.ApiClient.GetAsync("/api/Items"))
            {
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<List<ItemsModel>>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
