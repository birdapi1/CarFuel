﻿using CarFuel.Models;
using CarFuel.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarFuel.Web.Controllers {
  public class HomeController : Controller {
    public ActionResult Index() {

      return View();
      //using (var db = new CarFuelDb()) {
      //  var fillUpds = from f in db.FillUps
      //                 select f;
      //  return View(fillUpds.ToList());
      //}
      
    }

    public ActionResult About() {
      //using(var db = new CarFuelDb()) {
      //  var f1 = new FillUp(1000,40.0);
      //  var f2 = new FillUp(2000,50.0);
      //  var f3 = new FillUp(2500,20.0);

      //  f1.NextFillup = f2;
      //  f2.NextFillup = f3;

      //  db.FillUps.Add(f1);
      //  db.SaveChanges();
      //  return RedirectToAction("Index");

      //}

      return View();
    }

    public ActionResult Contact() {
      ViewBag.Message = "Your contact page.";

      return View();
    }
  }
}