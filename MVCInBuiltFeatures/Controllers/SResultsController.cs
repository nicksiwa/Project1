using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCInBuiltFeatures.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Reporting.WebForms;
using System.IO;


namespace MVCInBuiltFeatures.Controllers
{

    public class MyDbContext : IdentityDbContext<ApplicationUser>
    {
        new public DbSet<ApplicationDbContext> 
        Roles { get; set; } 
        public MyDbContext() : base("DefaultConnection") 
        { this.Configuration.LazyLoadingEnabled = true; 
        } }



    public class SResultsController : Controller
    {
        private MedicalDBContext db = new MedicalDBContext();






        // GET: SResults
      /* [Authorize(Roles = "Doctor,Nurse")]
        public ActionResult Index(string searchString)
        {
            var results = from m in db.SResults
                           select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                results = results.Where(s => s.sid.Contains(searchString));
            }
            return View(results);

        }*/

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

        [Authorize(Roles = "Doctor")]
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


        [Authorize(Roles = "Doctor")]
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


        [Authorize(Roles = "Doctor")]
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
