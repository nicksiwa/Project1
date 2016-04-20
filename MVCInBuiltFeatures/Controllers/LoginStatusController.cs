using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCInBuiltFeatures.Models;

namespace MVCInBuiltFeatures.Controllers
{
    public class LoginStatusController : Controller
    {
        private MedicalDBContext db = new MedicalDBContext();

        // GET: LoginStatus
        public ActionResult Index()
        {
            return View(db.LoginStatus.ToList());
        }

        // GET: LoginStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginStatus loginStatus = db.LoginStatus.Find(id);
            if (loginStatus == null)
            {
                return HttpNotFound();
            }
            return View(loginStatus);
        }

        // GET: LoginStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserName,Status")] LoginStatus loginStatus)
        {
            if (ModelState.IsValid)
            {
                db.LoginStatus.Add(loginStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(loginStatus);
        }

        // GET: LoginStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginStatus loginStatus = db.LoginStatus.Find(id);
            if (loginStatus == null)
            {
                return HttpNotFound();
            }
            return View(loginStatus);
        }

        // POST: LoginStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserName,Status")] LoginStatus loginStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loginStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loginStatus);
        }

        // GET: LoginStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginStatus loginStatus = db.LoginStatus.Find(id);
            if (loginStatus == null)
            {
                return HttpNotFound();
            }
            return View(loginStatus);
        }

        // POST: LoginStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoginStatus loginStatus = db.LoginStatus.Find(id);
            db.LoginStatus.Remove(loginStatus);
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
