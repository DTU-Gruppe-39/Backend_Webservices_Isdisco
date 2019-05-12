using System;
using System.Collections.Generic;
using Isdisco_Web_API.DAO;
using Isdisco_Web_API.Models;
using Isdisco_Web_API.Utility;
using Microsoft.AspNetCore.Http;

namespace Isdisco_Web_API.Controllers.Businesslogic
{
    public class UserController
    {
        UserDAO userDAO = new UserDAO();
     
        public UserController()
        {
        }

        public void AddUser (User user)
        {
            if (user != null)
                userDAO.Add(user);
            else 
                throw new APIException(StatusCodes.Status422UnprocessableEntity);
        }

        public User GetUser (int id)
        {
            return userDAO.Get(id);
        }

        public List<User> GetUsers ()
        {
            return userDAO.GetAll();
        }

        public void DeleteUser (int id)
        {
            userDAO.Delete(id);
        }

        public void UpdateUser (User user)
        {
            if (user != null)
                userDAO.Update(user);
            else
                throw new APIException(StatusCodes.Status422UnprocessableEntity);
        }
    }
}
