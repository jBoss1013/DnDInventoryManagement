﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace DnDIMDataManager.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {  //TODO remember to delete this
        //Username: jrjlboss@outlook.com
        //Pasword: JBoss12345

        // GET api/values
        public IEnumerable<string> Get()
        {  //TODO test this and see if it can be deleted
            string useID = RequestContext.Principal.Identity.GetUserId();
               
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}