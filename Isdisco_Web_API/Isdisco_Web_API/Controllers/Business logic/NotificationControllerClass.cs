﻿using System;
using Newtonsoft.Json.Linq;
using Isdisco_Web_API.Controllers.Business_logic;
using Isdisco_Web_API.Models;
using System.Collections.Generic;
using System.Timers;
using System.Threading.Tasks;
using Isdisco_Web_API.DAO;

namespace Isdisco_Web_API.Controllers.Businesslogic
{
    public class NotificationControllerClass
    {
        //private DAO.StorageSingleton storage = DAO.StorageSingleton.GetInstance();
        //private DAO.UserDAO usrDao = new DAO.UserDAO();
        private NotificationDAO notificationDAO = new NotificationDAO();
        private UserController usrCon = ControllerRegistry.GetUserController();
        private MusicrequestController mrc = ControllerRegistry.GetMusicrequestController();
        private CustomHttpHandler.ApnsProvider apnhttp = new CustomHttpHandler.ApnsProvider("https://api.development.push.apple.com:443", "com.Rasmus-Gregersen.Isdisco");

        private readonly string deviceToken = "834A1C6138CD293AC464D6CBFDBC987C3F73BC691EF55702F6DE5E84F2DA7081";

        public NotificationControllerClass()
        {
        }

        //Send message to test phone
        public async Task SendNotification(string title, string msg)
        {
           await apnhttp.SendAsync(title, msg, deviceToken, GetP8Token(), false);
        }

        //Send now playing message to users who have requested that track
        public async Task SendNowPlayingNotification(Track track)
        {
            List<User> usrs2Send = new List<User>();

            //Lambda for finding all users who match the given trackid
            //usrs2Send = mrc.GetAllMusicRequests().Find((Musicrequest obj) => obj.Track.Id.Equals(track.Id)).UpvoteUsers;
           
            List<Musicrequest> musicrequests = mrc.GetAllMusicRequests();
            for (int i = 0; i < musicrequests.Count; i++)
            {
                if (track.Id.Equals(musicrequests[i].Track.Id))
                {
                    for (int j = 0; j < musicrequests[i].UpvoteUsers.Count; j++)
                    {
                        usrs2Send.Add(musicrequests[i].UpvoteUsers[j]);
                    }
                }
            }

            string title = "Afspiller nu..";
            string msg = "Sangen \"" + track.SongName + "\", som du har ønsket, spiller nu!";

            for (int i = 0; i < usrs2Send.Count; i++)
            {
                await apnhttp.SendAsync(title, msg, usrs2Send[i].AppToken, GetP8Token(), false);
            }
        }

        //Send message to all users
        public async Task SendNotificationToAllAsync(string title, string msg)
        {
            List<User> a = usrCon.GetUsers();
            for (int i = 0; i < a.Count; i++)
            {   
                await apnhttp.SendAsync(title, msg, a[i].AppToken, GetP8Token(), false);
            }
        }

        public String GetP8Token()
        {
            return notificationDAO.GetP8Token();
        }
    }
}
