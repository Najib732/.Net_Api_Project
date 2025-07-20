using DAL.EF;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
     public interface Iprice
    {
        bool Totalprice(TotalPrice t);
    }
}
