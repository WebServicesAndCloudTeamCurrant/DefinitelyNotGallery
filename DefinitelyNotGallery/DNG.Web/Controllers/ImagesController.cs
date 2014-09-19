namespace DNG.Web.Controllers
{
    using DNG.Data;
    using DNG.Models;
    using DNG.Web.Models;
    using System.Linq;
    using System.Web.Http;

    public class ImagesController : BaseApiController
    {
        public ImagesController(IDngData data)
            : base(data)
        {
        }

        [HttpPost]
        public IHttpActionResult Upload(Image image)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            this.data.Images.Add(image);
            this.data.SaveChanges();

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var images = this.data
                .Images
                .All()
                .Select(ImageViewModel.FromImage);

            return Ok(images);
        }

        [HttpGet]
        public IHttpActionResult GetByCategory(int id)
        {
            var images = this.data
                .Images.All()
                .Where(x => x.CategoryID == id)
                .Select(ImageViewModel.FromImage);

            return Ok(images);
        }
    }
}