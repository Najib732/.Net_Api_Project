using BLL.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.UI;

namespace Pharmacy_Inventory_System.Controllers
{
    public class ProductAddApiController : ApiController
    {
        [Route("product/add")]
        [HttpPost]
        public HttpResponseMessage AddItem(string ProductName, string Description, decimal price, int StockQuantity)
        {
            var product = new ProductAdd();
            var data= product.AddValue(ProductName, Description, price, StockQuantity);
            if (data != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Failed to add product");
            }

        }
    }
}