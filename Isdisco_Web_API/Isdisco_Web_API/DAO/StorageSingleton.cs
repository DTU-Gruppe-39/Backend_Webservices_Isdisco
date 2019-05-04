using System;
using System.Collections.Generic;
using Isdisco_Web_API.Models;

namespace Isdisco_Web_API.DAO
{
    public class StorageSingleton
    {
        static StorageSingleton Singleton = null;


        private List<User> userList = new List<User>();
        public List<User> UserList 

        {
            get
            {
                return userList;
            }
        }

        private List<MusicRequest> musicRequestList = new List<MusicRequest>();
        public List<MusicRequest> MusicRequestList
        {
            get
            {
                return musicRequestList;
            }
        }

        private List<Blacklist> blacklist = new List<Blacklist>();
        public List<Blacklist> Blacklist
        {
            get
            {
                return blacklist;
            }
        }


        public string ClientCredentialsFlowAuthToken { get; set; }
        public string AuthorizationCodeFlowAuthToken { get; set; }
        public string AuthorizationCodeFlowAuthCode { get; set; }
        public string LoginCallback { get; set; }


        public StorageSingleton() 
        {
            UserList.Add(new User("Rasmus Gregersen", new LoginDetails("rasmus", "123"), false));
        }

        public static StorageSingleton GetInstance()
        {
            if (Singleton == null)
            {
                Singleton = new StorageSingleton();
                //Adds token to list
                //Singleton.InitDevicePushTokenList();
                return Singleton;
            }
            else
            {
                return Singleton;
            }
        }
       
       /*
        public void InitDevicePushTokenList()
        {
            DevicePushTokenList.Add(new Models.DevicePushToken("834A1C6138CD293AC464D6CBFDBC987C3F73BC691EF55702F6DE5E84F2DA7081", 0));
        }
        */
    }

}
