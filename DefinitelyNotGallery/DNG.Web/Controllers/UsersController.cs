namespace DNG.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    using DNG.Data;
    using DNG.Web.Models;

    public class UsersController : BaseApiController
    {
        public UsersController(IDngData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult ByUsername(string username)
        {
            var foundUser = this.GetUserModel(username);

            if (foundUser == null)
            {
                return BadRequest("User does not exist - invalid username.");
            }

            return Ok(foundUser);
        }

        [HttpGet]
        public IHttpActionResult Followers(string username)
        {
            var foundUser = this.GetUser(username);

            if (foundUser == null)
            {
                return BadRequest("User does not exist - invalid username.");
            }

            var followers = foundUser.Followers
                .AsQueryable().Select(UserViewModel.FromUser);

            return Ok(followers);
        }
    }
}
