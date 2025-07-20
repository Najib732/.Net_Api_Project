using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
   
        internal interface ILogin<T, ID>
        {
            ID Login(T obj);
        }
    
}
