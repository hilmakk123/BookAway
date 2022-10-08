using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookAway.Models;

namespace BookAway.Controllers
{
    public class HotelsController : Controller
    {
        private BookAwayEntities db = new BookAwayEntities();

        // GET: Hotels
        public ActionResult Index()
        {
            var hotels = db.Hotels.Include(h => h.HotelOwner1);
            return View(hotels.ToList());
        }

        // GET: Hotels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel = db.Hotels.Find(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View(hotel);
        }

        // GET: Hotels/Create
        public ActionResult Create()
        {
            ViewBag.HotelOwner = new SelectList(db.HotelOwners, "Id", "HOwnerUsername");
            return View();
        }

        // POST: Hotels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,HotelName,HotelAddress,HotelEmail,HotelContactNumber,TotalOfRooms,RentPerRoom,HotelPic,HotelOwner,HotelCity")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                db.Hotels.Add(hotel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HotelOwner = new SelectList(db.HotelOwners, "Id", "HOwnerUsername", hotel.HotelOwner);
            return View(hotel);
        }

        // GET: Hotels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel = db.Hotels.Find(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            ViewBag.HotelOwner = new SelectList(db.HotelOwners, "Id", "HOwnerUsername", hotel.HotelOwner);
            return View(hotel);
        }

        // POST: Hotels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,HotelName,HotelAddress,HotelEmail,HotelContactNumber,TotalOfRooms,RentPerRoom,HotelPic,HotelOwner,HotelCity")] Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HotelOwner = new SelectList(db.HotelOwners, "Id", "HOwnerUsername", hotel.HotelOwner);
            return View(hotel);
        }

        // GET: Hotels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel = db.Hotels.Find(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View(hotel);
        }

        // POST: Hotels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hotel hotel = db.Hotels.Find(id);
            db.Hotels.Remove(hotel);
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
    }
}
