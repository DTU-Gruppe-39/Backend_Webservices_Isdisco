using System;
namespace Isdisco_Web_API.Models
{
    public class LoginDetails
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public LoginDetails()
        {
        }
        public LoginDetails(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
