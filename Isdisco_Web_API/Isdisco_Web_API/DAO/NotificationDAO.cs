using System;
namespace Isdisco_Web_API.DAO
{
    public class NotificationDAO
    {

        StorageSingleton storage = StorageSingleton.GetInstance();

        public NotificationDAO()
        {
        }

        public String GetP8Token()
        {
            return storage.p8Token;
        }
        
    }
}
