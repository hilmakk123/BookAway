﻿using BookAway.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BookAway.Controllers
{
    public class CustomerController : Controller
    {
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

    }
}