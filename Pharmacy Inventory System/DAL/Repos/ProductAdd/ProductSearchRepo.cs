using DAL.EF;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class ProductSearchRepo : Repo, IGetRepo<Product,int>
    {
        public List<Product> GetAll()
        {
            return db.Products.ToList();
        }

        public Product GetById(int id)
        {
            return db.Products.Find(id);
        }

        public Product GetByName(string name)
        {
            return db.Products.FirstOrDefault(p => p.ProductName == name);
        }
    }

  
    }

