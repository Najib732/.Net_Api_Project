using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
   
    public class ProductDelete
    {
        readonly ProductRepo repo;
        public ProductDelete() { 
        repo = new ProductRepo();
        }

        public bool productdelete(int id)
        {
            repo.Delete(id);
            return true;
        }
    }
}
