using System;
namespace Isdisco_Web_API.Models
{
    public class User
    {
        public static int Counter { get; set; }
        public int Id { get; set; }
        public string Fullname { get; set; }
        public bool VIP { get; set; }
        public LoginDetails LoginDetails { get; set; }

        public User()
        {
        }

        public User(string fullname, LoginDetails loginDetails, bool vip)
        {
            Id = Counter;
            Counter++;

            Fullname = fullname;
            LoginDetails = loginDetails;
            VIP = vip;
        }

        public User(LoginDetails loginDetails)
        {
            LoginDetails = loginDetails;
        }
    }
}
