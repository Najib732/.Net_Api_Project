using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web;
using System.Web.Http;
using BLL.Services;
using BLL.DTO;
using System.Runtime.InteropServices;

namespace Pharmacy_Inventory_System.Controllers
{
    public class SaleAddController : ApiController
    {

        [Route("product/sale/add")]
        [HttpPost]
        /*
        public HttpResponseMessage AddSales(int productID, int quantity, int customer)
        {
            // Wrap single item into array to fit your AddValue method
            int[] productIDs = new int[] { productID };
            int[] quantities = new int[] { quantity };

            var saleService = new SaleAdd();
            bool result = saleService.AddValue(productIDs, quantities, customer);

            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Sales added successfully.");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Failed to add sales.");
            }
        }
       
       
        public HttpResponseMessage AddSales([FromBody] SaleDTO request)
        {
            var saleService = new SaleAdd();

            bool result = saleService.AddValue(
            new int[] { (int)request.ProductID },
                    new int[] { (int)request.Quantity },
                     (int)request.CustomerID
         );
           
            if (result)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Sales added successfully.");
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Failed to add sales.");
            }
        }
        */

     
        public HttpResponseMessage Sales([FromBody] string input)
        {
            try
            {
                // Example input: "product code:1,2,3;amount:10,20,30;customer account:1"
                var parts = input.Split(';');

                var productPart = parts.FirstOrDefault(p => p.StartsWith("product code:", StringComparison.OrdinalIgnoreCase));
                var amountPart = parts.FirstOrDefault(p => p.StartsWith("amount:", StringComparison.OrdinalIgnoreCase));
                var customerPart = parts.FirstOrDefault(p => p.StartsWith("customer account:", StringComparison.OrdinalIgnoreCase));

                if (productPart == null || amountPart == null || customerPart == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid input format.");
                }

                var productIDs = productPart.Split(':')[1].Split(',').Select(int.Parse).ToArray();
                var quantities = amountPart.Split(':')[1].Split(',').Select(int.Parse).ToArray();   
                var customerID = int.Parse(customerPart.Split(':')[1]);
              

                var service = new SaleAdd();
                var result = service.AddValue(productIDs, quantities, customerID);

                if (result)
                    return Request.CreateResponse(HttpStatusCode.OK, "Sales added successfully.");
                else
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Failed to add sales.");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }



    }



}