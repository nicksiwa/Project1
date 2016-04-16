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
    public class SResultsController : Controller
    {
        private MedicalDBContext db = new MedicalDBContext();

        // GET: SResults
        public ActionResult Index()
        {

            var SResults = from m in db.SResults
                               select m;
           
            return View(SResults);
            
        }

        // GET: SResults/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SResult sResult = db.SResults.Find(id);
            if (sResult == null)
            {
                return HttpNotFound();
            }
            return View(sResult);
        }

        // GET: SResults/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SResults/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,sid,result,medicine,present_illness,vital_sign,date")] SResult sResult)
        {
            if (ModelState.IsValid)
            {
                db.SResults.Add(sResult);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sResult);
        }

        // GET: SResults/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SResult sResult = db.SResults.Find(id);
            if (sResult == null)
            {
                return HttpNotFound();
            }
            return View(sResult);
        }

        // POST: SResults/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,sid,result,medicine,present_illness,vital_sign,date")] SResult sResult)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sResult).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sResult);
        }

        // GET: SResults/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SResult sResult = db.SResults.Find(id);
            if (sResult == null)
            {
                return HttpNotFound();
            }
            return View(sResult);
        }

        // POST: SResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SResult sResult = db.SResults.Find(id);
            db.SResults.Remove(sResult);
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
