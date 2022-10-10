using BookAway.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BookAway.Controllers
{
    public class CustomerController : Controller
    {
        //SqlConnection sql;
        //SqlCommand cmd;
        //string str = "server=INL372;database=BookAway;trusted_connection=true";
        //SqlDataReader sdr;
        BookAwayEntities entities = new BookAwayEntities();
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
      
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(Customer customer)
        {
            if (ModelState.IsValid)
            {
                entities.Customers.Add(customer);
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
        public ActionResult LoginCust(Login customer)
        {
            if (ModelState.IsValid)
            {
                bool n = entities.Customers.Any(x => x.CustUsername == customer.CustUsername && x.CustPassword == customer.CustPassword);
                if (n)
                {
                    FormsAuthentication.SetAuthCookie(customer.CustUsername, false);
                    
                    TempData["user"] = "cust";
                    return RedirectToAction("Index", "Customer");
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
        
        public ActionResult Search(Search search)
        {

            //var noRooms = (from b in entities.Bookings
            //              group b by b.Id into d
            //              join h in entities.Hotels on d.FirstOrDefault().Id equals h.Id
            //              where d.FirstOrDefault().CheckIn <= search.CheckIn && search.CheckOut <= d.FirstOrDefault().CheckOut
            //              select new { Id = h.Id, rooms = h.TotalOfRooms - d.Sum(x => x.NOfRooms) }).ToList();
            //var hotels = from h in entities.Hotels join s in noRooms on h.Id equals s.Id where h.HotelCity == search.Detsination && search.Rooms <= s.rooms select h;
            //SqlConnection sql = new SqlConnection(str);
            //cmd = new SqlCommand()
            //{
            //    Connection = sql,
            //    CommandText = "HoelDisp",
            //    CommandType = CommandType.StoredProcedure
            //};
            //cmd.Parameters.AddWithValue("@checkin",search.CheckIn);
            //cmd.Parameters.AddWithValue("@checkout",search.CheckOut);
            //cmd.Parameters.AddWithValue("@dest",search.Detsination);
            //cmd.Parameters.AddWithValue("@room",search.Rooms);
            //sql.Open();
            //sdr = cmd.ExecuteReader();
            //sd
            var hotels = entities.Hotels.Where(x=>x.HotelCity==search.Detsination);
            return View(hotels.ToList());
            //  var hotels = entities.HoelDisplay(search.CheckIn, search.CheckOut, search.Detsination, search.Rooms);

          
        }
        public ActionResult Book()
        {
            //ViewBag.Hotels = new SelectList(entities.Hotels, "Id", "HotelName");



            //var hotels = new SelectList(entities.Hotels, "Id", "HotelName");



            //var hotels = entities.Hotels.Select(x => x.HotelName).ToList();
            //ViewData["hotelList"] = hotels;

            ViewBag.HotelId = new SelectList(entities.Hotels, "Id", "HotelName");
            return View();
        }
        [HttpPost]
        public ActionResult Book([Bind(Include = "HotelId,CheckIn,CheckOut,NOfRooms")] Booking entry)
        {
            //ViewBag.Hotels = new SelectList(entities.Hotels, "Id", "HotelName");
            Customer cust = entities.Customers.SingleOrDefault(c => c.CustUsername == User.Identity.Name);
            entry.CustId = cust.Id;
          

            entities.Bookings.Add(entry);
            entities.SaveChanges();
            ViewBag.HotelId = new SelectList(entities.Hotels, "Id", "HotelName", entry.HotelId);

            Response.Write(@"<script>alert('Booking successfull');</script>");
            return View();
        }

    }
}