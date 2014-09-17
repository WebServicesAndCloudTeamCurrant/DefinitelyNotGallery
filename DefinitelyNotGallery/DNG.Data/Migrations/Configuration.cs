namespace DNG.Data.Migrations
{
    using System.Data.Entity.Migrations;

    using DNG.Data;

    internal sealed class Configuration : DbMigrationsConfiguration<DngDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "DNG.Data.DngDbContext";
        }
    }
}
