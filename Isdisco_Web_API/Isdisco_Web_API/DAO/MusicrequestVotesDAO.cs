using System;
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
        }

        public void AddDownvote (int id)
        {
            for (int i = 0; i < storageSingleton.MusicrequestList.Count; i++)
            {
                if (storageSingleton.MusicrequestList[i].Id.Equals(id))
                {
                    storageSingleton.MusicrequestList[i].Downvotes++;
                }
            }
        }

        public void RemoveDownvote(int id)
        {
            for (int i = 0; i < storageSingleton.MusicrequestList.Count; i++)
            {
                if (storageSingleton.MusicrequestList[i].Id.Equals(id))
                {
                    storageSingleton.MusicrequestList[i].Downvotes--;
                }
            }
        }
    }
}
