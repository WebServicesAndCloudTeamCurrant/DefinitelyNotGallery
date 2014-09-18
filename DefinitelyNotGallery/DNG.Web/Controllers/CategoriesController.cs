namespace DNG.Web.Controllers
{
    using DNG.Data;
    using DNG.Web.Models;
    using System.Linq;
    using System.Web.Http;

    public class CategoriesController : BaseApiController
    {
        public CategoriesController(IDngData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var categories = this.data
                .Categories
                .All()
                .Select(CategoryViewModel.FromCategory);

            return Ok(categories);
        }
    }
}