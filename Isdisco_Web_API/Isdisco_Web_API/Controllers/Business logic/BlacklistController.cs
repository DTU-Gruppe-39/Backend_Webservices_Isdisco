﻿using System;
using System.Collections.Generic;
using Isdisco_Web_API.DAO;
using Isdisco_Web_API.Models;
using Newtonsoft.Json;

namespace Isdisco_Web_API.Controllers.Businesslogic
{
    public class BlacklistController
    {
        BlacklistDAO blacklistDAO = new BlacklistDAO();
        MusicrequestController musicrequestController = new MusicrequestController();

        public BlacklistController()
        {
        }

        public void AddBlacklistItem (Blacklist blacklist)
        {
            blacklistDAO.Add(blacklist);
            for(int i = 0; i < musicrequestController.GetAllMusicRequests().Count; i++)
            {
                if (musicrequestController.GetAllMusicRequests()[i].Track.Id == blacklist.Track.Id)
                {
                    musicrequestController.DeleteMusicrequest(musicrequestController.GetAllMusicRequests()[i].Id);
                }
            }
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
