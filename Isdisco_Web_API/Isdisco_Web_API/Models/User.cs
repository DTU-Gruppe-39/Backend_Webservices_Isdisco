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
            Counter++;
            Id = Counter;
            VIP = false;
        }

        public User(int id, string fullname, LoginDetails loginDetails, bool vip)
        {
            Id = id;
            Fullname = fullname;
            LoginDetails = loginDetails;
            VIP = vip;
        }

        public User(string fullname, LoginDetails loginDetails, bool vip)
        {
            Counter++;
            Id = Counter;

            Fullname = fullname;
            LoginDetails = loginDetails;
            VIP = vip;
        }

        public User(string fullname, LoginDetails loginDetails, bool vip, string appToken)
        {
            Counter++;
            Id = Counter;

            Fullname = fullname;
            LoginDetails = loginDetails;
            VIP = vip;
            AppToken = AppToken;
        }

        public User(int id, string fullname, LoginDetails loginDetails, bool vip, string appToken)
        {
            Id = id;
            Fullname = fullname;
            LoginDetails = loginDetails;
            VIP = vip;
            AppToken = AppToken;
        }

        public User(string fullname, LoginDetails loginDetails, bool vip, string appToken, string facebookToken)
        {
            Counter++;
            Id = Counter;

            Fullname = fullname;
            LoginDetails = loginDetails;
            VIP = vip;
            AppToken = AppToken;
            FacebookToken = facebookToken;
        }

        public User(int id, string fullname, LoginDetails loginDetails, bool vip, string appToken, string facebookToken)
        {
            Id = id;

            Fullname = fullname;
            LoginDetails = loginDetails;
            VIP = vip;
            AppToken = AppToken;
            FacebookToken = facebookToken;
        }

        public User(LoginDetails loginDetails)
        {
            Counter++;
            Id = Counter;
            LoginDetails = loginDetails;
            VIP = false;
        }

        public User(int id, LoginDetails loginDetails)
        {
            Id = id;
            LoginDetails = loginDetails;
            VIP = false;
        }
    }
}
