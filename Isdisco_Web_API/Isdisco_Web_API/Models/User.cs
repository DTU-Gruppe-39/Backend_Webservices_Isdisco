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
        public string AppToken { get; set; }
        public string FacebookToken { get; set; }

        public User()
        {
        }

        public User(string fullname, LoginDetails loginDetails, bool vip, string appToken, string facebookToken)
        {
            Id = Counter;
            Counter++;

            Fullname = fullname;
            LoginDetails = loginDetails;
            VIP = vip;
            AppToken = AppToken;
            FacebookToken = facebookToken;
        }

        public User(LoginDetails loginDetails)
        {
            LoginDetails = loginDetails;
        }
    }
}
