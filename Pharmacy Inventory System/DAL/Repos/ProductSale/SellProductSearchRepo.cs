using DAL.EF;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class SellProductSearchRepo : Repo, ISellItemSearch<Sale, int>
    {
        public List<Sale> GetAll()
        {
            return db.Sales.ToList();
        }

        public List<Sale> GetByVoucher(int Vouchar)
        {
           
            var search = (from value in db.Sales
                          where value.VoucharNo == Vouchar
                          select value).ToList();
            return search;
        }

       
    }

}

