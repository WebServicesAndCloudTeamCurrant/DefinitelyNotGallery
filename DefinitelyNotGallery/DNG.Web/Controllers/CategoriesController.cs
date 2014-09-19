namespace DNG.Web.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using DNG.Data;
    using DNG.Models;
    using DNG.Web.Models;

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

            var newCategory = new Category
            {
                Name = category.Name
            };

            this.data.Categories.Add(newCategory);
            this.data.SaveChanges();

            category.Id = newCategory.CategoryID;
            return Ok(category);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, CategoryViewModel category)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingCategory = this.data
                .Categories
                .All()
                .FirstOrDefault(a => a.CategoryID == id);

            if (existingCategory == null)
            {
                return BadRequest("Such category does not exists!");
            }

            existingCategory.Name = category.Name;
            this.data.SaveChanges();

            category.Id = id;
            return Ok(category);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingCategory = this.data
                .Categories
                .All()
                .FirstOrDefault(a => a.CategoryID == id);

            if (existingCategory == null)
            {
                return BadRequest("Such category does not exists!");
            }

            this.data.Categories.Delete(existingCategory);
            this.data.SaveChanges();

            return Ok();
        }
    }
}