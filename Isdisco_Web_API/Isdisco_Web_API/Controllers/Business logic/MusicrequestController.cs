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
            List<Musicrequest> listToReturn = musicrequestDAO.GetAll();

            for (int i = 0; i < listToReturn.Count; i++)
            {
                for (int j = 0; j < listToReturn[i].Upvotes.Count; j++)
                {
                    listToReturn[i].UpvoteUsers.Add(userController.GetUser(listToReturn[i].Upvotes[j]));
                }
            }

            return listToReturn;
        }

        public Musicrequest GetMusicrequest(int id)
        {
            return musicrequestDAO.Get(id);
        }

        public void AddMusicrequest(Musicrequest musicrequest)
        {
            musicrequestDAO.Add(musicrequest);
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
            musicrequestVotesDAO.AddUpvote(id, userid);
        }

        public void RemoveUpvoteMusicrequest(int id, int userid)
        {
            musicrequestVotesDAO.RemoveUpvote(id, userid);
        }

        public void DownvoteMusicrequest(int id)
        {
            musicrequestVotesDAO.AddDownvote(id);
        }

        public void RemoveDownvoteMusicrequest (int id)
        {
            musicrequestVotesDAO.RemoveDownvote(id);
        }
    }
}
