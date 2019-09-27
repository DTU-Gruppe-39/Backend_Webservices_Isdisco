using System;
namespace Isdisco_Web_API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Firstname { get; set; }
        public string Email { get; set; }
        public string AppToken { get; set; }
        public string FacebookToken { get; set; }
        public bool VIP { get; set; }

        public User(int id, string fullname, string firstname, string email, string appToken, string facebookToken, bool vip)
        {
            Id = id;
            Fullname = fullname;
            Firstname = firstname;
            Email = email;
            AppToken = appToken;
            FacebookToken = facebookToken;
            VIP = vip;
        }


        public User(int id, string fullname, bool vip, string appToken)
        {
            Id = id;
            Fullname = fullname;
            VIP = vip;
            AppToken = appToken;
        }

        public User(string fullname, string firstname, string email, string appToken, string facebookToken)
        {
            Fullname = fullname;
            Firstname = firstname;
            Email = email;
            AppToken = appToken;
            FacebookToken = facebookToken;
        }

        public User()
        {

        }
    }
}
