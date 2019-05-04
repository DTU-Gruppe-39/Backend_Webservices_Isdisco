using System;
using System.Collections.Generic;
using Isdisco_Web_API.Models;

namespace Isdisco_Web_API.DAO
{
    public class UserDAO : DefaultDAO<User>
    {
        StorageSingleton storageSingleton = StorageSingleton.GetInstance();
        public UserDAO()
        {
        }

        public void Add(User element)
        {
            storageSingleton.UserList.Add(element);
        }

        public void Update(User element)
        {
            for (int i = 0; i < storageSingleton.UserList.Count; i++)
            {
                if (storageSingleton.UserList[i].Id.Equals(element.Id))
                {
                    storageSingleton.UserList[i] = element;
                }
            }
        }

        public void Delete(int id)
        {
            for (int i = 0; i < storageSingleton.UserList.Count; i++)
            {
                if (storageSingleton.UserList[i].Id.Equals(id))
                {
                    storageSingleton.UserList.RemoveAt(i);
                }
            }
        }

        public List<User> GetAll()
        {
            return storageSingleton.UserList;
        }

        public User Get(int id)
        {
            foreach (User user in storageSingleton.UserList)
            {
                if (user.Id.Equals(id))
                {
                    return user;
                }
            }
            return null;
        }
    }
}
