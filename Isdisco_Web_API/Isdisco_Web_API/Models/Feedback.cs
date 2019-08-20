using System;
namespace Isdisco_Web_API.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Tag { get; set; }
        public string Message { get; set; }
         
        public Feedback(int id, User user, string tag, string message)
        {
            this.Id = id;
            this.User = user;
            this.Tag = tag;
            this.Message = message;
        }

        public Feedback(User user, string tag, string message)
        {
            this.User = user;
            this.Tag = tag;
            this.Message = message;
        }


        public Feedback()
        {

        }
    }
}
