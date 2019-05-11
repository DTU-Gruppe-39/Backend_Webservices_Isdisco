using System;
using System.Collections.Generic;
using Isdisco_Web_API.DAO;
using Isdisco_Web_API.Models;

namespace Isdisco_Web_API.Controllers.Businesslogic
{
    public class MusicrequestController
    {
        MusicrequestDAO musicrequestDAO = new MusicrequestDAO();
        MusicrequestVotesDAO musicrequestVotesDAO = new MusicrequestVotesDAO();
        UserController userController = new UserController();

        public MusicrequestController()
        {
        }

        public List<Musicrequest> GetAllMusicRequests()
        {
            return musicrequestDAO.GetAll();
        }

        public Musicrequest GetMusicrequest(int id)
        {
            return musicrequestDAO.Get(id);
        }

        public void AddMusicrequest(Musicrequest musicrequestFromApp)
        {
            List<Musicrequest> musicrequests = GetAllMusicRequests();
            for (int i = 0; i < musicrequests.Count; i++)
            {
                if (musicrequestFromApp.Track.Id.Equals(musicrequests[i].Track.Id))
                {
                    UpvoteMusicrequest(musicrequests[i].Id, musicrequestFromApp.UserId);
                    return;
                }
            }

            Musicrequest musicrequest = new Musicrequest(musicrequestFromApp.Track, musicrequestFromApp.Id, musicrequestFromApp.Downvotes, musicrequestFromApp.Upvotes);
            musicrequestDAO.Add(musicrequest);
            UpvoteMusicrequest(musicrequest.Id, musicrequest.UserId);
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
