using DnDIMDataManager.Library.Models;
using DnDIMDataManager.Library.DataAccess;
using DnDIMDataManager.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace DnDIMDataManager.Controllers
{
    
    public class RegisterUserController : ApiController
    {
        private ApplicationUserManager _userManager;

        public RegisterUserController()
        { 
        }

        public RegisterUserController(ApplicationUserManager userManager,
            ISecureDataFormat<AuthenticationTicket> accessTokenFormat)
        {
            _userManager = userManager;
            AccessTokenFormat = accessTokenFormat;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }
        
        [AllowAnonymous]
        [HttpPost]
        //Uses userManger to create and store new register user data to asp.net dbo and to DnD dbo
        //returns status code and error message
        public async Task<IHttpActionResult> Register(RegisterUserModel model)
        {
           
            if (!ModelState.IsValid) return BadRequest(ModelState);


            var user = new ApplicationUser() { UserName = model.Email, Email = model.Email };

            IdentityResult result = await UserManager.CreateAsync(user, model.Password);


            if (!result.Succeeded) 
            { 
                return BadRequest(ModelState);
            }
            else
            {
                //TODO do better and add confirmation email, also validate that dbo is accessable 
                //if DnD is not accessable, this will still store user to aspnet user dbo making it impossible for
                //for user to use same email 
                RegisterUserData newUser = new RegisterUserData();
                model.Id = user.Id;
                newUser.SaveRegisteredUser(model);

                return Ok();
            }

        }

       
    }
}
