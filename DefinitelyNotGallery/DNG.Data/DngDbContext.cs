namespace DNG.Data
{
    using DNG.Data.Migrations;
    using DNG.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

    public class DngDbContext : IdentityDbContext<ApplicationUser>
    {
        public DngDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DngDbContext, Configuration>());
        }

        public static DngDbContext Create()
        {
            return new DngDbContext();
        }

        public IDbSet<Category> Categories { get; set; }
        public IDbSet<Image> Images { get; set; }
        public IDbSet<Subscription> Subscriptions { get; set; }
        
    }
}