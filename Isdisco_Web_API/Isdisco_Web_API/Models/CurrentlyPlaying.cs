using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Isdisco_Web_API.Models
{
    public class CurrentlyPlaying
    {
        public Track Track { get; set; }
        public int Duration { get; set; }
        public int Progress { get; set; }

        public CurrentlyPlaying(Track track, int duration, int progress)
        {
            Track = track;
            Duration = duration;
            Progress = progress;
        }
    }
}
