using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Http;
using BLL.Services;

namespace Pharmacy_Inventory_System.Controllers
{
    public class UserLoginController :ApiController
    {
        [HttpPost]
        [Route("User/Login")]

        public HttpResponseMessage GetItem(int id,string password)
        {
            UserLogin userLogin = new UserLogin();
            var data = userLogin.Validation(id,password);
            if(data != null) {
                return Request.CreateResponse(HttpStatusCode.OK, new { Success = true, UserId = id });
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Login failed.");
            }
        }
    }
}