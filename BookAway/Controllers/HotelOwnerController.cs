using BookAway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BookAway.Controllers
{
    public class HotelOwnerController : Controller
    {
        BookAwayEntities entities = new BookAwayEntities();
        static string uname;
        // GET: HotelOwner

        public ActionResult Index()
        {   // var std = studentList.Where(s => s.StudentId == Id)
            //User.Identity.ToString();
            HotelOwner owner = entities.HotelOwners.SingleOrDefault(o => o.HOwnerUsername == uname);
            ViewBag.id = owner.Id;
            return View();
        }

        public ActionResult Insert()
        {




            return View();
        }
        [HttpPost]
        public ActionResult Insert(Hotel hotel)
        {
            HotelOwner owner = entities.HotelOwners.SingleOrDefault(o => o.HOwnerUsername == uname);
            if (ModelState.IsValid)

            {
                hotel.HotelOwner = owner.Id;
                entities.Hotels.Add(hotel);
                entities.SaveChanges();
                Response.Write(@"<script>alert('Hotel created successfully');</script>");
            }
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(HotelOwner ho)
        {
            if (ModelState.IsValid)
            {

                entities.HotelOwners.Add(ho);
                entities.SaveChanges();
                ModelState.Clear();
                //0   TempData["msg"] = "<script>alert('Account Created Successfully');</script>";
                Response.Write(@"<script>alert('Account Created Successfully');</script>");
            }
            return View();
        }

        public ActionResult LoginCust()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginCust(LoginHotelOwner ho)
        {
            if (ModelState.IsValid)
            {
                bool n = entities.HotelOwners.Any(x => x.HOwnerUsername == ho.HOwnerUsername && x.HOwnerPassword == ho.HOwnerPassword);
                if (n)
                {
                    FormsAuthentication.SetAuthCookie(ho.HOwnerUsername, false);
                    uname = ho.HOwnerUsername;
                    TempData["user"] = "cust";
                    return RedirectToAction("Insert", "HotelOwner");
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
    }
}