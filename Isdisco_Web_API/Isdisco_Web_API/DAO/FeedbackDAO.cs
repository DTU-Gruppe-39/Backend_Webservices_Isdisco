using System;
using System.Collections.Generic;
using Isdisco_Web_API.Models;

namespace Isdisco_Web_API.DAO
{
    public class FeedbackDAO : DefaultDAO<Feedback>
    {
        StorageSingleton storageSingleton = StorageSingleton.GetInstance();

        public FeedbackDAO()
        {
        }

        public void Add(Feedback feedback)
        {
            storageSingleton.FeedbackList.Add(feedback);
        }

        public void Delete(int id)
        {
            for (int i = 0; i < storageSingleton.FeedbackList.Count; i++)
            {
                if (storageSingleton.FeedbackList[i].Id.Equals(id))
                {
                    storageSingleton.FeedbackList.RemoveAt(i);
                }
            }
        }

        public void DeleteAll()
        {
            storageSingleton.FeedbackList.Clear();
        }

        public List<Feedback> GetAll()
        {
            return storageSingleton.FeedbackList;
        }

        public Feedback Get(int id)
        {
            foreach (Feedback feedback in storageSingleton.FeedbackList)
            {
                if (feedback.Id.Equals(id))
                {
                    return feedback;
                }
            }
            return null;
        }

        public List<Feedback> GetTag(string tag)
        {
            List<Feedback> taggedFeedbackList = new List<Feedback>();
            foreach (Feedback feedback in storageSingleton.FeedbackList)
            {
                if (feedback.Tag.Equals(tag))
                {
                    taggedFeedbackList.Add(feedback);
                }
            }
            return taggedFeedbackList;
        }

        public void Update(Feedback element)
        {
            throw new NotImplementedException();
        }
    }
}
