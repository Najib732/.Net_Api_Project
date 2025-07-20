using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Pharmacy_Inventory_System.Controllers
{
    public class ProductDelController :ApiController
    {
        [HttpPost]
        [Route("product/delete")]
        public HttpResponseMessage clear(int id)
        {
            ProductDelete product = new ProductDelete();
            product.productdelete(id);
            return Request.CreateErrorResponse(HttpStatusCode.OK, "Sucessfully delete");

        } 
    }
}