using System;
namespace Isdisco_Web_API.Models
{
    public class Feedback
    {
        public static int Counter { get; set; }
        public User User { get; set; }
        public string Tag { get; set; }
        public string Message { get; set; }
        public int Id { get; set; }
         
        public Feedback(User user, string tag, string message)
        {
            this.User = user;
            this.Tag = tag;
            this.Message = message;
            Counter++;
            Id = Counter;
        }
    }
}
