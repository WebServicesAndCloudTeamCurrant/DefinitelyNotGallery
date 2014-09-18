namespace DNG.Web.Models
{
    using System;
    using System.Linq.Expressions;

    using DNG.Models;

    public class ImageViewModel
    {
        public static Expression<Func<Image, ImageViewModel>> FromImage
        {
            get
            {
                return x => new ImageViewModel
                {
                    Id = x.ImageID,
                    Name = x.Name,
                    Url = x.Url
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }
    }
}