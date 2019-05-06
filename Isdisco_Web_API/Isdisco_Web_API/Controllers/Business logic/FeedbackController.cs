using System;
using System.Collections.Generic;
using Isdisco_Web_API.DAO;
using Isdisco_Web_API.Models;

namespace Isdisco_Web_API.Controllers.Businesslogic
{
    public class FeedbackController
    {
        DAO.FeedbackDAO feedbackDAO = new DAO.FeedbackDAO();
        DAO.UserDAO userDAO = new DAO.UserDAO();
        public FeedbackController()
        {
        }

        internal void PostFeedback(Feedback feedback)
        {
            feedbackDAO.Add(feedback);
        }

        internal List<Feedback> GetTaggedFeedbackList(string tag)
        {
            return feedbackDAO.GetTag(tag);
        }

        public List<Feedback> GetFeedbackList()
        {
            Console.WriteLine(feedbackDAO.GetAll());
            return feedbackDAO.GetAll();
        }
    }
}
