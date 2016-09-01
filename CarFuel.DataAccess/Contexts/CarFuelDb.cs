using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CarFuel.Models;

namespace CarFuel.DataAccess.Models {
  public class CarFuelDb : DbContext {
    //public DbSet<FillUp> FillUps { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<User> Users { get; set; }
  }
}