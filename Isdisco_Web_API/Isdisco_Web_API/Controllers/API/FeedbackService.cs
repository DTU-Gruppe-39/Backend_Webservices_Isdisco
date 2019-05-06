using System;
using System.Collections.Generic;
using Isdisco_Web_API.Controllers.Businesslogic;
using Isdisco_Web_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Isdisco_Web_API.Controllers.API
{

    [Route("api/feedback")]
    public class FeedbackService : Controller
    {

        FeedbackController fc = new FeedbackController();

        [HttpGet("all")]
        public List<Feedback> Get()
        {
            return fc.GetFeedbackList();
        }

        [HttpGet("tag")]
        public List<Feedback> Get(string tag)
        {
            return fc.GetTaggedFeedbackList(tag);
        }

        [HttpPost("uploadFeedback")]
        public string PostFeedback([FromBody] Feedback feedback)
        {
            fc.PostFeedback(feedback);
            return "Sent";
        }
    }
}
