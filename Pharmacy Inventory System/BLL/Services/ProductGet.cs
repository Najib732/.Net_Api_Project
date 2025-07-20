using BLL.DTO;
using DAL.EF;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Data.Entity.Infrastructure.Design;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public  class ProductGet
    {
        private readonly ProductSearchRepo _repo;
        public ProductGet() { 
            _repo= new ProductSearchRepo();

        }
        public  List<ProductDTO> GetAll()
        {
       
            var data = _repo.GetAll();
            return Convert(data);
        }


        public  ProductDTO Get(int id)
       {
       
        var data = _repo.GetById(id);
        if (data == null)
            return null;

        return Convert(data);
        }

        public  ProductDTO GetByName(string name)
        {
            var data = _repo.GetByName(name);
            if (data == null)
                return null;

            return Convert(data);
        }


        private static ProductDTO Convert(Product item)
        {
           var data= new ProductDTO
            {
                ProductID = item.ProductID,
                ProductName = item.ProductName,
                Description = item.Description,
                Price = item.Price,
                StockQuantity = item.StockQuantity,
                BranchID = item.BranchID,
                DateAdded = item.DateAdded
            };
            return data;
        }

        private static List<ProductDTO> Convert(List<Product> items)
        {
            var data = new List<ProductDTO>();

            foreach (var item in items)
            {
                data.Add(new ProductDTO
                {
                    ProductID = item.ProductID,
                    ProductName = item.ProductName,
                    Description = item.Description,
                    Price = item.Price,
                    StockQuantity = item.StockQuantity,
                    BranchID = item.BranchID,
                    DateAdded = item.DateAdded
                });
            }

            return data;
        }





    }
}
