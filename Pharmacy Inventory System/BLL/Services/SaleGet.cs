using BLL.DTO;
using DAL.EF;
using DAL.Repos;
using DAL.Repos.ProductSale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SaleGet
    {
        private readonly SellProductSearchRepo _repo;
        private readonly GetTotalPrice totalprice;
        public SaleGet()
        {
            _repo = new SellProductSearchRepo();
            totalprice=new GetTotalPrice();
        }

        public List<SaleDTO> GetAll()
        {
            var saleTableDetails = _repo.GetAll();
            var voucherTableDetail = totalprice.GetAll();
            return null;
                //Convert(saleTableDetails, voucherTableDetail);
        }

        public List<ShowSaleDTO> Get(int VoucharNo)
        {
            var saleTableDetails = _repo.GetByVoucher(VoucharNo);
            var voucherTableDetails = totalprice.GetById(VoucharNo);
            return Convert(saleTableDetails, voucherTableDetails);
          
        }


        private List<ShowSaleDTO> Convert(List<Sale> dtoList,TotalPrice obj)
        {
            var list = new List<ShowSaleDTO>();

            foreach (var data in dtoList)
            {
                var saleDto = new ShowSaleDTO
                {
                    ProductID = data.ProductID,
                    Quantity = data.Quantity,
                    SaleDate = data.SaleDate,
                    VoucharNo = data.VoucharNo,
                    Status = data.Status,
                    CustomerID = data.CustomerID,
                    price = data.price,
                    Total_Price=obj.Total_Price,
                    Discount=obj.Discount
                };

                list.Add(saleDto);
            }

            return list;
        }

        
    }
}
