﻿using System;
using System.Collections.Generic;

namespace Isdisco_Web_API.Models
{
    public class Musicrequest
    {
        public static int Counter { get; set; }
        public int Id { get; set; }
        public Track Track { get; set; }
        public int UserId { get; set; }
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

        public Musicrequest()
        {
            Counter++;
            Id = Counter;
            Timestamp = DateTime.Now;
        }
       
        public Musicrequest(Track track, int userId)
        {
            Counter++;
            Id = Counter;
            Track = track;
            UserId = userId;
            Timestamp = DateTime.Now;
        }

        public Musicrequest(Track track, int userId, int downvotes, List<int> upvotes)
        {
            Counter++;
            Id = Counter;
            Track = track;
            UserId = userId;
            Timestamp = DateTime.Now;
            Downvotes = downvotes;
            Upvotes = upvotes;
        }
    }
}