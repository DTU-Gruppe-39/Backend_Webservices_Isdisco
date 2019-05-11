using System;
using Newtonsoft.Json.Linq;
using Isdisco_Web_API.Controllers.Business_logic;
using Isdisco_Web_API.Models;
using System.Collections.Generic;
using System.Timers;
using System.Threading.Tasks;

namespace Isdisco_Web_API.Controllers.Businesslogic
{
    public class NotificationControllerClass
    {
        private DAO.StorageSingleton storage = DAO.StorageSingleton.GetInstance();
        private DAO.MusicrequestDAO reqDao = new DAO.MusicrequestDAO();
        private DAO.UserDAO usrDao = new DAO.UserDAO();
        private MusicrequestController mrc = new MusicrequestController();
        private CustomHttpHandler.ApnsProvider apnhttp = new CustomHttpHandler.ApnsProvider("https://api.development.push.apple.com:443", "com.Rasmus-Gregersen.Isdisco");

        private readonly string deviceToken = "834A1C6138CD293AC464D6CBFDBC987C3F73BC691EF55702F6DE5E84F2DA7081";
        private readonly string deviceToken1 = "F9659290C65335689BB1F300EDDFDEC036BB3D32E78DB726879049AD487B333D";

        public NotificationControllerClass()
        {
        }

        //Send message to test phone
        public async Task<bool> SendNotificationAsync(string title, string msg)
        {
            bool isSuccess = await apnhttp.SendAsync(title, msg, deviceToken, storage.p8Token, false);

            return isSuccess;
        }

        //Send now playing message to users who have requested that track
        public async Task<bool> SendNowPlayingNotificationAsync(Track track)
        {
            List<User> usrs2Send = new List<User>();
            //req = reqDao.GetAll().FindAll((Musicrequest obj) => obj.Track.Id == track.Id);

            //Lambda for finding all users who match the given trackid
            usrs2Send = mrc.GetAllMusicRequests().Find((Musicrequest obj) => obj.Track.Id.Equals(track.Id)).UpvoteUsers;

            
            string title = "Afspiller nu..";
            string msg = "Sangen " + track.SongName + ", som du har ønsket spiller nu!";
            bool isSuccess = false;


            /*
            foreach (User ureq in usrs2Send)
            {
                await apnhttp.SendAsync(title, msg, ureq.AppToken, storage.p8Token, false);
            }
            */

            for (int i = 0; i < usrs2Send.Count; i++)
            {
                isSuccess = await apnhttp.SendAsync(title, msg, usrs2Send[i].AppToken, storage.p8Token, false);
            }

            return isSuccess;
        }

        //Send message to all users
        public async Task<bool> SendNotificationToAllAsync(string title, string msg)
        {
            List<User> a = usrDao.GetAll();
            Console.WriteLine("Foreach");
            bool isSuccess = false;

            for (int i = 0; i < a.Count; i++)
            {
                isSuccess = await apnhttp.SendAsync(title, msg, storage.UserList[i].AppToken, storage.p8Token, false);
                //await apnhttp.SendAsync(title, msg, deviceToken1, storage.p8Token, false);
            }

            return isSuccess;
        }
    }
}
