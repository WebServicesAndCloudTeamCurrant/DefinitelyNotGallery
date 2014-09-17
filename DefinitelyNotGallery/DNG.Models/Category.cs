namespace DNG.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        private ICollection<Image> images;

        public Category()
        {
            this.images = new HashSet<Image>();
        }

        [Key]
        public int CategoryID { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string Name { get; set; }

        public string Description { get; set; }

        public int? ParentID { get; set; }

        public virtual Category Parent { get; set; }

        public virtual ICollection<Image> Images
        {
            get
            {
                return this.images;
            }

            set
            {
                this.images = value;
            }
        }
    }
}