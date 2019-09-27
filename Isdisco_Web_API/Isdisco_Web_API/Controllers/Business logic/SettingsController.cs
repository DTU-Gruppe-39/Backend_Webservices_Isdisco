using System;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Isdisco_Web_API.Controllers.Business_logic;
using Isdisco_Web_API.DAO;
using Isdisco_Web_API.Models;

namespace Isdisco_Web_API.Controllers.Businesslogic
{
    public class SettingsController
    {
        private static System.Timers.Timer aTimer;
        private static System.Timers.Timer refreshTimer;
        SpotifyControllerClass sc = ControllerRegistry.GetSpotifyController();
        SpotifyAuthController auth = ControllerRegistry.GetSpotifyAuthController();

        NotificationControllerClass ncc = ControllerRegistry.GetNotificationController();
        MusicrequestController musicrequestController = ControllerRegistry.GetMusicrequestController();
       
        private JwtFromP8 p8 = new JwtFromP8();

        //private CustomHttpHandler.ApnsProvider apnhttp = new CustomHttpHandler.ApnsProvider("https://api.development.push.apple.com:443", "com.Rasmus-Gregersen.Isdisco");
        //NotificationControllerClass ncc = new NotificationControllerClass();
        StorageSingleton storage = StorageSingleton.GetInstance();
        //private readonly string deviceToken = "834A1C6138CD293AC464D6CBFDBC987C3F73BC691EF55702F6DE5E84F2DA7081";

        public SettingsController()
        {  
        }

        public void Reset()
        {
            musicrequestController.DeleteAllMusicrequest();
            musicrequestController.DeleteAllLiveRequest();
        }

        public void StartEvent()
        {
        //    //Create tokens
        //    storage.p8Token = p8.GetToken();
            auth.GetRefreshAuthorizationCodeFlowAuthToken();
            auth.GetClientCredentialsFlowAuthToken();

        //    // Create a timer with a two second interval.
        //    //aTimer = new System.Timers.Timer(10000);

        //    // Hook up the Elapsed event for the timer.
        //    //aTimer.Elapsed += OnTimedEventAsync;
        //    //aTimer.AutoReset = true;
        //    //aTimer.Enabled = true;
        //    //Console.WriteLine("\n\n\n\nTHE START EVENT TIMER WAS STARTED\n\n\n\n");

        //    //refreshTimer = new System.Timers.Timer(1800000);
        //    ////To get token before 30 min.

        //    //// Hook up the Elapsed event for the timer.
        //    //refreshTimer.Elapsed += RefreshEventAsync;
        //    //refreshTimer.AutoReset = true;
        //    //refreshTimer.Enabled = true;
        }

        public void StopEvent()
        {
        //    //aTimer.Stop();
        //    //Console.WriteLine("\n\n\n\nTHE START EVENT TIMER WAS STOPPED\n\n\n\n");

        //    //refreshTimer.Stop();

            storage.AuthorizationCodeFlowAuthCode = null;
            storage.AuthorizationCodeFlowAuthTokenResponse = null;
            storage.ClientCredentialsFlowAuthToken = null;
            storage.RefreshAuthorizationCodeFlowAuthToken = null;            
        }

        //private async void OnTimedEventAsync(Object sender, ElapsedEventArgs e)
        //{
        //    CurrentlyPlaying currentlyPlaying = sc.GetCurrentlyPlayingSong();
        //    if (storage.currentlyPlaying == null)
        //    {
        //        storage.currentlyPlaying = currentlyPlaying;
        //    }
        //    else if (!(storage.currentlyPlaying.Track.Id.Equals(currentlyPlaying.Track.Id)))
        //    {
        //        storage.currentlyPlaying = currentlyPlaying;

        //        if (!storage.currentlyPlaying.Track.SongName.Equals(""))
        //        {
        //        //TODO: Get this function working.
        //        //Send notifications
        //        await ncc.SendNowPlayingNotification(currentlyPlaying.Track);
        //        }


        //        //Remove matching songrequest
        //        for (int i = 0; i < musicrequestController.GetAllMusicRequests().Count; i++)
        //        {
        //            if (musicrequestController.GetAllMusicRequests()[i].Track.Id.Equals(currentlyPlaying.Track.Id))
        //            {
        //                musicrequestController.DeleteMusicrequest(musicrequestController.GetAllMusicRequests()[i].Id);
        //                //storage.MusicrequestList.RemoveAt(i); //(musicrequestController.GetAllMusicRequests()[i].Id);
        //            }
        //        }

        //        Console.WriteLine("\n\n\n\nSONG UPDATED!!!!!!!!\n\n\n\n");
        //    }
        //    else if (currentlyPlaying.Track.Id.Equals(null))
        //    {
        //        storage.currentlyPlaying = null;
        //    }
        //}

        //private async void RefreshEventAsync(Object sender, ElapsedEventArgs e)
        //{
        //    //Update APNS JWT and send a test notification to device.
        //    storage.p8Token = p8.GetToken();

        //    //Update the Spotify tokens
        //    auth.GetRefreshAuthorizationCodeFlowAuthToken();
        //    auth.GetClientCredentialsFlowAuthToken();

        //    await ncc.SendNotification("Test af timer", "Test af timer");

        //}
    }
}
