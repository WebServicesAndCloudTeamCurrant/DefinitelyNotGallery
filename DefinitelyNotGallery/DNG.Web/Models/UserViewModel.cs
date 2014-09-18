namespace DNG.Web.Models
{
    using DNG.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

    public class UserViewModel
    {
        public static Expression<Func<User, UserViewModel>> FromUser
        {
            get
            {
                return x => new UserViewModel 
                { 
                    FirstName = x.FirstName,
                    LastName = x.LastName, 
                    DateOfBirth = x.DateOfBirth, 
                    Age = x.Age, 
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

        public DateTime? DateOfBirth { get; set; }

        public int? Age { get; set; }

        [MinLength(2)]
        [MaxLength(20)]
        public string Country { get; set; }

        [MinLength(2)]
        [MaxLength(20)]
        public string City { get; set; }
    }
}