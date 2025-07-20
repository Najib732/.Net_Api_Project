using BLL.DTO;
using DAL.EF;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
   
    public class SaleStatus
    {
        public readonly SellRepo productRepo;
        public readonly Sale Sale;
        public SaleStatus() {
            productRepo = new SellRepo();
            Sale = new Sale();
        }
        public  bool update(int voucharno, int status)
        {
            var data = new SaleDTO()
            {
                VoucharNo = voucharno,
                Status = status
            };
            var transfer = Convert(data);
            
            productRepo.Update(transfer);
            return true;
        }

        private  Sale Convert(SaleDTO obj)
        {
           
            Sale.VoucharNo = obj.VoucharNo;
            Sale.Status = obj.Status;
            return Sale;
        }
    }
}
