﻿using System;
using Newtonsoft.Json.Linq;
using Isdisco_Web_API.Controllers.Business_logic;
using Isdisco_Web_API.Models;
using System.Collections.Generic;
using System.Timers;

namespace Isdisco_Web_API.Controllers.Businesslogic
{
    public class NotificationControllerClass
    {
        private DAO.StorageSingleton storage = DAO.StorageSingleton.GetInstance();
        private DAO.MusicrequestDAO reqDao = new DAO.MusicrequestDAO();
        private DAO.UserDAO usrDao = new DAO.UserDAO();
        private CustomHttpHandler.ApnsProvider apnhttp = new CustomHttpHandler.ApnsProvider("https://api.development.push.apple.com:443", "com.Rasmus-Gregersen.Isdisco");

        private readonly string deviceToken = "834A1C6138CD293AC464D6CBFDBC987C3F73BC691EF55702F6DE5E84F2DA7081";
        private readonly string deviceToken1 = "F9659290C65335689BB1F300EDDFDEC036BB3D32E78DB726879049AD487B333D";

        public NotificationControllerClass()
        {
        }

        //Send message to test phone
        public async System.Threading.Tasks.Task SendNotificationAsync(string title, string msg)
        {
            await apnhttp.SendAsync(title, msg, deviceToken, storage.p8Token, false);
        }

        //Send now playing message to users who have requested that track
        public async System.Threading.Tasks.Task SendNowPlayingNotificationAsync(Track track)
        {
            List<User> usrs2Send = new List<User>();
            //req = reqDao.GetAll().FindAll((Musicrequest obj) => obj.Track.Id == track.Id);

            //Lambda for finding all users who match the given trackid
            usrs2Send = reqDao.GetAll().Find((obj) => obj.Track.Id == track.Id).UpvoteUsers;
            string title = "Afspiller nu..";
            string msg = "Sangen " + track.SongName + ", som du har ønsket spiller nu!";

            /*
            foreach (User ureq in usrs2Send)
            {
                await apnhttp.SendAsync(title, msg, ureq.AppToken, storage.p8Token, false);
            }
            */

            for (int i = 0; i < usrs2Send.Count; i++)
            {
                await apnhttp.SendAsync(title, msg, usrs2Send[i].AppToken, storage.p8Token, false);
            }
        }

        //Send message to all users
        public async System.Threading.Tasks.Task SendNotificationToAllAsync(string title, string msg)
        {
            List<User> a = usrDao.GetAll();
            Console.WriteLine("Foreach");
            for (int i = 0; i < a.Count; i++)
            {
                await apnhttp.SendAsync(title, msg, storage.UserList[i].AppToken, storage.p8Token, false);
                //await apnhttp.SendAsync(title, msg, deviceToken1, storage.p8Token, false);
            }
        }
    }
}
