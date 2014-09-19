namespace DNG.Web.Controllers
{
    using DNG.Data;
    using DNG.Models;
    using DNG.Web.Models;
    using System.Linq;
    using System.Web.Http;
    using Microsoft.AspNet.Identity;

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

        [Authorize]
        [HttpPut]
        public IHttpActionResult UpdateImage(Image image)
        {
            var userId = this.User.Identity.GetUserId();

            var imageFromDb = this.data
                                .Images
                                .All()
                                .Where(i => i.ImageID == image.ImageID)
                                .FirstOrDefault();
            if (imageFromDb == null)
            {
                return BadRequest("The image does not exist");
            }

            if(userId != imageFromDb.UserID)
            {
                return BadRequest("You are not authorized to change this image");
            }

            imageFromDb.Name = image.Name;
            imageFromDb.Url = image.Url;
            imageFromDb.Description = image.Description;

            this.data.SaveChanges();
            return Ok();
        }

        [Authorize]
        [HttpDelete]
        public IHttpActionResult DeleteImage(Image image)
        {
            var userId = this.User.Identity.GetUserId();

            var imageFromDb = this.data
                                .Images
                                .All()
                                .Where(i => i.ImageID == image.ImageID)
                                .FirstOrDefault();
            
            if (imageFromDb == null)
            {
                return BadRequest("The image does not exist");
            }

            if (userId != imageFromDb.UserID)
            {
                return BadRequest("You are not authorized to change this image");
            }

            this.data.Images.Delete(imageFromDb);
            this.data.SaveChanges();
            return Ok();
        }
    }
}