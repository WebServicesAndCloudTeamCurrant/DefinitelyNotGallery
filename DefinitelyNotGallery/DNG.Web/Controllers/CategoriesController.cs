namespace DNG.Web.Controllers
{
    using DNG.Data;
    using DNG.Models;
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

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var category = this.data
               .Categories
               .All()
               .Where(a => a.CategoryID == id)
               .Select(CategoryViewModel.FromCategory)
               .FirstOrDefault();

            if (category == null)
            {
                return BadRequest(string.Format("Category with id: '{0}' does not exists!", id));
            }

            return Ok(category);
        }

        [HttpPost]
        public IHttpActionResult Create(CategoryViewModel category)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newCategory = new Category()
            {
                Name = category.Name
            };

            this.data.Categories.Add(newCategory);
            this.data.SaveChanges();

            return Ok();
        }
    }
}