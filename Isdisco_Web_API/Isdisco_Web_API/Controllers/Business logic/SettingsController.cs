using System;
using System.Timers;
using Isdisco_Web_API.DAO;
using Isdisco_Web_API.Models;

namespace Isdisco_Web_API.Controllers.Businesslogic
{
    public class SettingsController
    {
        private static Timer aTimer;
        SpotifyControllerClass sc = new SpotifyControllerClass();
        NotificationControllerClass ncc = new NotificationControllerClass();
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
        }

        public void StopEvent()
        {
            aTimer.Stop();
            Console.WriteLine("\n\n\n\nTHE START EVENT TIMER WAS STOPPED\n\n\n\n");
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
                ncc.SendNowPlayingNotificationAsync(currentlyPlaying.Track);
                Console.WriteLine("\n\n\n\nSONG UPDATED!!!!!!!!\n\n\n\n");
            }
            //Console.WriteLine("\nCurrently playing pinged");
        }
    }
}
