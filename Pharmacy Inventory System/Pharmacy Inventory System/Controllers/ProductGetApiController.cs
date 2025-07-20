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
    public class ProductGetApiController: ApiController
    {
        private ProductGet product = new ProductGet();
        [Route("product/get")]
        public HttpResponseMessage GetItem()
        {
           
            var data=  product.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("product/get/name/{name}")]
        public HttpResponseMessage GetItem(string name)
        {
            var data = product.GetByName(name);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpPost]
        [Route("product/get/id/{id}")]
    
        public HttpResponseMessage GetItem(int id)
           {
            var data = product.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
           }
    }
}