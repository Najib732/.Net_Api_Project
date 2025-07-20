using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface Isell<CLASS, ID, RET>
    {
        RET Create(CLASS obj);
        RET Create(List<CLASS> obj);
        RET Update(CLASS obj);
        void Delete(ID id);
        ID GetVoucher();
    }
}
