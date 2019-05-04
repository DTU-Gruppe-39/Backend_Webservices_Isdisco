using System;
using System.Collections.Generic;
using Isdisco_Web_API.DAO;
using Isdisco_Web_API.Models;
using Newtonsoft.Json;

namespace Isdisco_Web_API.Controllers.Businesslogic
{
    public class BlacklistController
    {
        BlacklistDAO blacklistDAO = new BlacklistDAO();

        public BlacklistController()
        {
        }

        public void AddBlacklistItem (Blacklist blacklist)
        {
            blacklistDAO.Add(blacklist);
        }

        public Blacklist GetBlacklistItem (int id)
        {
            return blacklistDAO.Get(id);
        }

        public List<Blacklist> GetBlacklist ()
        {
            return blacklistDAO.GetAll();
        }

        public void DeleteBlacklistItem (int id)
        {
            blacklistDAO.Delete(id);
        }
    }
}
