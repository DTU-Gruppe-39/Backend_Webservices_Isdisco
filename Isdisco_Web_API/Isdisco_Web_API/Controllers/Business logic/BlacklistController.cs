using System;
using System.Collections.Generic;
using Isdisco_Web_API.DAO;
using Isdisco_Web_API.Models;
using Isdisco_Web_API.Utility;
using Microsoft.AspNetCore.Http;
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
            if (blacklist != null)
            {
                blacklistDAO.Add(blacklist);
                for (int i = 0; i < ControllerRegistry.GetMusicrequestController().GetAllMusicRequests().Count; i++)
                {
                    if (ControllerRegistry.GetMusicrequestController().GetAllMusicRequests()[i].Track.Id == blacklist.Track.Id)
                    {
                        ControllerRegistry.GetMusicrequestController().DeleteMusicrequest(ControllerRegistry.GetMusicrequestController().GetAllMusicRequests()[i].Id);
                    }
                }
            }
            throw new APIException(StatusCodes.Status422UnprocessableEntity);
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
