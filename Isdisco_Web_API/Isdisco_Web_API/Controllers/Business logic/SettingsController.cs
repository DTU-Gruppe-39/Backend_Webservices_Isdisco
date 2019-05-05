using System;
using System.Timers;
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
        private JwtFromP8 p8 = new JwtFromP8();
        //NotificationControllerClass ncc = new NotificationControllerClass();
        StorageSingleton storage = StorageSingleton.GetInstance();

        public SettingsController()
        {
        }

        public void StartEvent()
        {
            // Create a timer with a two second interval.
            aTimer = new Timer(10000);
            
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
            Console.WriteLine("\n\n\n\nTHE START EVENT TIMER WAS STARTED\n\n\n\n");

            refreshTimer = new Timer(1800000);

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

        private void RefreshEvent(object sender, ElapsedEventArgs e)
        {
            storage.p8Token = p8.GetToken();
            auth.GetAuthorizationCodeFlowAuthToken();
            auth.GetClientCredentialsFlowAuthToken();
        }
    }
}
