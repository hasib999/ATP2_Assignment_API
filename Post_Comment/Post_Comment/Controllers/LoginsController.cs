using Post_Comment.Models;
using Post_Comment.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Post_Comment.Controllers
{
    public class LoginsController : ApiController
    {
        LoginRepository loginRepository = new LoginRepository();
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(loginRepository.GetAll());
        }
        [Route("")]
        public IHttpActionResult Post(Login login)
        {
            loginRepository.Insert(login);
            return Created("/api/Logins/" + login.Lid, login);
        }
    }
}
