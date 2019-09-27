using System;
using System.Collections.Generic;
using Isdisco_Web_API.Models;
using Isdisco_Web_API.Utility;
using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;

namespace Isdisco_Web_API.DAO
{
    public class FeedbackDAO : DefaultDAO<Feedback>
    {
        StorageSingleton storage = StorageSingleton.GetInstance();
        Controllers.Businesslogic.UserController usrcon = Controllers.Businesslogic.ControllerRegistry.GetUserController();
        StorageSingleton storageSingleton = StorageSingleton.GetInstance();

        public FeedbackDAO()
        {
        }

        public void Add(Feedback feedback)
        {
            /*string sqlStatement = "INSERT INTO feedback (UserId, Tag, TheMessage)" +
                "VALUES (@UserId, @Tag, @TheMessage);";

            using (SqlConnection connection = new SqlConnection(storage.DBConnectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@UserId", feedback.User.Id);
                command.Parameters.AddWithValue("@Tag", feedback.Tag);
                command.Parameters.AddWithValue("@TheMessage", feedback.Message);

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



            storageSingleton.FeedbackList.Add(feedback);
        }

        public void Delete(int id)
        {
            /*string sqlStatement = "DELETE FROM feedback WHERE ID=@ID";

            using (SqlConnection connection = new SqlConnection(storage.DBConnectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@ID", id);

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


            for (int i = 0; i < storage.FeedbackList.Count; i++)
            {
                if (storage.FeedbackList[i].Id.Equals(id))
                {
                    storage.FeedbackList.RemoveAt(i);
                }
            }
        }

        public void DeleteAll()
        {
            /*string sqlStatement = "DELETE FROM feedback;";

            using (SqlConnection connection = new SqlConnection(storage.DBConnectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
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


            storage.FeedbackList.Clear();
        }

        public List<Feedback> GetAll()
        {
            /*List<Feedback> result = new List<Feedback>();
            string queryString = "SELECT * FROM feedback;";

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
                            int userId = reader.GetInt32(1);
                            string tag = reader.GetString(2);
                            string message = reader.GetString(3);
                            User user = usrcon.GetUser(userId);

                            result.Add(new Feedback(id, user, tag, message));
                        }
                    }
                }
            }
            return result;*/


            return storage.FeedbackList;
        }

        public Feedback Get(int id)
        {
            foreach (Feedback feedback in storage.FeedbackList)
            {
                if (feedback.Id.Equals(id))
                {
                    return feedback;
                }
            }
            throw new APIException(StatusCodes.Status404NotFound);
        }

        public List<Feedback> GetTag(string tag)
        {
            List<Feedback> taggedFeedbackList = new List<Feedback>();
            foreach (Feedback feedback in storage.FeedbackList)
            {
                if (feedback.Tag.Equals(tag))
                {
                    taggedFeedbackList.Add(feedback);
                }
            }
            return taggedFeedbackList;
        }

        public void Update(Feedback element)
        {
            throw new NotImplementedException();
        }
    }
}
