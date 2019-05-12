using System;
using System.Collections.Generic;
using Isdisco_Web_API.Models;

namespace Isdisco_Web_API.DAO
{
    public class LiveRequestDAO : DefaultDAO<LiveRequest>
    {
        StorageSingleton storageSingleton = StorageSingleton.GetInstance();

        public LiveRequestDAO()
        {
        }

        public void Add(LiveRequest element)
        {
            storageSingleton.LiverequestList.Add(element);
        }

        public void Update(LiveRequest element)
        {
            for (int i = 0; i < storageSingleton.LiverequestList.Count; i++)
            {
                if (storageSingleton.LiverequestList[i].Id.Equals(element.Id))
                {
                    storageSingleton.LiverequestList[i] = element;
                }
            }
        }

        public void Delete(int id)
        {
            for (int i = 0; i < storageSingleton.LiverequestList.Count; i++)
            {
                if (storageSingleton.LiverequestList[i].Id.Equals(id))
                {
                    storageSingleton.LiverequestList.RemoveAt(i);
                }
            }
        }

        public void DeleteAll()
        {

            storageSingleton.LiverequestList.Clear();
        }

        public List<LiveRequest> GetAll()
        {
            return storageSingleton.LiverequestList;
        }

        public LiveRequest Get(int id)
        {
            foreach (LiveRequest musicRequest in storageSingleton.LiverequestList)
            {
                if (musicRequest.Id.Equals(id))
                {
                    return musicRequest;
                }
            }
            return null;
        }

        public void AddUpvote(int id, User user)
        {
            for (int i = 0; i < storageSingleton.LiverequestList.Count; i++)
            {
                if (storageSingleton.LiverequestList[i].Id.Equals(id))
                {
                    storageSingleton.LiverequestList[i].Upvotes.Add(user.Id);
                    storageSingleton.LiverequestList[i].UpvoteUsers.Add(user);
                }
            }
        }
    }
}
