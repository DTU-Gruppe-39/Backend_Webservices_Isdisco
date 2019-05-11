using System;
using System.Timers;
using Isdisco_Web_API.Controllers.Business_logic;
using Isdisco_Web_API.DAO;
using Isdisco_Web_API.Models;

namespace Isdisco_Web_API.Controllers.Businesslogic
{
    public class SettingsController
    {
        private static Timer aTimer;
        private static Timer refreshTimer;
        SpotifyControllerClass sc = new SpotifyControllerClass();
        SpotifyAuthController auth = new SpotifyAuthController();
        private CustomHttpHandler.ApnsProvider apnhttp = new CustomHttpHandler.ApnsProvider("https://api.development.push.apple.com:443", "com.Rasmus-Gregersen.Isdisco");
        private JwtFromP8 p8 = new JwtFromP8();
        //NotificationControllerClass ncc = new NotificationControllerClass();
        StorageSingleton storage = StorageSingleton.GetInstance();
        private readonly string deviceToken = "834A1C6138CD293AC464D6CBFDBC987C3F73BC691EF55702F6DE5E84F2DA7081";


        public SettingsController()
        {
        }

        public void StartEvent()
        {
            //Create p8 token
            storage.p8Token = p8.GetToken();

            // Create a timer with a two second interval.
            aTimer = new Timer(10000);
            
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
            Console.WriteLine("\n\n\n\nTHE START EVENT TIMER WAS STARTED\n\n\n\n");


            refreshTimer = new Timer(1800000);
            //To get token before 30 min.

            // Hook up the Elapsed event for the timer. 
            refreshTimer.Elapsed += RefreshEvent;
            refreshTimer.AutoReset = true;
            refreshTimer.Enabled = true;
        }

        public void StopEvent()
        {
            aTimer.Stop();
            Console.WriteLine("\n\n\n\nTHE START EVENT TIMER WAS STOPPED\n\n\n\n");

            refreshTimer.Stop();
        }


        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            //Console.WriteLine("\nAuthToken: " + storage.AuthorizationCodeFlowAuthToken + "\n");
            CurrentlyPlaying currentlyPlaying = sc.GetCurrentlyPlayingSong();
            if (storage.currentlyPlaying == null)
            {
                storage.currentlyPlaying = currentlyPlaying;
            }
            else if (!(storage.currentlyPlaying.Track.Id.Equals(currentlyPlaying.Track.Id)))
            {
                storage.currentlyPlaying = currentlyPlaying;
                //Send notifications
                //ncc.SendNowPlayingNotificationAsync(currentlyPlaying);

                Console.WriteLine("\n\n\n\nSONG UPDATED!!!!!!!!\n\n\n\n");
            }
            //Console.WriteLine("\nCurrently playing pinged");
        }

        private void RefreshEvent(Object sender, ElapsedEventArgs e)
        {
            storage.p8Token = p8.GetToken();
            //apnhttp.SendAsync("Timer2", "Test efter timer", deviceToken, storage.p8Token, false);

            auth.GetRefreshAuthorizationCodeFlowAuthToken();
            //auth.GetAuthorizationCodeFlowAuthToken();
            auth.GetClientCredentialsFlowAuthToken();
        }
    }
}
