using System;
using System.Collections.Generic;
using Isdisco_Web_API.Models;

namespace Isdisco_Web_API.DAO
{
    public class LiveRequestDAO : DefaultDAO<Musicrequest>
    {
        StorageSingleton storageSingleton = StorageSingleton.GetInstance();

        public LiveRequestDAO()
        {
        }

        public void Add(Musicrequest element)
        {
            storageSingleton.LiverequestList.Add(element);
        }

        public void Update(Musicrequest element)
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

        public List<Musicrequest> GetAll()
        {
            return storageSingleton.LiverequestList;
        }

        public Musicrequest Get(int id)
        {
            foreach (Musicrequest musicRequest in storageSingleton.LiverequestList)
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
