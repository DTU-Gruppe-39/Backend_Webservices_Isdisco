using System;
using System.Collections.Generic;
using Isdisco_Web_API.Models;
using Isdisco_Web_API.Utility;
using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;

namespace Isdisco_Web_API.DAO
{
    public class UserDAO : DefaultDAO<User>
    {
        StorageSingleton storage = StorageSingleton.GetInstance();
        public UserDAO()
        {
        }

        public void Add(User element)
        {
            storage.UserList.Add(element);
        }

        public void Update(User element)
        {
            for (int i = 0; i < storage.UserList.Count; i++)
            {
                if (storage.UserList[i].Id.Equals(element.Id))
                {
                    storage.UserList[i] = element;
                }
            }
        }

        public void Delete(int id)
        {
            for (int i = 0; i < storage.UserList.Count; i++)
            {
                if (storage.UserList[i].Id.Equals(id))
                {
                    storage.UserList.RemoveAt(i);
                }
            }
        }

        public List<User> GetAll()
        {
            List<User> result = new List<User>();
            using (SqlConnection connection = new SqlConnection(storage.DBConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM users;", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string fullname = reader.GetString(1);
                            string firstname = reader.GetString(2);
                            string email = reader.GetString(3);
                            //needed to handle potential null values
                            string appToken = (reader.IsDBNull(4) ? "" : reader.GetString(4));
                            string facebookToken = (reader.IsDBNull(5) ? "" : reader.GetString(5));
                            Boolean vip = reader.GetBoolean(6);

                            result.Add(new User(id, fullname, firstname, email, appToken, facebookToken, vip));


                            //result.Add(new User(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetBoolean(6)));
                        }
                    }
                }
            }
            return result;
/*
            return storageSingleton.UserList;
*/
        }

        public User Get(int id)
        {
            foreach (User user in storage.UserList)
            {
                if (user.Id.Equals(id))
                {
                    return user;
                }
            }
            throw new APIException(StatusCodes.Status404NotFound);
        }
    }
}
