using System;
using System.Collections.Generic;
using Isdisco_Web_API.Models;
using Isdisco_Web_API.Utility;
using Microsoft.AspNetCore.Http;

namespace Isdisco_Web_API.DAO
{
    public class BlacklistDAO : DefaultDAO<Blacklist>
    {
        StorageSingleton storageSingleton = StorageSingleton.GetInstance();

        public BlacklistDAO()
        {
        }

        public void Add(Blacklist element)
        {
            if (!storageSingleton.Blacklist.Contains(element))
            {
                storageSingleton.Blacklist.Add(element);
            }
            else
            {
                throw new APIException(StatusCodes.Status403Forbidden, "sang er allerede i blacklist");
            }

        }

        public void Delete(int id)
        {
            for (int i = 0; i < storageSingleton.Blacklist.Count; i++)
            {
                if (storageSingleton.Blacklist[i].Id.Equals(id))
                {
                    storageSingleton.Blacklist.RemoveAt(i);
                }
            }
        }

        public Blacklist Get(int id)
        {
            foreach (Blacklist blacklist in storageSingleton.Blacklist)
            {
                if (blacklist.Id.Equals(id))
                {
                    return blacklist;
                }
            }
            throw new APIException(StatusCodes.Status404NotFound);
        }

        public List<Blacklist> GetAll()
        {
            return storageSingleton.Blacklist;
        }

        public void Update(Blacklist element)
        {
            for (int i = 0; i < storageSingleton.Blacklist.Count; i++)
            {
                if (storageSingleton.Blacklist[i].Id.Equals(element.Id))
                {
                    storageSingleton.Blacklist[i] = element;
                }
            }
        }
    }
}
