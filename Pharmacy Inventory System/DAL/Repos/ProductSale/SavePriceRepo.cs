using DAL.EF;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class SavePriceRepo : Repo, Iprice
    {
        public bool Totalprice(TotalPrice t)
        {
            db.TotalPrices.Add(t);
            db.SaveChanges();
            return true;
        }

    }
}