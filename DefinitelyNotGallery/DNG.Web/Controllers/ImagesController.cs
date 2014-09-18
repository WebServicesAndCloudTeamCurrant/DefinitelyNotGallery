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
        public IHttpActionResult GetByCategory(int categoryId)
        {
            var images = this.data
                .Images
                .All()
                .Where(i => i.CategoryID == categoryId)
                .Select(ImageViewModel.FromImage);

            return Ok(images);
        }
    }
}