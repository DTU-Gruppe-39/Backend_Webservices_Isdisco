using System;
using System.Collections.Generic;
using Isdisco_Web_API.DAO;
using Isdisco_Web_API.Models;

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
            userDAO.Add(user);
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
            userDAO.Update(user);
        }
    }
}
