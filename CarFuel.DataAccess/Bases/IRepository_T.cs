using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFuel.DataAccess.Bases {

  /*
   <T> = Type Parameter
   Where T : class = Type Constraints ( have to class ref )
    keyword : built-in delegate
  */
  public interface IRepository<T> where T : class {
    IQueryable<T> Query(Func<T, bool> criteria);

    T Add(T item);
    T Remove(T item);
    int SaveChanges();
  }
}
