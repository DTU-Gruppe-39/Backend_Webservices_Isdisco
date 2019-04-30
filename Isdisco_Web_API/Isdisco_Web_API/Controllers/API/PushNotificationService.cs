using System;
using Microsoft.AspNetCore.Mvc;

namespace Isdisco_Web_API.Controllers.API
{
    [Route("api/nofifications")]
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
            ncc.PushNotification();
        }


    }
}
