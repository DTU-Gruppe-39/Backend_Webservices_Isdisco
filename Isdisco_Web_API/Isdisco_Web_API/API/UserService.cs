using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Isdisco_Web_API.Controllers.Businesslogic;
using Isdisco_Web_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Isdisco_Web_API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserService : Controller
    {
        UserController userController = new UserController();

        // GET api/user
        [HttpGet]
        public List<User> Get()
        {
            return userController.GetUsers();
        }

        // GET api/user/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return userController.GetUser(id);
        }

        // POST api/user
        [HttpPost]
        public void Post([FromBody] User user)
        {
            userController.AddUser(user);
        }

        // PUT api/user
        [HttpPut]
        public void Put([FromBody] User user)
        {
            userController.UpdateUser(user);
        }

        // DELETE api/user/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            userController.DeleteUser(id);
        }
    }
}
