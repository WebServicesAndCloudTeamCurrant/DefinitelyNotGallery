namespace DNG.Web.Models
{
    using DNG.Models;
    using System;
    using System.Linq.Expressions;

    public class CategoryViewModel
    {
        public static Expression<Func<Category, CategoryViewModel>> FromCategory
        {
            get
            {
                return c => new CategoryViewModel()
                {
                    Id = c.CategoryID,
                    Name = c.Name,
                    Description = c.Description
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}