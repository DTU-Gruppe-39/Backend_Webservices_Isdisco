using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Isdisco_Web_API.Models;
using Isdisco_Web_API.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Isdisco_Web_API.Controllers.API
{
    [Route("api/authentication")]
    public class AuthenticationService : Controller
    {
        // POST api/autentication
        [HttpPost("login")]
        public string Login(LoginDetails loginDetails)
        {
            return "JWT";
        }

        // 

    }
}
