using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using MVCInBuiltFeatures.Models;

namespace MVCInBuiltFeatures.Controllers
{
    


    public class HistoryController : Controller
    {
            private MedicalDBContext db = new MedicalDBContext();
            
        // GET: History
            public ActionResult Index(string searchString)
            {
                var results = from m in db.SResults
                              join c in db.Students
                              on m.sid equals c.sid
                              select new
                              {
                                  sid = c.sid,
                                  name = c.name,
                                  sname = c.sname,
                                  date = m.date,
                                  medicine = m.medicine,
                                  re = m.result

                              };
                if (!String.IsNullOrEmpty(searchString))
                {
                    results = results.Where(s => s.sid.Contains(searchString));
                }
                return View(results);

            }

    }
}