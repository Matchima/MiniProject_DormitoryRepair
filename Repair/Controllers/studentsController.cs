using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Repair.Models;

namespace Repair.Controllers
{
    public class studentsController : Controller
    {
        private RepairContext db = new RepairContext();

        // GET: students
        public ActionResult Index(string selected, string searchString)
        {
            if (Session["UserID"] != null && Session["permiss"].ToString() == "student")
            {
                var ida = Session["UserID"].ToString();
                var dd = db.students.Where(a => a.studentid == ida).ToList();
                return View(dd);
            }
            else
            {
                var Roomadds = from m in db.students
                               select m;

                if (selected == "1")
                {

                    Roomadds = Roomadds.Where(s => s.fname.Contains(searchString));

                }

                if (selected == "2")
                {

                    Roomadds = Roomadds.Where(s => s.lname.Contains(searchString));

                }

                if (selected == "3")
                {
                    Roomadds = Roomadds.Where(s => s.studentid.Contains(searchString));



                }

                if (selected == "4")
                {

                    Roomadds = Roomadds.Where(s => s.year.Contains(searchString));

                }

                if (selected == "5")
                {

                    Roomadds = Roomadds.Where(s => s.faculty.Contains(searchString));

                }

                if (selected == "6")
                {

                    Roomadds = Roomadds.Where(s => s.branch.Contains(searchString));

                }

                if (selected == "7")
                {

                    Roomadds = Roomadds.Where(s => s.roomno.Contains(searchString));

                }
                return View(Roomadds);
            }
               
            }

         

        // GET: students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,studentid,password,fname,lname,faculty,branch,year,roomno,tell,permiss")] student student)
        {
            if (ModelState.IsValid)
            {
                db.students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,studentid,password,fname,lname,faculty,branch,year,roomno,tell,permiss")] student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            student student = db.students.Find(id);
            db.students.Remove(student);
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
