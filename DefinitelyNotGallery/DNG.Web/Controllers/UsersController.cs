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

        //[Authorize(Roles="Admin")]
        [HttpGet]
        public IHttpActionResult All()
        {
            var users = this.data
                .Users
                .All()
                .Select(UserViewModel.FromUser);

            return Ok(users);
        }

        [HttpGet]
        [Route("Users/{username}")]
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
        [Route("Users/{username}/followers")]
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

        [HttpGet]
        [Route("Users/{username}/following")]
        public IHttpActionResult Following(string username)
        {
            var foundUser = this.GetUser(username);

            if (foundUser == null)
            {
                return BadRequest("User does not exist - invalid username.");
            }

            var following = foundUser.Following
                .AsQueryable().Select(UserViewModel.FromUser);

            return Ok(following);
        }

        [HttpGet]
        [Route("Users/{username}/subscriptions")]
        public IHttpActionResult Subscriptions(string username)
        {
            var foundUser = this.GetUser(username);

            if (foundUser == null)
            {
                return BadRequest("User does not exist - invalid username.");
            }

            var subscriptions = foundUser.Subsciptions
                .AsQueryable().Select(CategoryViewModel.FromCategory);

            return Ok(subscriptions);
        }

        [HttpPut]
        [Route("Users/{currentUser}/follow/{userToFollow}")]
        public IHttpActionResult Follow(string currentUser, string userToFollow)
        {
            var foundUser = this.GetUser(currentUser);

            if (foundUser == null)
            {
                return BadRequest("User does not exist - invalid username.");
            }

            var foundUserToFollow = this.GetUser(userToFollow);

            if (foundUserToFollow == null)
            {
                return BadRequest("User to follow does not exist - invalid username.");
            }

            foundUser.Following.Add(foundUserToFollow);
            foundUserToFollow.Followers.Add(foundUser);

            return Ok();
        }

        [HttpPut]
        [Route("Users/{currentUser}/unfollow/{userToUnFollow}")]
        public IHttpActionResult UnFollow(string currentUser, string userToUnFollow)
        {
            var foundUser = this.GetUser(currentUser);

            if (foundUser == null)
            {
                return BadRequest("User does not exist - invalid username.");
            }

            var foundUserToUnFollow = this.GetUser(userToUnFollow);

            if (foundUserToUnFollow == null)
            {
                return BadRequest("User to stop following does not exist - invalid username.");
            }

            foundUser.Following.Remove(foundUserToUnFollow);
            foundUserToUnFollow.Followers.Remove(foundUser);

            return Ok();
        }
    }
}
