using DnDIMDataManager.Models;
using DnDIMDesktopUI.Helpers.API;
using DnDIMDesktopUI.Library.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.ModelBinding;

namespace DnDIMDesktopUI.Library.API
{
    public class RegisterUserEndPoint
    {
        private IAPIHelper _apiHelper;
        public RegisterUserEndPoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

        public async Task<IHttpActionResult> Register(RegisterUserModel model)
        {
           

            var user = new ApplicationUser() { UserName = model.Email, Email = model.Email };

            IdentityResult result = await UserManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }

            return Ok();
        }
    }
}
