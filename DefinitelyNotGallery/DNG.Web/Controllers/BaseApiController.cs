namespace DNG.Web.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using DNG.Data;
    using DNG.Web.Models;
    using DNG.Models;

    public abstract class BaseApiController : ApiController
    {
        protected IDngData data;

        protected BaseApiController(IDngData data)
        {
            this.data = data;
        }

        [NonAction]
        protected UserViewModel GetUserModel(string username)
        {
            var foundUser = this.data
                .Users
                .All()
                .Where(user => user.UserName == username)
                .Select(UserViewModel.FromUser)
                .FirstOrDefault();

            return foundUser;
        }

        [NonAction]
        protected User GetUser(string username)
        {
            var foundUser = this.data
                .Users
                .All()
                .Where(user => user.UserName == username)
                .FirstOrDefault();

            return foundUser;
        }
    }
}