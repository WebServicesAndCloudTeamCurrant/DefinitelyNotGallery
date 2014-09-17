namespace DNG.Data
{
    using DNG.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class DngDbContext : IdentityDbContext<ApplicationUser>
    {
        public DngDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static DngDbContext Create()
        {
            return new DngDbContext();
        }
    }
}