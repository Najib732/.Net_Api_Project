using BLL.DTO;
using DAL.EF;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class SaleAdd
    {
        private readonly SellRepo sell;
        private readonly ProductRepo productRepo;
        private readonly ProductSearchRepo searchRepo;
        private readonly SavePriceRepo t;

        public SaleAdd()
        {
            sell = new SellRepo();
            productRepo = new ProductRepo();
            searchRepo = new ProductSearchRepo();
            t=new SavePriceRepo();
           
        }
        public bool AddValue(int[] productID, int[] quantity, int customerID)
        {
            List<SaleDTO> dtoList = new List<SaleDTO>();
            decimal total = 0;

            for (int i = 0; i < productID.Length; i++)
            {
                var product = searchRepo.GetById(productID[i]);
                var price1=product.Price;
                SaleDTO dto = new SaleDTO
                {
                    ProductID = productID[i],
                    Quantity = quantity[i],
                    SaleDate = DateTime.Now,
                    Status = 1,
                    CustomerID = customerID,
                    price = (quantity[i] * price1)

            };
                dtoList.Add(dto);
            }

            var data = Convert(dtoList);
            var check = sell.Create(data); 

            if (check)
            {
                for (int i = 0; i < productID.Length; i++)
                {
                    var product = searchRepo.GetById(productID[i]);
                    if (product != null)
                    {
                        product.StockQuantity -= quantity[i];
                        product.Price = quantity[i]*product.Price;
                        /*
                        if (product.StockQuantity < 0)
                            product.StockQuantity = 0;
                        */
                            total += (decimal)(product.Price * quantity[i]);

                            productRepo.Update(product);
                        
                    }
                }
                int voucherNo = sell.GetVoucher();
                var insert = new TotalPrice
                {
                    VoucharNo = voucherNo,
                    Total_Price = total,
                    Discount = 0
                };

                t.Totalprice(insert);


                return true;
            }

            return false;
        }



        private List<Sale> Convert(List<SaleDTO> dtoList)
        {
            var list = new List<Sale>();

            foreach (var data in dtoList)
            {
                var sale = new Sale
                {
                    ProductID = data.ProductID,
                    Quantity = data.Quantity,
                    SaleDate = data.SaleDate,
                    VoucharNo = data.VoucharNo,
                    Status = data.Status,
                    CustomerID = data.CustomerID,
                    price=data.price,
                    
                };

                list.Add(sale);
            }

            return list;
        }
    }

}
