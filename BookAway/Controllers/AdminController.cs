using BookAway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace BookAway.Controllers
{
    public class AdminController : Controller
    {
        BookAwayEntities entities = new BookAwayEntities();

        // GET: HotelOwner
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoginAdminl()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginAdminl(Login login)
        {
            if (ModelState.IsValid)
            {
                bool n = entities.AdminLogins.Any(x => x.AdminUsername == login.CustUsername && x.AdminPassword == login.CustPassword);
                if (n)
                {
                    FormsAuthentication.SetAuthCookie(login.CustUsername, false);


                    return RedirectToAction("Index", "HotelOwner");
                }

                else
                {
                    Response.Write(@"<script>alert('Not Valid User');</script>");
                }
            }
            //Response.Write(@"<script>alert('!!Not Valid User');</script>");

            return View();
        }
        public ActionResult LogOutCust()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}