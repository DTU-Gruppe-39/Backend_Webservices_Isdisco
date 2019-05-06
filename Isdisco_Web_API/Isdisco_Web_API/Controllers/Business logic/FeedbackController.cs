using System;
namespace Isdisco_Web_API.Controllers.Businesslogic
{
    public class FeedbackController
    {
        DAO.FeedbackDAO feedbackDAO = new DAO.FeedbackDAO();
        DAO.UserDAO userDAO = new DAO.UserDAO();
        public FeedbackController()
        {
        }

        internal void PostFeedback(int id, string title, string msg)
        {
            feedbackDAO.Add(new Models.Feedback(userDAO.Get(id),title, msg));
            Console.WriteLine(feedbackDAO.Get(id).Title);
            Console.WriteLine(feedbackDAO.Get(id).Messsage);

        }
    }
}
