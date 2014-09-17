namespace DNG.Web.Controllers
{
    using DNG.Data;
    using System.Web.Http;

    public abstract class BaseApiController : ApiController
    {
        protected IDngData data;

        //// Poor man's dependency inversion
        //// Switched to Ninject
        //protected BaseApiController()
        //    : this(new DngData(new DngDbContext()))
        //{
        //}

        protected BaseApiController(IDngData data)
        {
            this.data = data;
        }
    }
}