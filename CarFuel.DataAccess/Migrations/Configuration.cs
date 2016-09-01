namespace CarFuel.DataAccess.Migrations
{
  using CarFuel.Models;
  using System;
  using System.Data.Entity;
  using System.Data.Entity.Migrations;
  using System.Linq;

  internal sealed class Configuration : DbMigrationsConfiguration<CarFuel.DataAccess.Models.CarFuelDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CarFuel.DataAccess.Models.CarFuelDb";
        }

        protected override void Seed(CarFuel.DataAccess.Models.CarFuelDb context)
        {
          var zeroId = new Guid();
          context.Users.AddOrUpdate(
            u => u.UserId,
            new User { UserId = zeroId , DisplayName = "Default User"}
            );
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
        }
    }
}
