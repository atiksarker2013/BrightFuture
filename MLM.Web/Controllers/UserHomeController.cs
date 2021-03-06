﻿using MLM.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MLM.Web.Controllers
{
    public class UserHomeController : Controller
    {
        // GET: UserHome
        private BrightFutureHoustoneEntities db = new BrightFutureHoustoneEntities();
      

        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            return RedirectToAction("Login");
        }

        public ActionResult Login()
        {


            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {

            try
            {
                StaffList obj = db.StaffList.SingleOrDefault(m => m.Username == username && m.Password == password && m.IsDelete == false && m.IsUser == true);
                if (obj == null)
                {
                    Exception e = new Exception("Incorrect user access.");
                    return View("Error", new HandleErrorInfo(e, "UserHome", "Login"));
                }
                else
                {
                    GlobalClass.LoginUser = obj;

                    GlobalClass.Company = db.Company.SingleOrDefault(m => m.CompanyKey == obj.CompanyKey);
                    //GlobalClass.Company = db.Company.FirstOrDefault();
                    //GlobalClass.Warehouse = db.Warhouse.FirstOrDefault();
                    GlobalClass.SystemSession = true;
                    return RedirectToAction("Index", "UserHome");
                }

            }
            catch (DivideByZeroException e)
            {
                return View("Error", new HandleErrorInfo(e, "UserHome", "Login"));
            }
        }
        public ActionResult AdminLogin()
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(string username, string password)
        {
            try
            {
                if (username == System.Configuration.ConfigurationManager.AppSettings["superAdd"] && password == System.Configuration.ConfigurationManager.AppSettings["sp"])
                {
                    GlobalClass.MasterSession = true;
                    return RedirectToAction("Index", "Home");
                }

            }
            catch (DivideByZeroException e)
            {
                return View("Error", new HandleErrorInfo(e, "Home", "Index"));
            }

            return View();
        }
        

        public ActionResult RedirectToCustomerMesseging()
        {
            if (GlobalClass.SystemSession)
            {
                return RedirectToAction("CustomerMesseging", "MgtJobMesseging", new { id = GlobalClass.StoreGuid });
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "UserHome", "Logout"));
            }

        }
        
        
        public ActionResult Setup()
        {
            if (GlobalClass.SystemSession)
            {
                return View();
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "UserHome", "Logout"));
            }

        }

        public ActionResult Index()
        {
            if (GlobalClass.SystemSession)
            {
                //DashboardClass model = new DashboardClass();
                //model.FirstGrid = new List<DashboardJobClass>();
                //model.FirstGrid = setup.FillFirstGrid(1);

                //model.SecGrid = new List<DashboardJobClass>();
                //model.SecGrid = setup.FillFirstGrid(2);

                //model.ThirdGrid = new List<DashboardJobClass>();
                //model.ThirdGrid = setup.FillFirstGrid(3);

                //model.ForthGrid = new List<DashboardJobClass>();
                //model.ForthGrid = setup.FillFirstGrid(4);
                return View();
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "UserHome", "Logout"));
            }

        }
    }
}