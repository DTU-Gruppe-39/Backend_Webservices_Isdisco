using System;
namespace Isdisco_Web_API.Models
{
    public class Blacklist
    {
        public Track Track { get; set; }

        public Blacklist()
        {
        }

        public Blacklist(Track track)
        {
            Track = track;
        }
    }
}
