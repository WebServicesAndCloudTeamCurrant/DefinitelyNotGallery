namespace DNG.Web.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;

    using DNG.Models;

    public class UserViewModel
    {
        public static Expression<Func<User, UserViewModel>> FromUser
        {
            get
            {
                return x => new UserViewModel 
                { 
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName, 
                    UserName = x.UserName,
                    Email = x.Email,
                    DateOfBirth = x.DateOfBirth,
                    Country = x.Country, 
                    City = x.City 
                };
            }
        }

        public object Id { get; set; }

        [MinLength(2)]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [MinLength(2)]
        [MaxLength(20)]
        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [MinLength(2)]
        [MaxLength(20)]
        public string Country { get; set; }

        [MinLength(2)]
        [MaxLength(20)]
        public string City { get; set; }
    }
}