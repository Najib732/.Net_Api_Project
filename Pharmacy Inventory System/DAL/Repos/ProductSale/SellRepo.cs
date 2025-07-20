using DAL.EF;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class SellRepo : Repo, Isell<Sale, int, bool>
    {

        public bool Create(List<Sale> valu)
        {
            try
            {
                var value = GetVoucher(); // last voucher number
                int newVoucher = value + 1;

                foreach (var data in valu)
                {
                    data.VoucharNo = newVoucher;
                    db.Sales.Add(data);  // Add each sale to DbSet here, not the list itself
                }
                db.SaveChanges();
                return true;           
            }
            catch (Exception ex)
            {
                // Handle or log the error properly here
                throw new Exception("SaveChanges failed: " + (ex.InnerException?.Message ?? ex.Message));
            }

        }


        public int GetVoucher()
        {
            int maxVoucherNo = db.Sales
             .Select(x => (int?)x.VoucharNo)
              .Max() ?? -10;
            return maxVoucherNo;
        }

        public bool Update(Sale obj)
        {
            try
            {
                var existing = db.Sales.Find(obj.VoucharNo);
                if (existing == null)
                {
                    return false;
                }

                if (obj.ProductID != null)
                {
                    existing.ProductID = obj.ProductID;
                }

                if (obj.Quantity != null)
                {
                    existing.Quantity = obj.Quantity;
                }

                if (obj.SaleDate != null)
                {
                    existing.SaleDate = obj.SaleDate;
                }

                if (obj.VoucharNo != null)
                {
                    existing.VoucharNo = obj.VoucharNo;
                }

                if (obj.Status!=null)
                {
                    existing.Status = obj.Status;
                }

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Create(Sale obj)
        {
            throw new NotImplementedException();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

       
    }
}
