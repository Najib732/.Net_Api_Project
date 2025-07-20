using BLL.DTO;
using DAL.EF;
using DAL.Repos;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProductAdd
    {

        private readonly ProductRepo productRepo;
        public ProductAdd()
        {
            productRepo = new ProductRepo();
        }

        public  ProductDTO AddValue(string ProductName, string Description, decimal price, int StockQuantity)
        {
            ProductDTO dto = new ProductDTO
            {
                ProductName = ProductName,
                Description = Description,
                Price = price,
                StockQuantity = StockQuantity,
                DateAdded = DateTime.Now
            };

            var data= Convert(dto);
            var d= productRepo.Create(data);


            if (d != null)
            {
                return dto;
            }
            else
            {
                return null;
            }
        }

        private static Product Convert(ProductDTO dto)
        {
            var data = new Product
            {
                ProductName = dto.ProductName,
                Description = dto.Description,
                Price = dto.Price,
                StockQuantity = dto.StockQuantity,
                BranchID = 0,
                DateAdded = DateTime.Now.Date

            };
            return data;
        }

    }
}
