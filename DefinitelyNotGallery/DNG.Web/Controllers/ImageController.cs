namespace DNG.Web.Controllers
{
    using System.Web.Http;
    using System.Linq;

    using DNG.Data;
    using DNG.Models;

    public class ImageController : BaseApiController
    {
        // Poor man's dependency inversion
        public ImageController()
            : this(new DNGData(new DngDbContext()))
        {
        }

        public ImageController(IDNGData data)
            : base(data)
        {
        }

        [HttpPost]
        public IHttpActionResult Create()
        {
            // Used to create the tables not associated with users 
            this.data.SaveChanges();
            return Ok();
        }
    }
}