using AccountManager._1._Presentation.ResponseModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountManager._1._Presentation.Controllers
{
    public class ControllerApiBase : ControllerBase
    {

        [NonAction]
        protected BadRequestObjectResult BadRequest(string errorMessage)
        {
            return base.BadRequest(new MessageResponse(errorMessage)); 
        }

        [NonAction]
        public OkObjectResult Ok(string message)
        {
            return base.Ok(new MessageResponse(message));
        }
        
    }
}
