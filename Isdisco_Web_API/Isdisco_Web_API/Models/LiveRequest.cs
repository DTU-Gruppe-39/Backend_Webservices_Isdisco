﻿using System;
using System.Collections.Generic;

namespace Isdisco_Web_API.Models
{
    public class LiveRequest
    {
        public static int Counter { get; set; }
        public int Id { get; set; }
        public Track Track { get; set; }
        public int UserId { get; set; }
        public DateTime Timestamp { get; set; }
        private List<int> downvotes = new List<int>();
        private List<User> downvoteUsers = new List<User>();
        private List<int> upvotes = new List<int>();
        private List<User> upvoteUsers = new List<User>();

        public List<int> Downvotes
        {
            get { return downvotes; }
            set { downvotes = value; }
        }

        public List<User> DownvoteUsers
        {
            get { return downvoteUsers; }
            set { downvoteUsers = value; }
        }

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

        public LiveRequest()
        {
            Timestamp = DateTime.Now;
        }

        public LiveRequest(Track track, int userId)
        {
            Counter++;
            Id = Counter;
            Track = track;
            UserId = userId;
            Timestamp = DateTime.Now;
        }

        public LiveRequest(Track track, int userId, List<int> downvotes, List<int> upvotes)
        {
            Counter++;
            Id = Counter;
            Track = track;
            UserId = userId;
            Timestamp = DateTime.Now;
            Downvotes = downvotes;
            Upvotes = upvotes;
        }

        public LiveRequest(Track track, int userId, List<int> downvotes, List<int> upvotes, List<User> upVoteUsers, List<User> downVoteUsers)
        {
            Counter++;
            Id = Counter;
            Track = track;
            UserId = userId;
            Timestamp = DateTime.Now;
            Downvotes = downvotes;
            Upvotes = upvotes;
            UpvoteUsers = upVoteUsers;
            DownvoteUsers = downVoteUsers;
        }
    }
}
