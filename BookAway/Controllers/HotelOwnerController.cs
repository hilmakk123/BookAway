
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

        // GET: HotelOwner
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoginHotel ()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginHotel(Login login)
        {
            if (ModelState.IsValid)
            {
                bool n = entities.HotelOwners.Any(x => x.HOwnerUsername == login.CustUsername && x.HOwnerPassword== login.CustPassword);
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
    }
}