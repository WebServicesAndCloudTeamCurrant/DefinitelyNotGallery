namespace DNG.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Subscription
    {
        [Key]
        public int SubscriptionID { get; set; }

        [Required]
        public int SubscribedUserID { get; set; }

        [Required]
        public bool IsSubscribed { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }

        public virtual User User { get; set; }
    }
}