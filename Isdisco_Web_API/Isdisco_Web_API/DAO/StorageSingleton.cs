using System;
using System.Collections.Generic;

namespace Isdisco_Web_API.DAO
{
    public class StorageSingleton
    {
        static StorageSingleton Singleton = null;

        private static List<Models.User> userList = new List<Models.User>();
        public List<Models.User> UserList 
        {
            get
            {
                return userList;
            }
        }

        public static List<Models.DevicePushToken> devicePushTokenList = new List<Models.DevicePushToken>();
        public List<Models.DevicePushToken> DevicePushTokenList
        {
            get
            {
                return devicePushTokenList;
            }
        }


        public string ClientCredentialsFlowAuthToken { get; set; }
        public string AuthorizationCodeFlowAuthToken { get; set; }
        public string AuthorizationCodeFlowAuthCode { get; set; }

        public StorageSingleton() 
        {
        }

        public static StorageSingleton GetInstance()
        {
            if (Singleton == null)
            {
                Singleton = new StorageSingleton();
                //Adds token to list
                Singleton.InitDevicePushTokenList();
                return Singleton;
            }
            else
            {
                return Singleton;
            }
        }
       
       
        public void InitDevicePushTokenList()
        {
            DevicePushTokenList.Add(new Models.DevicePushToken("834A1C6138CD293AC464D6CBFDBC987C3F73BC691EF55702F6DE5E84F2DA7081", 0));
        }
    }

}
