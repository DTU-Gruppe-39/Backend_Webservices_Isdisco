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
        public async Task<bool> SendNotificationAsync(string title, string msg)
        {
            bool isSuccess = false;
            if (msg != null && title != null)
            {
                isSuccess = await ncc.SendNotificationAsync(title, msg);
            }
            return isSuccess;
        }

        [HttpGet("pushall")]
        public async Task<bool> SendNotificationToAllAsync(string title, string msg)
        {
            bool isSuccess = false;
            if (msg != null && title != null)
            {
                isSuccess = await ncc.SendNotificationToAllAsync(title, msg);
                Console.WriteLine("SendAll");
            }
            return isSuccess;
        }
    }
}
