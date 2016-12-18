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
    public class repairsController : Controller
    {
        private RepairContext db = new RepairContext();

        // GET: repairs
        public ActionResult Index(string selected, string searchString )
        {
            if (Session["UserID"] != null && Session["permiss"].ToString() == "student")
            {
                var stdid = Session["UserID"].ToString();
                var Roomadds = from m in db.repairs
                               where (m.studentid == stdid)
                               select m;

                

                if (selected == "1")
                {

                    Roomadds = Roomadds.Where(s => s.jobname.Contains(searchString));

                }

                if (selected == "2")
                {



                }

                if (selected == "3")
                {
                    Roomadds = Roomadds.Where(s => s.studentid.Contains(searchString));



                }

                if (selected == "4")
                {

                    Roomadds = Roomadds.Where(s => s.status.Contains(searchString));

                }

                if (selected == "5")
                {

                    Roomadds = Roomadds.Where(s => s.roomno.Contains(searchString));

                }

                if (selected == "6")
                {

                    Roomadds = Roomadds.Where(s => s.choich.Contains(searchString));

                }
                return View(Roomadds);
            } 
            else {
                var Roomadds = from m in db.repairs
                               select m;

                if (selected == "1")
                {

                    Roomadds = Roomadds.Where(s => s.jobname.Contains(searchString));
                 
                }

                if (selected == "2")
                {

                   

                }

                if (selected == "3")
                {
                    Roomadds = Roomadds.Where(s => s.studentid.Contains(searchString));

                   

                }

                if (selected == "4")
                {

                    Roomadds = Roomadds.Where(s => s.status.Contains(searchString));

                }

                if (selected == "5")
                {

                    Roomadds = Roomadds.Where(s => s.roomno.Contains(searchString));

                }

                if (selected == "6")
                {

                    Roomadds = Roomadds.Where(s => s.choich.Contains(searchString));

                }
                return View(Roomadds);
            }

            
            


            
        }

        public ActionResult New()
        {
            
   
                var dd = db.repairs.Where(a => a.status == "New").ToList();
              
           
                return View(dd);
            }

        public ActionResult progress()
        {


            var dd = db.repairs.Where(a => a.status == "progress").ToList();


            return View(dd);
        }

        public ActionResult Finished()
        {


            var dd = db.repairs.Where(a => a.status == "Finished").ToList();


            return View(dd);
        }








        // GET: repairs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            repair repair = db.repairs.Find(id);
            if (repair == null)
            {
                return HttpNotFound();
            }
            return View(repair);
        }

        // GET: repairs/Create
        public ActionResult Create()
        {
            
              
            return View();
        }

        // POST: repairs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,jobname,descript,datetime,status,studentid,roomno,choich")] repair repair)
        {
            if (ModelState.IsValid)
            {
                db.repairs.Add(repair);

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(repair);
        }

        // GET: repairs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            repair repair = db.repairs.Find(id);
            if (repair == null)
            {
                return HttpNotFound();
            }
            return View(repair);
        }

        // POST: repairs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,jobname,descript,datetime,status,studentid,roomno,choich")] repair repair)
        {
            if (ModelState.IsValid)
            {
                db.Entry(repair).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(repair);
        }

        // GET: repairs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            repair repair = db.repairs.Find(id);
            if (repair == null)
            {
                return HttpNotFound();
            }
            return View(repair);
        }

        // POST: repairs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repair repair = db.repairs.Find(id);
            db.repairs.Remove(repair);
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
