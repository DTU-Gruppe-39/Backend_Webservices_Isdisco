using System;
using System.Collections.Generic;
using Isdisco_Web_API.DAO;
using Isdisco_Web_API.Models;
using Isdisco_Web_API.Utility;
using Microsoft.AspNetCore.Http;

namespace Isdisco_Web_API.Controllers.Businesslogic
{
    public class MusicrequestController
    {
        MusicrequestDAO musicrequestDAO = new MusicrequestDAO();
        MusicrequestVotesDAO musicrequestVotesDAO = new MusicrequestVotesDAO();
        LiveRequestDAO liveRequestDAO = new LiveRequestDAO();
        UserController userController = ControllerRegistry.GetUserController();
        //BlacklistController blacklistController = ControllerRegistry.GetBlacklistController();

        public MusicrequestController()
        {
        }

        public List<Musicrequest> GetAllMusicRequests()
        {
            return musicrequestDAO.GetAll();
        }

        public List<LiveRequest> GetAllLiveRequests()
        {
            return liveRequestDAO.GetAll();
        }

        public Musicrequest GetMusicrequest(int id)
        {
            return musicrequestDAO.Get(id);
        } 

        public void AddMusicrequest(Musicrequest musicrequestFromApp)
        {
            List<Musicrequest> musicrequests = GetAllMusicRequests();
            for (int j = 0; j < ControllerRegistry.GetBlacklistController().GetBlacklist().Count; j++)
            {
                if (musicrequestFromApp.Track.Id == ControllerRegistry.GetBlacklistController().GetBlacklist()[j].Track.Id)
                {
                    throw new APIException(StatusCodes.Status302Found, "The track is blacklisted by the admin");
                }
            }

            for (int i = 0; i < musicrequests.Count; i++)
            {
                if (musicrequestFromApp.Track.Id.Equals(musicrequests[i].Track.Id))
                {
                    //Song is already requested
                    UpvoteMusicrequest(musicrequests[i].Id, musicrequestFromApp.UserId);
                    LiveRequest liverequest = new LiveRequest(musicrequestFromApp.Track, musicrequestFromApp.UserId, musicrequestFromApp.Downvotes, musicrequestFromApp.Upvotes);
                    AddLiveRequest(liverequest);
                    UpvoteLiveRequest(liverequest.Id, liverequest.UserId);
                    throw new APIException(StatusCodes.Status202Accepted);
                }
            }

            Musicrequest musicrequest = new Musicrequest(musicrequestFromApp.Track, musicrequestFromApp.UserId, musicrequestFromApp.Downvotes, musicrequestFromApp.Upvotes);
            LiveRequest liverequest1 = new LiveRequest(musicrequestFromApp.Track, musicrequestFromApp.UserId, musicrequestFromApp.Downvotes, musicrequestFromApp.Upvotes);
            musicrequestDAO.Add(musicrequest);
            UpvoteMusicrequest(musicrequest.Id, musicrequest.UserId);
            AddLiveRequest(liverequest1);
            UpvoteLiveRequest(liverequest1.Id, liverequest1.UserId);

        }

        public void AddLiveRequest(LiveRequest musicrequestFromApp)
        {
            liveRequestDAO.Add(musicrequestFromApp);
        }

        public void DeleteLiveRequest(int id)
        {
            liveRequestDAO.Delete(id);
        }

        public void DeleteAllLiveRequest()
        {
            liveRequestDAO.DeleteAll();
        }

        public void DeleteMusicrequest(int id)
        {
            musicrequestDAO.Delete(id);
        }

        public void DeleteAllMusicrequest()
        {
            musicrequestDAO.DeleteAll();
        }

        public void UpvoteMusicrequest(int id, int userid)
        {
            musicrequestVotesDAO.AddUpvote(id, userController.GetUser(userid));

        }

        public void UpvoteLiveRequest(int id, int userid)
        {
            liveRequestDAO.AddUpvote(id, userController.GetUser(userid));

        }

        public void RemoveUpvoteMusicrequest(int id, int userid)
        {
            musicrequestVotesDAO.RemoveUpvote(id, userid);
        }

        public void DownvoteMusicrequest(int id, int userid)
        {
            musicrequestVotesDAO.AddDownvote(id, userController.GetUser(userid));
        }

        public void RemoveDownvoteMusicrequest (int id, int userid)
        {
            musicrequestVotesDAO.RemoveDownvote(id, userid);
        }
    }
}
