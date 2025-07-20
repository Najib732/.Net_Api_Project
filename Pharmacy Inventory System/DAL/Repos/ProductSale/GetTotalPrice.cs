using DAL.EF;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.ProductSale
{
    public class GetTotalPrice : Repo, IGetRepo<TotalPrice, int>
    {
        public List<TotalPrice> GetAll()
        {
            return db.TotalPrices.ToList();
        }

        public TotalPrice GetById(int id)
        {
            return db.TotalPrices.Find(id);
        }

        public TotalPrice GetByName(string name)
        {
            return null;
        }
    }
}





