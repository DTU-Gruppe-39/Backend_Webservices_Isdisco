using System;
using System.Collections.Generic;
using Isdisco_Web_API.DAO;
using Isdisco_Web_API.Models;

namespace Isdisco_Web_API.Controllers.Businesslogic
{
    public class FeedbackController
    {
        DAO.FeedbackDAO feedbackDAO = new DAO.FeedbackDAO();
        //DAO.UserDAO userDAO = new DAO.UserDAO();
        //private DAO.StorageSingleton storage = DAO.StorageSingleton.GetInstance();

        UserController usrCon = new UserController();
        FeedbackController feedCon = new FeedbackController();

        public FeedbackController()
        {
        }

        internal void PostFeedback(Feedback feedbackFromApp)
        {
            Feedback feedback = new Feedback(usrCon.GetUser(feedbackFromApp.Id), feedbackFromApp.Tag, feedbackFromApp.Message);
            feedCon.Add(feedback);
        }

        private void Add(Feedback feedback)
        {
            feedbackDAO.Add(feedback);
        }

        internal List<Feedback> GetTaggedFeedbackList(string tag)
        {
            return feedbackDAO.GetTag(tag);
        }

        public List<Feedback> GetFeedbackList()
        {
            return feedbackDAO.GetAll();
        }

        public void RemoveFeedback(int id)
        {
            feedbackDAO.Delete(id);
        }

        public void RemoveAllFeedback()
        {
            feedbackDAO.DeleteAll();
        }
    }
}
