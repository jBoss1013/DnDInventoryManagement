using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Description;

namespace DnDIMDataManager.App_Start
{
    public class AuthOpFilter : IOperationFilter
    {  
        /// <summary>
        /// Allows for an extra paramter in methods to put the token in for authentication in swagger ui
        /// Used to get bearer token for auth processes for quick access
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="schemaRegistry"></param>
        /// <param name="apiDescription"></param>
        /// 

        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if(operation.parameters == null)
            {
                operation.parameters = new List<Parameter>();
            }
            operation.parameters.Add(new Parameter
            {
                name = "Authorization",
                @in = "header",
                description = "access token",
                required = false,
                type = "string"

            });
        }
    }
}