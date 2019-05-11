﻿using System;
namespace Isdisco_Web_API.Models
{
    public class Feedback
    {
        public User User { get; set; }
        public string Tag { get; set; }
        public string Messsage { get; set; }
        public int Id { get; set; }
         
        public Feedback(User user, string tag, string message)
        {
            this.User = user;
            this.Tag = tag;
            this.Messsage = message;
            Id = user.Id;
        }
    }
}
