using System;
using Isdisco_Web_API.Models;
using Isdisco_Web_API.Utility;
using Microsoft.AspNetCore.Http;

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
            throw new APIException(StatusCodes.Status404NotFound);
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
                    //skip index 0 because it is the user who requested it
                    //used for showing names
                    for (int j = 1; j < storageSingleton.MusicrequestList[i].UpvoteUsers.Count; j++)
                    {
                        if (storageSingleton.MusicrequestList[i].UpvoteUsers[j].Id.Equals(userid))
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
                        if (storageSingleton.MusicrequestList[i].DownvoteUsers[j].Id.Equals(userid))
                        {
                            storageSingleton.MusicrequestList[i].DownvoteUsers.RemoveAt(j);
                        }
                    }
                }
            }
        }
    }
}
