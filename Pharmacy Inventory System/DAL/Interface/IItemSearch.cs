using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IGetRepo<T,ID>
    {
        List<T> GetAll();
        T GetById(ID id);
        T GetByName(string name); 
    }

}
