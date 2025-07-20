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
    public class ProductUpdateApiController :ApiController
    {
        [HttpPost]
        [Route("product/update")]
        public HttpResponseMessage UpdateItem(int id, string Description, decimal price, int StockQuantity)
        {
            ProductUpdate product=new ProductUpdate();
            var data= product.UpdateValue( id, Description, price, StockQuantity);
            if (data != null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.OK, "sucess");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "faild");
            }
            
        }
    }
}