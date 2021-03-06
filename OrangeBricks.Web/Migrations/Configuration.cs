namespace OrangeBricks.Web.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OrangeBricks.Web.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "OrangeBricks.Web.Models.ApplicationDbContext";
        }

        protected override void Seed(OrangeBricks.Web.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            // Seed View Status
            // avoid duplicatie
            if(context.ViewStatus.Count()<1)
            {

                context.ViewStatus.AddOrUpdate(k => k.StatusId,
                new Models.ViewStatus { StatusName = "NotAvailable" }
                , new Models.ViewStatus { StatusName = "Pending" }
                , new Models.ViewStatus { StatusName = "Accepted" }
                );

            }



        }
    }
}
