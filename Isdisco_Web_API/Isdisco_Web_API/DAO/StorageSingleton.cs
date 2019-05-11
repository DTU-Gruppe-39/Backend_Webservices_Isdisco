using System;
using System.Collections.Generic;
using Isdisco_Web_API.Models;
using Isdisco_Web_API.Controllers.Businesslogic;

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

        private List<Musicrequest> musicrequestList = new List<Musicrequest>();
        public List<Musicrequest> MusicrequestList
        {
            get
            {
                return musicrequestList;
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

        private List<Feedback> feedbackList = new List<Feedback>();
        public List<Feedback> FeedbackList
        {
            get
            {
                return feedbackList;
            }
        }

        public string p8Token { get; set; }
        public string ClientCredentialsFlowAuthToken { get; set; }
        public string AuthorizationCodeFlowAuthToken { get; set; }
        public string AuthorizationCodeFlowAuthCode { get; set; }
        public string RefreshAuthorizationCodeFlowAuthToken { get; set; }
        public string LoginCallback { get; set; }
        public CurrentlyPlaying currentlyPlaying { get; set; }

        public StorageSingleton() 
        {
            UserList.Add(new User(1, "Rasmus Gregersen", new LoginDetails("rasmus", "123"), false, "F9659290C65335689BB1F300EDDFDEC036BB3D32E78DB726879049AD487B333D"));
            UserList.Add(new User(2, "Thomas Mattsson", new LoginDetails("thomas", "123"), false, "834A1C6138CD293AC464D6CBFDBC987C3F73BC691EF55702F6DE5E84F2DA7081"));
            UserList.Add(new User(3, "Magnus Koch", new LoginDetails("magnus", "123"), false, "0519173D80C775708E67EB89C289F57928602BC3557F246BB17B678A24738E19"));

            //public Track(string id, string songName, string artistName, string image_small_url, string image_medium_url, string image_large_url, string webplayerLink)
            FakeTracks.Add(new Track("6u7jPi22kF8CTQ3rb9DHE7", "Old Town Road - Remix", "Lil Nas X", "https://i.scdn.co/image/394d581cef8d98be1884bfab8457e8581e800a8a", "https://i.scdn.co/image/85959c52c6ae576ee504a7c819cf65b71cb31278", "https://i.scdn.co/image/2cc54e7570d470966be2def87590dfa84f87076f", "https://open.spotify.com/track/6u7jPi22kF8CTQ3rb9DHE7"));
            FakeTracks.Add(new Track("1NgeW6kFhdqAvEKgKYhf1s", "Paris", "Lord Siva", "https://i.scdn.co/image/770004061b73088dbfa681af12de8a695dd1cfc8", "https://i.scdn.co/image/a8219aa651df2310ab13da89e876e77c35ed35dd", "https://i.scdn.co/image/77cfb3c383031e92ba0c6efcb43fa383153d0189", "https://open.spotify.com/track/1NgeW6kFhdqAvEKgKYhf1s"));
            FakeTracks.Add(new Track("2Fxmhks0bxGSBdJ92vM42m", "bad guy", "Billie Eilish", "https://i.scdn.co/image/66effcd1e9e477d0f808c34dd52181c32d1cc894", "https://i.scdn.co/image/3f64a047ef7a183da1f57842ca8bb8b6b61dc836", "https://i.scdn.co/image/16160e9999e3395dfdef718d2e7cc8432d728920", "https://open.spotify.com/track/2Fxmhks0bxGSBdJ92vM42m"));
            FakeTracks.Add(new Track("6nDKrPlXdpomGBgAlO7UdP", "SOS", "Avicii", "https://i.scdn.co/image/b375ef37db875d690965f1afb969cc2c86e21219", "https://i.scdn.co/image/38acfd3d2517343bc564d3093d54982aa3dc155c", "https://i.scdn.co/image/2cc4d3aa28ebae67ed93040315342ca43aa7080d", "https://open.spotify.com/track/6nDKrPlXdpomGBgAlO7UdP"));
            FakeTracks.Add(new Track("07LIU0ZjhmP0BX2KDGXdZY", "Rally (feat. Gilli)", "Sivas", "https://i.scdn.co/image/968bda518610f12168bcf90632c52af388975aa2", "https://i.scdn.co/image/efff7b06371fc4c0ce9f910d6400ad216324f920", "https://i.scdn.co/image/aeda3bc78b7aecbea5b0deae94b43f8a96fd5ac8", "https://open.spotify.com/track/07LIU0ZjhmP0BX2KDGXdZY"));
            FakeTracks.Add(new Track("59iEMlCecSDtur0rlSOmvX", "All In", "Branco", "https://i.scdn.co/image/35d5d3b1a09ef8f6fd0ee91860fddf7f83270650", "https://i.scdn.co/image/68c865397f4367bd4126686ed237d66bfa5063cf", "https://i.scdn.co/image/d105a40b634cca1949211736c56fcbca087a9dc9", "https://open.spotify.com/track/59iEMlCecSDtur0rlSOmvX"));
            //FakeTracks.Add(new Track("Shallow", "Lady Gaga", "Test7", "https://open.spotify.com/track/2VxeLyX666F8uXCJ0dZF8B?si=XU18v7syTUuHhx8h115x4w"));
            //FakeTracks.Add(new Track("Sweet but Psycho", "Ava Max", "Test8", "https://open.spotify.com/track/25sgk305KZfyuqVBQIahim?si=YIPBt3VESRaqIyzm60w_kw"));
            //FakeTracks.Add(new Track("Gangnam Style", "Psy", "Test9", "https://open.spotify.com/track/03UrZgTINDqvnUMbbIMhql?si=gtaXMnlsSIm0Klhyvo_yAQ"));
            //FakeTracks.Add(new Track("Nede Mette", "Blak", "1Test", "https://open.spotify.com/track/2gFaHRqjAE5ZNNnGr9eYG4?si=Oo4fJD0ZSsq45tFeVvApLw"));
            //FakeTracks.Add(new Track("Model", "Gulddreng", "2Test", "https://open.spotify.com/track/7Gf2vkf59IaWPu3Kb5Tdmx?si=dNnR67GKRzeWYyxK7JnqxQ"));

            musicrequestList.Add(new Musicrequest(FakeTracks[0], UserList[0].Id, 5, new List<int>() { 1, 2, 3 }));
            musicrequestList.Add(new Musicrequest(FakeTracks[1], UserList[1].Id, 3, new List<int>() { 1, 2, 3 }));
            musicrequestList.Add(new Musicrequest(FakeTracks[2], UserList[0].Id, 6, new List<int>() { 1, 2, 3 }));
            musicrequestList.Add(new Musicrequest(FakeTracks[3], UserList[1].Id, 8, new List<int>() { 1, 2, 3 }));


            feedbackList.Add(new Feedback(UserList[0], "Generelt", "Fedt event"));
            feedbackList.Add(new Feedback(UserList[1], "Generelt", "Fedt event"));
            feedbackList.Add(new Feedback(UserList[2], "Andet", "Fedt event"));
            feedbackList.Add(new Feedback(UserList[0], "Generelt", "Fedt event"));
            feedbackList.Add(new Feedback(UserList[2], "Generelt", "Fedt event"));
            feedbackList.Add(new Feedback(UserList[1], "Andet", "Fedt event"));
            feedbackList.Add(new Feedback(UserList[0], "Generelt", "Fedt event"));


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


        private List<Track> fakeTracks = new List<Track>();
        public List<Track> FakeTracks
        {
            get
            {
                return fakeTracks;
            }
        }
    }

}
