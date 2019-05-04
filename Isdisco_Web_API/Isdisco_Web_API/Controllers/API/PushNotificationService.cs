using System;
using System.IO;
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
        public async System.Threading.Tasks.Task SendNotificationAsync()
        {

            //var a = System.IO.File.OpenText("/Users/thomasmattsson/Documents/GitHub/Backend_Webservices_Isdisco/Isdisco_Web_API/Isdisco_Web_API/wwwroot/push-cert.p8");
            //Console.WriteLine(a.ReadToEnd());
            Businesslogic.NotificationControllerClass ncc = new Businesslogic.NotificationControllerClass();
            await ncc.SendNotificationAsync();

        }


    }
}
