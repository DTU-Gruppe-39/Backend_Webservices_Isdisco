using System;
using System.Collections.Generic;

namespace Isdisco_Web_API.Models
{
    public class ListOfTracks
    {
        private List<Track> tracks = new List<Track>();
        public List<Track> Tracks
        {
            get { return tracks; }
            set { tracks = value; }
        }
    }
}
