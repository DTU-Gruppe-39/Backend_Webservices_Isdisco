﻿using System;
using Isdisco_Web_API.Models;

namespace Isdisco_Web_API.DAO
{
    public class MusicrequestVotesDAO
    {
        StorageSingleton storageSingleton = StorageSingleton.GetInstance();

        public MusicrequestVotesDAO()
        {
        }

        public void AddUpvote (int id, User user)
        {
            for (int i = 0; i < storageSingleton.MusicrequestList.Count; i++)
            {
                if (storageSingleton.MusicrequestList[i].Id.Equals(id))
                {
                    storageSingleton.MusicrequestList[i].Upvotes.Add(user.Id);
                    storageSingleton.MusicrequestList[i].UpvoteUsers.Add(user);
                }
            }
        }

        public void RemoveUpvote (int id, int userid)
        {
            for (int i = 0; i < storageSingleton.MusicrequestList.Count; i++)
            {
                if (storageSingleton.MusicrequestList[i].Id.Equals(id))
                {
                    for(int j = 0; j < storageSingleton.MusicrequestList[i].Upvotes.Count; j++)
                    {
                        if (storageSingleton.MusicrequestList[i].Upvotes[j].Equals(userid))
                        {
                            storageSingleton.MusicrequestList[i].Upvotes.RemoveAt(j);
                        }
                    }
                }
            }

            for (int i = 0; i < storageSingleton.MusicrequestList.Count; i++)
            {
                if (storageSingleton.MusicrequestList[i].Id.Equals(id))
                {
                    for (int j = 0; j < storageSingleton.MusicrequestList[i].UpvoteUsers.Count; j++)
                    {
                        if (storageSingleton.MusicrequestList[i].UpvoteUsers[j].Equals(userid))
                        {
                            storageSingleton.MusicrequestList[i].UpvoteUsers.RemoveAt(j);
                        }
                    }
                }
            }
        }

        public void AddDownvote (int id, User user)
        {
            for (int i = 0; i < storageSingleton.MusicrequestList.Count; i++)
            {
                if (storageSingleton.MusicrequestList[i].Id.Equals(id))
                {
                    storageSingleton.MusicrequestList[i].Downvotes.Add(user.Id);
                    storageSingleton.MusicrequestList[i].DownvoteUsers.Add(user);
                }
            }
        }

        public void RemoveDownvote(int id, int userid)
        {
            for (int i = 0; i < storageSingleton.MusicrequestList.Count; i++)
            {
                if (storageSingleton.MusicrequestList[i].Id.Equals(id))
                {
                    for (int j = 0; j < storageSingleton.MusicrequestList[i].Downvotes.Count; j++)
                    {
                        if (storageSingleton.MusicrequestList[i].Downvotes[j].Equals(userid))
                        {
                            storageSingleton.MusicrequestList[i].Downvotes.RemoveAt(j);
                        }
                    }
                }
            }

            for (int i = 0; i < storageSingleton.MusicrequestList.Count; i++)
            {
                if (storageSingleton.MusicrequestList[i].Id.Equals(id))
                {
                    for (int j = 0; j < storageSingleton.MusicrequestList[i].DownvoteUsers.Count; j++)
                    {
                        if (storageSingleton.MusicrequestList[i].DownvoteUsers[j].Equals(userid))
                        {
                            storageSingleton.MusicrequestList[i].DownvoteUsers.RemoveAt(j);
                        }
                    }
                }
            }
        }
    }
}
