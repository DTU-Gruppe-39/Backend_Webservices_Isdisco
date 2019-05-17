using System;
namespace Isdisco_Web_API.Controllers.Businesslogic
{
    public static class ControllerRegistry
    {
        private static BlacklistController blacklistController;
        private static FeedbackController feedbackController;
        private static MusicrequestController musicrequestController;
        private static NotificationControllerClass notificationControllerClass;
        private static SettingsController settingsController;
        private static SpotifyControllerClass spotifyControllerClass;
        private static UserController userController;
        private static SpotifyAuthController spotifyAuthController;

        public static BlacklistController GetBlacklistController()
        {
            if (blacklistController == null)
                blacklistController = new BlacklistController();
            return blacklistController;
        }

        public static FeedbackController GetFeedbackController()
        {
            if (feedbackController == null)
                feedbackController = new FeedbackController();
            return feedbackController;
        }

        public static MusicrequestController GetMusicrequestController()
        {
            if (musicrequestController == null)
                musicrequestController = new MusicrequestController();
            return musicrequestController;
        }

        public static NotificationControllerClass GetNotificationController()
        {
            if (notificationControllerClass == null)
                notificationControllerClass = new NotificationControllerClass();
            return notificationControllerClass;
        }

        public static SettingsController GetSettingsController()
        {
            if (settingsController == null)
                settingsController = new SettingsController();
            return settingsController;
        }

        public static SpotifyControllerClass GetSpotifyController()
        {
            if (spotifyControllerClass == null)
                spotifyControllerClass = new SpotifyControllerClass();
            return spotifyControllerClass;
        }

        public static SpotifyAuthController GetSpotifyAuthController()
        {
            if (spotifyAuthController == null)
                spotifyAuthController = new SpotifyAuthController();
            return spotifyAuthController;
        }

        public static UserController GetUserController()
        {
            if (userController == null)
                userController = new UserController();
            return userController;
        }
    }
}
