using System;
namespace Isdisco_Web_API.Models
{
    public class Blacklist
    {
        public static int Counter { get; set; }
        public int Id { get; set; }
        public Track Track { get; set; }

        public Blacklist()
        {
        }

        public Blacklist(Track track)
        {
            Id = Counter;
            Counter++;
            Track = track;
        }
    }
}
