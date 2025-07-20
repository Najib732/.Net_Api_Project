using DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IRepo<CLASS, ID, RET>
    {
        RET Create(CLASS obj);
        RET Create(List<CLASS> obj);
        RET Update(CLASS obj);
        RET Delete(ID id);
    }

}
