using BookAway.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Dynamic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BookAway.Controllers
{
    public class HomeController : Controller
    {
        BookAwayEntities entities = new BookAwayEntities();
        // GET: Home
        public ActionResult Index()
        {
            var city = entities.Hotels.Select(x => x.HotelCity).Distinct().ToList();
            //var City = (from c in city select new SelectListItem { Text = c, Value = c }).ToList();
            ViewData["cityList"] = city;
           // City.Insert(0, new SelectListItem { Text = "--Select Destination--", Value = "" });
           // dynamic myModel = new ExpandoObject();
           // myModel.City = City;

            return View();
        }

        [HttpPost]
        public ActionResult Search(Search search)
        {
            var noRooms = from h in entities.Hotels
                          join b in entities.Bookings on h.Id equals b.Id
                          where b.CheckIn <= search.CheckIn && search.CheckOut <= b.CheckOut group h by h.Id 
                          select new { Id = h.Id, rooms = h.TotalOfRooms - b.NOfRooms };
            var hotels = from h in entities.Hotels join s in noRooms on h.Id equals s.Id where h.HotelCity == search.Detsination && search.Rooms <= s.rooms select h;
            // var hotels = entities.Hotels.Select(x => x.HotelCity == search.Detsination && x.Id);
            return View(hotels.ToList());
        }

        public ActionResult About()
        {
            return View();
        }
       

    }
}