using System;
namespace Isdisco_Web_API.Models
{
    public class Blacklisted
    {
        public Track Track { get; set; }

        public Blacklisted()
        {
        }

        public Blacklisted(Track track)
        {
            Track = track;
        }
    }
}
