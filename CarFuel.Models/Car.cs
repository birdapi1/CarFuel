using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace CarFuel.Models {
  public class Car {

    public Car() : this("Car") {
      //
    }

    public Car(string name) {
      FillUps = new HashSet<FillUp>();
      Name = name;
    }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    
    public string Name { get; set; }
    public virtual ICollection<FillUp> FillUps { get; set; } //= new HashSet<FillUp>();

    [Required]
    public virtual User Owner { get; set; }

    public double? AverageKML {
      get {
        if (FillUps.Count <= 1)
          return null;

        if (FillUps.Count == 2)
          return FillUps.First().KmL;

        var first = FillUps.First();
        var last = FillUps.Last();
        var sumLiters = FillUps.Sum(f => f.Liters) - first.Liters;
        var kml = (last.Odometer - first.Odometer) / sumLiters;

        return Math.Round(kml,2 , MidpointRounding.AwayFromZero);

      }
    }

    public FillUp AddFillUp(int odometer, double liters ) {
      
      FillUp f = new FillUp(odometer , liters);
      if(FillUps.Count > 0) {
        FillUps.LastOrDefault().NextFillup = f;
      }

      this.FillUps.Add(f);

      return f;

    }
  }
}