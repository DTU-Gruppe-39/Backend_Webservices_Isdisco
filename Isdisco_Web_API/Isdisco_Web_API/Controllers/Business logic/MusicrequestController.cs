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
            if (musicrequestFromApp != null)
            {
                List<Musicrequest> musicrequests = GetAllMusicRequests();
                //Går igennem blacklisten
                for (int j = 0; j < ControllerRegistry.GetBlacklistController().GetBlacklist().Count; j++)
                {
                    //Hvis sangen findes i blacklist
                    if (musicrequestFromApp.Track.Id.Equals(ControllerRegistry.GetBlacklistController().GetBlacklist()[j].Track.Id))
                    {
                        throw new APIException(StatusCodes.Status403Forbidden, "The track is blacklisted by the admin");
                    }
                }

                // Går igennem alle musicrequests
                for (int i = 0; i < musicrequests.Count; i++)
                {
                    // Hvis sangen allerede er under musicrequests
                    if (musicrequestFromApp.Track.Id.Equals(musicrequests[i].Track.Id))
                    {
                        //Går alle Upvotes på den enkle allerede eksiterende musicrequest igennem
                        for (int j = 0; j < musicrequests[i].Upvotes.Count; j++)
                        {
                            //Hvis brugeren allerede har upvoted sangen
                            if (musicrequests[i].Upvotes[j].Equals(musicrequestFromApp.UserId))
                            {
                                throw new APIException(StatusCodes.Status302Found);
                            }
                        }

                        //Går alle Downvotes på den enkle allerede eksiterende musicrequest igennem
                        for (int k = 0; k < musicrequests[i].Downvotes.Count; k++)
                        {
                            //Hvis brugeren allerede har downvoted sangen
                            if (musicrequests[i].Downvotes[k].Equals(musicrequestFromApp.UserId))
                            {
                                //Brugerens downvote bliver fjernet fra musicrequesten
                                RemoveDownvoteMusicrequest(musicrequests[i].Id, musicrequestFromApp.UserId);

                                //Brugeren upvoter musicrequesten
                                UpvoteMusicrequest(musicrequests[i].Id, musicrequestFromApp.UserId);
                                LiveRequest liverequest = new LiveRequest(musicrequestFromApp.Track, musicrequestFromApp.UserId, musicrequestFromApp.Downvotes, musicrequestFromApp.Upvotes);
                                AddLiveRequest(liverequest);
                                UpvoteLiveRequest(liverequest.Id, liverequest.UserId);
                                throw new APIException(StatusCodes.Status202Accepted);
                            }
                        }

                        //Brugeren upvoter musicrequesten
                        UpvoteMusicrequest(musicrequests[i].Id, musicrequestFromApp.UserId);
                        LiveRequest liverequest2 = new LiveRequest(musicrequestFromApp.Track, musicrequestFromApp.UserId, musicrequestFromApp.Downvotes, musicrequestFromApp.Upvotes);
                        AddLiveRequest(liverequest2);
                        UpvoteLiveRequest(liverequest2.Id, liverequest2.UserId);
                        throw new APIException(StatusCodes.Status202Accepted);
                    }
                    else
                    {
                        //Opreter en ny musicrequest, da den ikke allerede eksitere
                        Musicrequest musicrequest = new Musicrequest(musicrequestFromApp.Track, musicrequestFromApp.UserId, musicrequestFromApp.Downvotes, musicrequestFromApp.Upvotes);
                        LiveRequest liverequest1 = new LiveRequest(musicrequestFromApp.Track, musicrequestFromApp.UserId, musicrequestFromApp.Downvotes, musicrequestFromApp.Upvotes);
                        musicrequestDAO.Add(musicrequest);
                        UpvoteMusicrequest(musicrequest.Id, musicrequest.UserId);
                        AddLiveRequest(liverequest1);
                        UpvoteLiveRequest(liverequest1.Id, liverequest1.UserId);
                    }
                }
            }
            else 
                throw new APIException(StatusCodes.Status422UnprocessableEntity); 
        }

        public void AddLiveRequest(LiveRequest musicrequestFromApp)
        {
            if (musicrequestFromApp != null)
                liveRequestDAO.Add(musicrequestFromApp);
            else
                throw new APIException(StatusCodes.Status422UnprocessableEntity);
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
