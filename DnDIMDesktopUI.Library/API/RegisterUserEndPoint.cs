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
    public class RegisterUserEndPoint : IRegisterUserEndPoint
    {
        private IAPIHelper _apiHelper;
        public RegisterUserEndPoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task PostRegisterUser(RegisterUserModel user)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync("/api/RegisterUser", user))
            {
                if (response.IsSuccessStatusCode)
                {
                    //response message may not be nessecary at thsi point
                    //may adjust if email confirmation is implemented
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
