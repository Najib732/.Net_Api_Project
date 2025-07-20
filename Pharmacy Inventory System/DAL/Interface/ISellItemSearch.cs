using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    internal interface ISellItemSearch<T,ID>
    {
      
            List<T> GetAll();
            List<T> GetByVoucher(ID Vouchar);
            
        
    }
}
