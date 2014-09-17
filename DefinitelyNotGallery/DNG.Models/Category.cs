namespace DNG.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category
    {
        private ICollection<Image> images;
        private ICollection<User> subscribers;

        public Category()
        {
            this.images = new HashSet<Image>();
            this.subscribers = new HashSet<User>();
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

        public virtual ICollection<User> Subscribers
        {
            get
            {
                return this.subscribers;
            }

            set
            {
                this.subscribers = value;
            }
        }
    }
}