using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sep3API.Data;
using Sep3API.Models;

namespace Sep3API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private CloudMemoryUserService _cloudMemoryUserService;

        public UsersController()
        {
            _cloudMemoryUserService = new CloudMemoryUserService();
        }

        [HttpPost]
        public async Task<ActionResult<User>> CheckingUserLogin([FromBody] User user)
        {
            try
            {
                return Ok(_cloudMemoryUserService.ValidateUserAsyncLogin(user.username, user.password));
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<User>> CheckingUserRegister([FromBody] User user)
        {
            try
            {
                
                    return Ok(_cloudMemoryUserService.ValidateUserAsyncRegister(user.username, user.password,user.Email));

            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        [HttpPost]
        [Route("UpdateUsersInfo")]
        public async Task<ActionResult<User>> UpdateUsersInfo([FromBody] User user)
        {
            try
            {
                
                return Ok(_cloudMemoryUserService.UpdateUsersInfo(user));

            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IList<User>>> GetAllUsers()
        {
            try
            {
                IList<User> users = await _cloudMemoryUserService.GetAllUsers();
                return Ok(users);
            } catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpGet]
        [Route("GetUserByUserName")]
        public async Task<ActionResult<User>> GetUserByUserName([FromQuery] string username)
        {
            try
            {
                
                return Ok(_cloudMemoryUserService.GetUserByUserNameAsync(username));

            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet]
        [Route("GetUserById")]
        public async Task<ActionResult<User>> GetUserByUserName([FromQuery] int id)
        {
            try
            {
                
                return Ok(_cloudMemoryUserService.GetUserById(id));

            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch]
        [Route("{id:int}")]

        public async Task<ActionResult<User>> UpdateUsersRoleById([FromBody] User user)
        {
            try
            {
                User updatedUser = await _cloudMemoryUserService.UpdateUsersRole(user);
                return Ok(updatedUser);
            }
            
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}