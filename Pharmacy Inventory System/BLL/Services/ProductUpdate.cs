using BLL.DTO;
using DAL.Repos;
using DAL.EF;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public  class ProductUpdate
    {
        public readonly ProductRepo product;
        public ProductUpdate()
        {
            product = new ProductRepo();
        }
        public  ProductDTO UpdateValue(int id, string Description, decimal price, int StockQuantity)
        {
            ProductDTO dto = new ProductDTO
            {
                ProductID = id,
                Description = Description,
                Price = price,
                StockQuantity = StockQuantity,
                DateAdded = DateTime.Now
            };

            var data = Convert(dto);

            
            var check=product.Update(data);

            if (check)
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
                ProductID=dto.ProductID,
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
