using System;
using System.Collections.Generic;
using System.Linq;
using DnDIMDataManager.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(DnDIMDataManager.Startup))]

namespace DnDIMDataManager
{
    public partial class Startup
    {
       
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
