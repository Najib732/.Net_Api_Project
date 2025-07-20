using DAL.EF;
using DAL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.user
{
    public class LoginRepo : Repo, ILogin<User, bool>
    {
        public bool Login(User obj)
        {

            var data = (from f in db.Users
                        where f.UserName == obj.UserName
                        select f).ToList();
            return true;     
            
        }


    }
}
