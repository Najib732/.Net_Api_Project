using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Http;

namespace Pharmacy_Inventory_System.Controllers
{
    public class SaleUpdateController : ApiController
    {
       
        [HttpPost]
        [Route("product/sale/update")]
        public HttpResponseMessage UpdateSale(int voucharno, int status)
        {
            SaleStatus product = new SaleStatus();
            bool result = product.update(voucharno, status);
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Sale status updated.");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Update failed.");
            }

        }
    }
}