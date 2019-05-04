using System;
using Newtonsoft.Json.Linq;
using Isdisco_Web_API.Controllers.Business_logic;
namespace Isdisco_Web_API.Controllers.Businesslogic
{
    public class NotificationControllerClass
    {
        private DAO.StorageSingleton storage = DAO.StorageSingleton.GetInstance();
        private JwtFromP8 p8 = new JwtFromP8();
        private CustomHttpHandler.ApnsProvider apnhttp = new CustomHttpHandler.ApnsProvider("https://api.development.push.apple.com:443", "com.Rasmus-Gregersen.Isdisco");

        //private string p8privateKey, p8privateKeyId, teamId, appBundleIdentifier, deviceToken;

        //private string notification = "Hej!";
        //private string payload;

        public NotificationControllerClass()
        {
        }


        public async System.Threading.Tasks.Task SendNotificationAsync()
        {
            await apnhttp.SendAsync("Hej", "834A1C6138CD293AC464D6CBFDBC987C3F73BC691EF55702F6DE5E84F2DA7081", p8.GetToken(), false); 
        }
        
        




            /*
            p8privateKey = "MIGTAgEAMBMGByqGSM49AgEGCCqGSM49AwEHBHkwdwIBAQQgzdgv9ENf8lc74VfU\n1jCn4WEXryur2sOK6tXBfWnNJGigCgYIKoZIzj0DAQehRANCAARH8kCLw2xvoDGl\njoRv2CWGi6xo8ygK6VYrFCq6TbKyvQksKlsbVoqsmDB3N8f0c3xOsktvYxNtaUf3\nUUHcMXs8";
            p8privateKeyId = "Q96692A9S2";
            teamId = "G6TSQJ6DQ5";
            appBundleIdentifier = "com.Rasmus-Gregersen.Isdisco";
            deviceToken = "834A1C6138CD293AC464D6CBFDBC987C3F73BC691EF55702F6DE5E84F2DA7081";

            ApnHttp2Sender http = new ApnHttp2Sender(p8privateKey, p8privateKeyId, teamId, appBundleIdentifier, ApnServerType.Development);
            await http.SendAsync(deviceToken, "{\"aps\":{\"alert\":\"Hello\"}}");
            ApnSendResult result = new ApnSendResult();
            */

           //return result.Success.ToString();
        }

    }














    /*
    internal async void PushNotificationAsync()
    {
        p8privateKey = "MIGTAgEAMBMGByqGSM49AgEGCCqGSM49AwEHBHkwdwIBAQQgzdgv9ENf8lc74VfU\n1jCn4WEXryur2sOK6tXBfWnNJGigCgYIKoZIzj0DAQehRANCAARH8kCLw2xvoDGl\njoRv2CWGi6xo8ygK6VYrFCq6TbKyvQksKlsbVoqsmDB3N8f0c3xOsktvYxNtaUf3\nUUHcMXs8";
        p8privateKeyId = "Q96692A9S2";
        teamId = "G6TSQJ6DQ5";
        appBundleIdentifier = "com.Rasmus-Gregersen.Isdisco";
        deviceToken = "834A1C6138CD293AC464D6CBFDBC987C3F73BC691EF55702F6DE5E84F2DA7081";

        server = CorePush.Apple.ApnServerType.Development;

        payload = "{\"aps\":{\"alert\":\"" + notification + "\",\"badge\":1,\"sound\":\"default\"}}";
        using (var apn = new ApnSender(p8privateKey, p8privateKeyId, teamId, appBundleIdentifier, server))
        {
            await apn.SendAsync(deviceToken, payload);

        }
        */





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



