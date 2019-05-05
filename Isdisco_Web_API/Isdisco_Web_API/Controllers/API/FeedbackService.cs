using System;
using Isdisco_Web_API.Controllers.Businesslogic;
using Microsoft.AspNetCore.Mvc;

namespace Isdisco_Web_API.Controllers.API
{

    [Route("api/feedback")]
    public class FeedbackService
    {

        Businesslogic.FeedbackController fc = new FeedbackController();

        [HttpPost("upload")]
        public void PostFeedback()
        {

        }

    }
}
