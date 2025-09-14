using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarInsuranceApp.Models;

namespace CarInsuranceApp.Controllers
{
    public class InsureeController : Controller
    {
        private InsuranceEntities db = new InsuranceEntities();

        // GET: Insuree
        public ActionResult Index()
        {
            return View(db.Insurees.ToList());
        }

        // GET: Insuree/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insurees insurees = db.Insurees.Find(id);
            if (insurees == null)
            {
                return HttpNotFound();
            }
            return View(insurees);
        }

        // GET: Insuree/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Insuree/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType")] Insurees insuree)
        {
            if (ModelState.IsValid)
            {
                insuree.Quote = CalculateQuote(insuree); // <<< dodane
                db.Insurees.Add(insuree);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(insuree);
        }


        // GET: Insuree/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insurees insurees = db.Insurees.Find(id);
            if (insurees == null)
            {
                return HttpNotFound();
            }
            return View(insurees);
        }

        // POST: Insuree/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType")] Insurees insuree)
        {
            if (ModelState.IsValid)
            {
                insuree.Quote = CalculateQuote(insuree); // <<< dodane
                db.Entry(insuree).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(insuree);
        }


        // GET: Insuree/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insurees insurees = db.Insurees.Find(id);
            if (insurees == null)
            {
                return HttpNotFound();
            }
            return View(insurees);
        }

        // POST: Insuree/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Insurees insurees = db.Insurees.Find(id);
            db.Insurees.Remove(insurees);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        private decimal CalculateQuote(Insurees insuree)
        {
            decimal quote = 50m;

            int age = DateTime.Now.Year - insuree.DateOfBirth.Year;
            if (insuree.DateOfBirth > DateTime.Now.AddYears(-age)) age--;

            if (age <= 18)
                quote += 100;
            else if (age >= 19 && age <= 25)
                quote += 50;
            else
                quote += 25;

            if (insuree.CarYear < 2000) quote += 25;
            if (insuree.CarYear > 2015) quote += 25;

            if (insuree.CarMake.ToLower() == "porsche")
            {
                quote += 25;
                if (insuree.CarModel.ToLower() == "911 carrera")
                    quote += 25;
            }

            quote += insuree.SpeedingTickets * 10;

            if (insuree.DUI)
                quote *= 1.25m;

            if (insuree.CoverageType)
                quote *= 1.5m;

            return Math.Round(quote, 2);
        }
        public ActionResult Admin()
        {
            var insurees = db.Insurees.ToList();
            return View(insurees);
        }


    }
}
