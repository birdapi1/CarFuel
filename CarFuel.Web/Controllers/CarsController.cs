using CarFuel.Models;
using CarFuel.Services;
using CarFuel.Services.Bases;
using CarFuel.Web.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarFuel.Web.Controllers {
  public class CarsController : AppControllerBase {
    /*private CarFuelDb db = new CarFuelDb();

    protected override void Dispose(bool disposing) {
      if (disposing) {
        db.Dispose();
      }
      base.Dispose(disposing);
    }*/

    private readonly ICarService _carService;

    public CarsController(ICarService carService ,
                          IUserService userService) : base(userService) {
      _carService = carService;

    }

    // GET: Cars
    public ActionResult Index() {

      //return View(db.Cars);
      //return View(_carService.All());

      if (User.Identity.IsAuthenticated) {
        var id = new Guid(User.Identity.GetUserId());
        var cars = _carService.All();

        ViewBag.AppUser = _userService.CurrentUser;
        return View("IndexForMember", cars);
      }
      else {
        return View("IndexForAnonymous");
      }

    }

    public ActionResult Add() {
      return View();
    }

    [HttpPost]
    public ActionResult Add(Car item) {
      ModelState.Remove("Owner");
      /*if (ModelState.IsValid) {
        db.Cars.Add(item);
        db.SaveChanges();
        return RedirectToAction("Index");
      }
      return View(item);*/
      if (ModelState.IsValid) {
        // TODO: assign car owner to current user.
        User u = _userService.Find(new Guid(User.Identity.GetUserId()));
        item.Owner = u;

        _carService.Add(item);
        _carService.SaveChanges();
        return RedirectToAction("Index");
      }
      return View(item);
    }

    public ActionResult AddFillUp(Guid id) {
      /*
        .Find
        1. Get Frome Memory
        2. Get DB
        3. Null 
      */
      //var c = db.Cars.Find(id);
      //if (c == null) {
      //  return HttpNotFound();
      //}
      //ViewBag.CarName = c.Name;

      //var q = (from c1 in db.Cars
      //            where c1.Id == id
      //            select c1.Name);

      var q = (from c in _carService.All()
               where c.Id == id
               select c.Name);

      var name = q.SingleOrDefault();
      ViewBag.CarName = name;
      return View();
    }

    [HttpPost]
    public ActionResult AddFillUp(Guid id,
                                //[Bind(Exclude ="Id")]
                                FillUp item) {
      ModelState.Remove("Id");
      if (ModelState.IsValid) {
        //var c = db.Cars.Find(id);
        //db.Entry(c).Collection(x => x.FillUps).Load(); // Munual Load (if Type not virtual)

        var c = _carService.Find(id);
        c.AddFillUp(item.Odometer, item.Liters);
        _carService.SaveChanges();
        //db.SaveChanges();
        return RedirectToAction("Index");
      }
      return View();
    }
  }
}