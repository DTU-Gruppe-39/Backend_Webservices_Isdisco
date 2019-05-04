using System;
using System.Collections.Generic;
using Isdisco_Web_API.Models;

namespace Isdisco_Web_API.DAO
{
    public class MusicrequestDAO : DefaultDAO<Musicrequest>
    {
        StorageSingleton storageSingleton = StorageSingleton.GetInstance();

        public MusicrequestDAO()
        {
        }

        public void Add(Musicrequest element)
        {
            storageSingleton.MusicrequestList.Add(element);
        }

        public void Update(Musicrequest element)
        {
            for (int i = 0; i < storageSingleton.MusicrequestList.Count; i++)
            {
                if (storageSingleton.MusicrequestList[i].Id.Equals(element.Id))
                {
                    storageSingleton.MusicrequestList[i] = element;
                }
            }
        }

        public void Delete(int id)
        {
            for (int i = 0; i < storageSingleton.MusicrequestList.Count; i++)
            {
                if (storageSingleton.MusicrequestList[i].Id.Equals(id))
                {
                    storageSingleton.MusicrequestList.RemoveAt(i);
                }
            }
        }

        public List<Musicrequest> GetAll()
        {
            return storageSingleton.MusicrequestList;
        }

        public Musicrequest Get(int id)
        {
            foreach (Musicrequest musicRequest in storageSingleton.MusicrequestList)
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
