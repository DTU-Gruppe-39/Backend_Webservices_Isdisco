using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//https://docs.microsoft.com/en-us/azure/notification-hubs/notification-hubs-push-notification-http2-token-authentification
namespace Isdisco_Web_API.Controllers.API
{
    [Route("api/notifications")]
    public class PushNotificationService : Controller
    {
        //private string title, msg;

        //private DAO.StorageSingleton storage = DAO.StorageSingleton.GetInstance();
        private readonly Businesslogic.NotificationControllerClass ncc = new Businesslogic.NotificationControllerClass();

        public PushNotificationService()
        {
        }

        [HttpGet("push")]
        public Task SendNotification(string title, string msg)
        {
            if (msg != null && title != null)
            {
                return ncc.SendNotification(title, msg);
            }
            return null;
        }

        [HttpGet("pushall")]
        public Task SendNotificationToAllAsync(string title, string msg)
        {
            if (msg != null && title != null)
            {   
                return ncc.SendNotificationToAllAsync(title, msg);
                Console.WriteLine("SendAll");
            }

            return null;
        }
    }
}
