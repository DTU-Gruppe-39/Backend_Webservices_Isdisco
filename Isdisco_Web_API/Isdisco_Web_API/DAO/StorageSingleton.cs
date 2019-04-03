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

        public string ClientCredentialsFlowAuthToken { get; set; }
        public string AuthorizationCodeFlowAuthToken { get; set; }

        public StorageSingleton() 
        {
        }

        public static StorageSingleton GetInstance()
        {
            if (Singleton == null)
            {
                Singleton = new StorageSingleton();
                return Singleton;
            }
            else
            {
                return Singleton;
            }
        }
    }
}
