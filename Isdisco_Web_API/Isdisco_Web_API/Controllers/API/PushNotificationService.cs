using System;
using Microsoft.AspNetCore.Mvc;
//https://docs.microsoft.com/en-us/azure/notification-hubs/notification-hubs-push-notification-http2-token-authentification
namespace Isdisco_Web_API.Controllers.API
{
    [Route("api/notifications")]
    public class PushNotificationService : Controller
    {

        //private DAO.StorageSingleton storage = DAO.StorageSingleton.GetInstance();

        public PushNotificationService()
        {
        }

        [HttpGet("push")]
        public void PushNotification()
        {
            Businesslogic.NotificationControllerClass ncc = new Businesslogic.NotificationControllerClass();
            _ = ncc.PushNotificationAsync();
             
        }


    }
}
