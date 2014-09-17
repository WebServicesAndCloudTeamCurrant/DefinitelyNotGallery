namespace DNG.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {
        private ICollection<Image> images;
        private ICollection<User> followers;
        private ICollection<User> following;
        private ICollection<Category> subscriptions;

        public User()
        {
            this.images = new HashSet<Image>();
            this.followers = new HashSet<User>();
            this.following = new HashSet<User>();
            this.subscriptions = new HashSet<Category>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);

            // Add custom user claims here
            return userIdentity;
        }

        [MinLength(2)]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [MinLength(2)]
        [MaxLength(20)]
        public string LastName { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DateOfBirth { get; set; }

        [NotMapped]
        public int? Age
        {
            get
            {
                // TODO: calculate age by date of birth
                throw new NotImplementedException("Гърмим културно :)");
            }
        }

        [MinLength(2)]
        [MaxLength(20)]
        public string Country { get; set; }

        [MinLength(2)]
        [MaxLength(20)]
        public string City { get; set; }

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

        public virtual ICollection<User> Followers
        {
            get
            {
                return this.followers;
            }

            set
            {
                this.followers = value;
            }
        }

        public virtual ICollection<User> Following
        {
            get
            {
                return this.following;
            }

            set
            {
                this.following = value;
            }
        }

        public virtual ICollection<Category> Subsciptions
        {
            get
            {
                return this.subscriptions;
            }

            set
            {
                this.subscriptions = value;
            }
        }
    }
}