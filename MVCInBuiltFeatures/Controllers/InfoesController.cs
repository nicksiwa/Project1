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



    public class InfoesController : Controller
    {
        private MedicalDBContext db = new MedicalDBContext();



        [Authorize(Roles = "Doctor,Nurse")]
        // GET: Infoes
        public ActionResult Index()
        {
            return View(db.Info.ToList());
        }

        // GET: Infoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Info info = db.Info.Find(id);
            if (info == null)
            {
                return HttpNotFound();
            }
            return View(info);
        }


        [Authorize(Roles = "Doctor,Nurse")]
        // GET: Infoes/Create
        public ActionResult Create()
        {
            return View();
        }

         [Authorize(Roles = "Doctor,Nurse")]
        // POST: Infoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Header,Detail,Image")] Info info)
        {
            if (ModelState.IsValid)
            {
                db.Info.Add(info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(info);
        }



         [Authorize(Roles = "Doctor,Nurse")]
        // GET: Infoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Info info = db.Info.Find(id);
            if (info == null)
            {
                return HttpNotFound();
            }
            return View(info);
        }

         [Authorize(Roles = "Doctor,Nurse")]
        // POST: Infoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Header,Detail,Image")] Info info)
        {
            if (ModelState.IsValid)
            {
                db.Entry(info).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(info);
        }

         [Authorize(Roles = "Doctor,Nurse")]
        // GET: Infoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Info info = db.Info.Find(id);
            if (info == null)
            {
                return HttpNotFound();
            }
            return View(info);
        }

         [Authorize(Roles = "Doctor,Nurse")]
        // POST: Infoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Info info = db.Info.Find(id);
            db.Info.Remove(info);
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
