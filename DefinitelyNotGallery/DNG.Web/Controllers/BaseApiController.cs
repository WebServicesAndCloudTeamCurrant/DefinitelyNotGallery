namespace DNG.Web.Controllers
{
    using DNG.Data;
    using System.Web.Http;

    public abstract class BaseApiController : ApiController
    {
        protected IDNGData data;

        // Poor man's dependency inversion
        protected BaseApiController()
            : this(new DNGData(new DngDbContext()))
        {
        }

        protected BaseApiController(IDNGData data)
        {
            this.data = data;
        }
    }
}