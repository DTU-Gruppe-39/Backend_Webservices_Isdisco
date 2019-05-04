using System;
using Newtonsoft.Json.Linq;
using Isdisco_Web_API.Controllers.Business_logic;
namespace Isdisco_Web_API.Controllers.Businesslogic
{
    public class NotificationControllerClass
    {
        private DAO.StorageSingleton storage = DAO.StorageSingleton.GetInstance();
        private JwtFromP8 p8 = new JwtFromP8();
        private CustomHttpHandler.ApnsProvider apnhttp = new CustomHttpHandler.ApnsProvider("https://api.development.push.apple.com:443", "com.Rasmus-Gregersen.Isdisco");

        private string deviceToken = "834A1C6138CD293AC464D6CBFDBC987C3F73BC691EF55702F6DE5E84F2DA7081";

        //private string notification = "Hej!";
        //private string payload;

        public NotificationControllerClass()
        {
        }

        public async System.Threading.Tasks.Task SendNotificationAsync(string title, string msg)
        {
            
            await apnhttp.SendAsync("Hej", deviceToken, p8.GetToken(), false);
        }
    }
}
