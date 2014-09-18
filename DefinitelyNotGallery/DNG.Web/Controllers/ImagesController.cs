namespace DNG.Web.Controllers
{
    using System.Web.Http;
    using System.Linq;

    using DNG.Data;
    using DNG.Models;
    using DNG.Web.Models;

    public class ImagesController : BaseApiController
    {
        
        public ImagesController(IDngData data)
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

        [HttpGet]
        public IHttpActionResult All()
        {
            var images = this.data
                .Images
                .All()
                .Select(ImageViewModel.FromUser);

            return Ok(images);
        }
    }
}