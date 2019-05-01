using System;
using System.Collections.Generic;

namespace Isdisco_Web_API.Models
{
    public class MusicRequest
    {
        public string Id { get; set; }
        public Track Track { get; set; }
        public string UserId { get; set; }
        public DateTime Timestamp { get; set; }
        public int Downvotes { get; set; }
        private List<int> upvotes = new List<int>();
        private List<User> upvoteUsers = new List<User>();

        public List<int> Upvotes
        {
            get { return upvotes; }
            set { upvotes = value; }
        }

        public List<User> UpvoteUsers
        {
            get { return upvoteUsers; }
            set { upvoteUsers = value; }
        }

        public MusicRequest()
        {
        }

        public MusicRequest(string id, Track track, string userId, DateTime timestamp, int downvotes, List<int> upvotes)
        {
            Id = id;
            Track = track;
            UserId = userId;
            Timestamp = timestamp;
            Downvotes = downvotes;
            Upvotes = upvotes;
        }
    }
}
