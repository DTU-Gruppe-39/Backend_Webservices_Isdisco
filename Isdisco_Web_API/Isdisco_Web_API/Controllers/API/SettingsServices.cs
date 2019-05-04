using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Isdisco_Web_API.Controllers.Businesslogic;
using Isdisco_Web_API.DAO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Isdisco_Web_API.Controllers.API
{
    [Route("api/settings")]
    public class SettingsServices : Controller
    {
        StorageSingleton storage = StorageSingleton.GetInstance();
        Businesslogic.SpotifyControllerClass scc = new Businesslogic.SpotifyControllerClass();
        SettingsController ss = new SettingsController();
        // GET: api/values
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/values
        [HttpGet("start")]
        public string StartEvent()
        {
            if (storage.AuthorizationCodeFlowAuthCode == null)
            {
                storage.LoginCallback = "settings/start";
                Response.Redirect(scc.GetUserScopes());
                return null;
            }
            if (storage.AuthorizationCodeFlowAuthToken == null)
            {
                scc.GetAuthorizationCodeToken();
            }
            ss.StartEvent();
            return "started";
        }

        [HttpGet("stop")]
        public string StopEvent()
        {
            ss.StopEvent();
            return "stopped";
        }

        // PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
