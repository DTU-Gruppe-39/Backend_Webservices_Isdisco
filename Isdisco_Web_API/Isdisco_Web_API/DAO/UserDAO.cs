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
            /*string sqlStatement = "INSERT INTO users (Fullname, Firstname, Email, AppToken, FacebookToken)" +
                "VALUES (@Fullname, @Firstname, @Email, @Apptoken, @FacebookToken);";

            using (SqlConnection connection = new SqlConnection(storage.DBConnectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@Fullname", element.Fullname);
                command.Parameters.AddWithValue("@Firstname", element.Firstname);
                command.Parameters.AddWithValue("@Email", element.Email);
                command.Parameters.AddWithValue("@Apptoken", element.AppToken);
                command.Parameters.AddWithValue("@FacebookToken", element.FacebookToken);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    Console.WriteLine("Add user to DB. RowsAffected: {0}", rowsAffected);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }*/
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
            /*List<User> result = new List<User>();
            string queryString = "SELECT * FROM users;";

            using (SqlConnection connection = new SqlConnection(storage.DBConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(queryString, connection))
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
                        }
                    }
                }
            }
            return result;*/

            return storage.UserList;

        }

        public User Get(int id)
        {
            /*string queryString = "SELECT * FROM users WHERE ID=@Id;";

            using (SqlConnection connection = new SqlConnection(storage.DBConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@Id", id);

                try
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int userId = reader.GetInt32(0);
                            string fullname = reader.GetString(1);
                            string firstname = reader.GetString(2);
                            string email = reader.GetString(3);
                            //needed to handle potential null values
                            string appToken = (reader.IsDBNull(4) ? "" : reader.GetString(4));
                            string facebookToken = (reader.IsDBNull(5) ? "" : reader.GetString(5));
                            Boolean vip = reader.GetBoolean(6);

                            return new User(userId, fullname, firstname, email, appToken, facebookToken, vip);
                        }
                    }
                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            throw new APIException(StatusCodes.Status404NotFound);*/

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
