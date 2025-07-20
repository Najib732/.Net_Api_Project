using BLL.DTO;
using DAL.EF;
using DAL.Repos.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserLogin
    {
        private readonly LoginRepo login;
        public UserLogin()
        {
            login=new LoginRepo();
        }

        public bool Validation(int UserId, string password)
        {
            var loginInfo = new UserDTO
            {
                Id=UserId,
                Password = password
            };

            var userEntity = Convert(loginInfo);
            
            return login.Login(userEntity); 
        }

        private static User Convert(UserDTO obj)
        {
            return new User
            {
                id = obj.Id,
                Password = obj.Password
            };
        }


    }
}
