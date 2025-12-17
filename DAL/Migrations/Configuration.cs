namespace DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.RegistrationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false; 
        }

        protected override void Seed(DAL.RegistrationDbContext context)
        {
            
        }
    }
}
