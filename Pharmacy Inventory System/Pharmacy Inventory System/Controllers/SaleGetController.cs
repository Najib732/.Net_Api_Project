using BLL.DTO;
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
    
    public class SaleGetController :ApiController
    {
        [HttpPost]
        [Route("product/sell/search")]

        public HttpResponseMessage GetItem(int VoucherNo)
        {
            SaleGet saleGetController = new SaleGet();
            var data = saleGetController.Get(VoucherNo);
            

            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
    }
}