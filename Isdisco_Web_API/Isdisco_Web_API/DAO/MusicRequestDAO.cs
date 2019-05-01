using System;
using System.Collections.Generic;
using Isdisco_Web_API.Models;

namespace Isdisco_Web_API.DAO
{
    public class MusicRequestDAO : DefaultDAO<MusicRequest>
    {
        StorageSingleton storageSingleton = StorageSingleton.GetInstance();

        public MusicRequestDAO()
        {
        }

        public void Add(MusicRequest element)
        {
            storageSingleton.MusicRequestList.Add(element);
        }

        public void Update(MusicRequest element)
        {
            for (int i = 0; i < storageSingleton.MusicRequestList.Count; i++)
            {
                if (storageSingleton.MusicRequestList[i].Id.Equals(element.Id))
                {
                    storageSingleton.MusicRequestList[i] = element;
                }
            }
        }

        public void Delete(int id)
        {
            for (int i = 0; i < storageSingleton.MusicRequestList.Count; i++)
            {
                if (storageSingleton.MusicRequestList[i].Id.Equals(id))
                {
                    storageSingleton.MusicRequestList.RemoveAt(i);
                }
            }
        }

        public List<MusicRequest> GetAll()
        {
            return storageSingleton.MusicRequestList;
        }

        public MusicRequest Get(int id)
        {
            foreach (MusicRequest musicRequest in storageSingleton.MusicRequestList)
            {
                if (musicRequest.Id.Equals(id))
                {
                    return musicRequest;
                }
            }
            return null;
        }
    }
}
