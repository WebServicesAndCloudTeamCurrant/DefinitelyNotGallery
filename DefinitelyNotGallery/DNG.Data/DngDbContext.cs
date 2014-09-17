namespace DNG.Data
{
    using DNG.Data.Migrations;
    using DNG.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

    public class DngDbContext : IdentityDbContext<User>
    {
        public DngDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DngDbContext, Configuration>());
        }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Image> Images { get; set; }

        public IDbSet<Subscription> Subscriptions { get; set; }

        public static DngDbContext Create()
        {
            return new DngDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasOptional(c => c.Parent)
                .WithMany()
                .HasForeignKey(p => p.ParentID);
        }
    }
}