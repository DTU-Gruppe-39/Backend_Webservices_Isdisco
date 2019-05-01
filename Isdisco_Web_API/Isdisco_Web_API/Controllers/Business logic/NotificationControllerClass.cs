using System;
using PushSharp;
using PushSharp.Apple;
using CorePush;
using CorePush.Apple;
using Newtonsoft.Json.Linq;

namespace Isdisco_Web_API.Controllers.Businesslogic
{
    public class NotificationControllerClass
    {
        private DAO.StorageSingleton storage = DAO.StorageSingleton.GetInstance();
        private JwtFromP8 p8 = new JwtFromP8();

        private string p8privateKey, p8privateKeyId, teamId, appBundleIdentifier, deviceToken;
        private ApnServerType server;

        private string notification;
        


        public NotificationControllerClass()
        {
        }

        internal async System.Threading.Tasks.Task<string> PushNotificationAsync()
        {
            p8privateKey = "MIGTAgEAMBMGByqGSM49AgEGCCqGSM49AwEHBHkwdwIBAQQgzdgv9ENf8lc74VfU\n1jCn4WEXryur2sOK6tXBfWnNJGigCgYIKoZIzj0DAQehRANCAARH8kCLw2xvoDGl\njoRv2CWGi6xo8ygK6VYrFCq6TbKyvQksKlsbVoqsmDB3N8f0c3xOsktvYxNtaUf3\nUUHcMXs8";
            p8privateKeyId = "Q96692A9S2";
            teamId = "G6TSQJ6DQ5";
            appBundleIdentifier = "com.Rasmus-Gregersen.Isdisco";
            deviceToken = "834A1C6138CD293AC464D6CBFDBC987C3F73BC691EF55702F6DE5E84F2DA7081";

            server = CorePush.Apple.ApnServerType.Development;

            notification = (string)JObject.Parse("{\n   “aps” : {\n      “badge” : 9\n      “sound” : “bingbong.aiff”\n   },\n   “messageID” : “ABCDEFGHIJ”\n}");
            using (var apn = new ApnSender(p8privateKey, p8privateKeyId, teamId, appBundleIdentifier, server))
            {
                await apn.SendAsync(deviceToken, notification);
                
            }

            return p8.GetToken();






            /*
            // Configuration (NOTE: .pfx can also be used here)
            var config = new ApnsConfiguration(ApnsConfiguration.ApnsServerEnvironment.Sandbox,
            "push-cert.p8", "push-cert-pwd");

            // Create a new broker
            var apnsBroker = new ApnsServiceBroker(config);

            // Wire up events
            apnsBroker.OnNotificationFailed += (notification, aggregateEx) =>
            {

                aggregateEx.Handle(ex =>
                {

                    // See what kind of exception it was to further diagnose
                    if (ex is ApnsNotificationException)
                    {
                        var notificationException = (ApnsNotificationException)ex;

                        // Deal with the failed notification
                        var apnsNotification = notificationException.Notification;
                        var statusCode = notificationException.ErrorStatusCode;

                        Console.WriteLine($"Apple Notification Failed: ID={apnsNotification.Identifier}, Code={statusCode}");

                    }
                    else
                    {
                        // Inner exception might hold more useful information like an ApnsConnectionException           
                        Console.WriteLine($"Apple Notification Failed for some unknown reason : {ex.InnerException}");
                    }

                    // Mark it as handled
                    return true;
                });
            };

            apnsBroker.OnNotificationSucceeded += (notification) =>
            {
                Console.WriteLine("Apple Notification Sent!");
            };

            // Start the broker
            apnsBroker.Start();

            foreach (var deviceToken in storage.DevicePushTokenList)
            {
                // Queue a notification to send
                apnsBroker.QueueNotification(new ApnsNotification
                {
                    DeviceToken = deviceToken,
                    Payload = JObject.Parse("{\"aps\":{\"badge\":7}}")
                });
            }

            // Stop the broker, wait for it to finish   
            // This isn't done after every message, but after you're
            // done with the broker
            apnsBroker.Stop();
     */   
    }
 
   }

}
