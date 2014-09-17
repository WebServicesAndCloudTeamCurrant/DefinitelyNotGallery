namespace DNG.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System;

    public class Image
    {
        [Key]
        public int ImageID { get; set; } // or GUID ?

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)] // not sure for this property !
        public string Url { get; set; }

        public string Description { get; set; }

        [ForeignKey("User")]
        public string UserID { get; set; }

        public virtual User User { get; set; }

        [ForeignKey("Category")]
        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }
    }
}