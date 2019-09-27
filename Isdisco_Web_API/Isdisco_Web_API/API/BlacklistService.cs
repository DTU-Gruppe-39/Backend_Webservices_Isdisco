using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Isdisco_Web_API.Controllers.Businesslogic;
using Isdisco_Web_API.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Isdisco_Web_API.Controllers.API
{
    [Route("api/blacklist")]
    public class BlacklistService : Controller
    {/*
        BlacklistController blacklistController = ControllerRegistry.GetBlacklistController();

        // GET: api/blacklist
        [HttpGet]
        public List<Blacklist> Get()
        {
            return blacklistController.GetBlacklist();
        }

        // GET api/blacklist/5
        [HttpGet("{id}")]
        public Blacklist Get(int id)
        {
            return blacklistController.GetBlacklistItem(id);
        }

        // POST api/blacklist
        [HttpPost]
        public void Post([FromBody] Blacklist blacklist)
        {
            blacklistController.AddBlacklistItem(blacklist);
        }

        // DELETE api/blacklist/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            blacklistController.DeleteBlacklistItem(id);
        }
    */}
}