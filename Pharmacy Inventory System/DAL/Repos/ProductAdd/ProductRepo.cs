using DAL.EF;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class ProductRepo : Repo, IRepo<Product, int, bool>
    {

        public bool Create(Product obj)
        {
            var data = db.Products.Add(obj);
            db.SaveChanges();
            if (data != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Create(List<Product> obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            var item = db.Products.Find(id);
            if (item != null)
            {
                
                var relatedSales = db.Sales.Where(s => s.ProductID == item.ProductID).ToList();
                db.Sales.RemoveRange(relatedSales);

                db.Products.Remove(item);

                db.SaveChanges();
            }
            return true;
        }

        public bool Update(Product obj)
        {
            try
            {

                var existing = db.Products.Find(obj.ProductID);

                if (existing != null)
                {
                    if (obj.Description != null)
                    {
                        existing.Description = obj.Description;
                    }

                    if (obj.Price != null)
                    {
                        existing.Price = obj.Price;
                    }

                    if (obj.StockQuantity != null)
                    {
                        existing.StockQuantity = obj.StockQuantity;
                    }

                    if (obj.DateAdded != null)
                    {
                        existing.DateAdded = obj.DateAdded;
                    }

                    if (obj.BranchID != null)
                    {
                        existing.BranchID = obj.BranchID;
                    }
                }


                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
