using System;
namespace Isdisco_Web_API.Models
{
    public class DevicePushToken
    {
        public String DeviceToken { get; set; }
        public int DeviceTokenId { get; set; }

        public DevicePushToken()
        {
        }

        public DevicePushToken(string deviceToken, int deviceTokenId)
        {
            DeviceToken = deviceToken;
            DeviceTokenId = deviceTokenId;
        }

        public static implicit operator string(DevicePushToken v)
        {
            throw new NotImplementedException();
        }
    }
}
