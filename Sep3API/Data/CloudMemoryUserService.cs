using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading.Tasks;
using Sep3API.Models;
using Sep3API.Persistence;


namespace Sep3API.Data
{

        public class CloudMemoryUserService : IUserService
        {
            private SocketConnection _socketConnection = new SocketConnection();
            public async Task<User> ValidateUserAsyncLogin(string username, string password)
            {
              return  await _socketConnection.connectingToJavaValidateLogin(username, password);
            }
     
            
            public async Task<User> ValidateUserAsyncRegister(string username, string password,string email)
            {
             
                return await _socketConnection.connectingToJavaValidatingRegister(username,password,email);
            }

            public async Task<User> GetUserByUserNameAsync(string username)
            {
                return await _socketConnection.GetUserByUserName(username);
            }

            public async Task<List<User>> GetAllUsers()
            {
                return  _socketConnection.ReceivingAllUsers();
            }

            public async Task<User> GetUserById(int id)
            {
                return _socketConnection.ReceivingUserById(id);
            }

            public async Task<User> UpdateUsersRole(User user)
            {
                return _socketConnection.SendUserRoleToUpdate(user);
            }

            public async Task<User> UpdateUsersInfo(User user)
            {
                return _socketConnection.SendUserToUpdateInfo(user);
            }

        }
}