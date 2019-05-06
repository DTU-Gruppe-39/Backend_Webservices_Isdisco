using System;
namespace Isdisco_Web_API.Models
{
    public class Feedback
    {
        public User User { get; set; }
        public string Title { get; set; }
        public string Messsage { get; set; }
        public int Id { get; set; }
         
        public Feedback(User user, string title, string message)
        {
            this.User = user;
            this.Title = title;
            this.Messsage = message;
            this.Id = user.Id;
        }
    }
}
