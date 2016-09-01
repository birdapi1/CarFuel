using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarFuel.Models {
  [Table("FillUp")]
  public class FillUp {
    public FillUp() {
    }

    public FillUp(int odometer, double liters, bool isFull = true) {
      Odometer = odometer;
      Liters = liters;
      IsFull = isFull;
    }

    [Key]
    public int Id { get; set; }

    [Column("IS_FULL")]
    public bool IsFull { get; set; }

    [Range(0.0,100.0)]
    public double Liters { get; set; }

    [Range(0,999999)]
    public int Odometer { get; set; }

    //Navigation Properties
    //makes it "virtual" to enable lazy-loading.
    /*
      Loading :
      1.Lazy load
      2.Eagerly load
      3.Manual load
     */
    public virtual FillUp NextFillup { get; set; }

    public double? KmL {
      get {
        // code here
        if (NextFillup == null) 
          return null;

        if (Odometer > NextFillup.Odometer)
          throw new Exception("Odometer should be greater than the previous one.");

        return (NextFillup.Odometer - Odometer) / NextFillup.Liters;
        
        
      }
    }
  }
}