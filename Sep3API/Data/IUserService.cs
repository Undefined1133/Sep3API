using System.Collections.Generic;
using System.Threading.Tasks;
using Sep3API.Models;

namespace Sep3API.Data
{

        public interface IUserService
        {
            Task<User> ValidateUserAsyncLogin(string username, string password);
   

           Task<User> ValidateUserAsyncRegister(string username, string password,string email);

           Task<User> GetUserByUserNameAsync(string username);
           Task<List<User>> GetAllUsers();

           Task<User> GetUserById(int id);
           Task<User> UpdateUsersRole(User user);
           Task<User> UpdateUsersInfo(User user);
        }
    
}