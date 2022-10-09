using BookAway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BookAway.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        BookAwayEntities entities = new BookAwayEntities();
        public ActionResult Index()
        {
            return View(entities.Hotels.ToList());
        }


        public ActionResult LoginCust()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginCust(LoginAdmin admin)
        {
            if (ModelState.IsValid)
            {
                bool n = entities.AdminLogins.Any(x => x.AdminUsername == admin.AdminUsername && x.AdminPassword == admin.AdminPassword);
                if (n)
                {
                    FormsAuthentication.SetAuthCookie(admin.AdminUsername, false);

                    TempData["user"] = "admin";
                    return RedirectToAction("Index", "Admin");
                }

                else
                {
                    Response.Write(@"<script>alert('Not Valid User');</script>");
                }
            }
            Response.Write(@"<script>alert('Not Valid User');</script>");

            return View();
        }


        public ActionResult LogOutCust()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel hotel = entities.Hotels.Find(id);
            if (hotel == null)
            {
                return HttpNotFound();
            }
            return View(hotel);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hotel hotel = entities.Hotels.Find(id);
            entities.Hotels.Remove(hotel);  
            entities.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}