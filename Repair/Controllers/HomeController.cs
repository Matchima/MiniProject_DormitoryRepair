using Repair.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Repair.Controllers
{
    public class HomeController : Controller
    {
        private RepairContext db = new RepairContext();
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Login(string username, string password)
        {

          
            var obj = db.students.Where(a => a.studentid.Equals(username) && a.password.Equals(password)).FirstOrDefault();
            if (obj != null)
            {
                Session["UserID"] = obj.studentid.ToString();
                Session["UserName"] = obj.fname.ToString();
                Session["Room"] = obj.roomno.ToString();
                Session["permiss"] = obj.permiss.ToString();
                return RedirectToAction("Index");

            }
            var empolyee = db.employees.Where(b => b.employeeid.Equals(username) && b.password.Equals(password)).FirstOrDefault();
            if (empolyee != null)
            {
                Session["UserID"] = empolyee.employeeid.ToString();
                Session["UserName"] = empolyee.fname.ToString();
             
                Session["permiss"] = empolyee.permiss.ToString();

                return RedirectToAction("Index");

            }

            return View();
        }

        public ActionResult LogOut()
        {
           
            Session.Abandon(); // it will clear the session at the end of request
            Session.Clear();
            return RedirectToAction("index");
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}