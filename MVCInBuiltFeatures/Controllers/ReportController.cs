using Microsoft.Reporting.WebForms;
using MVCInBuiltFeatures.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCInBuiltFeatures.Controllers
{
    public class ReportController : Controller
    {

        private MedicalDBContext db = new MedicalDBContext();

        // GET: Report
        public ActionResult Index()
        {
            using (MedicalDBContext dc = new MedicalDBContext())
            {
                //var v = dc.SResults.ToList();
                //return View(v);
                return View();
            }
        }



       


        public ActionResult Report(string id)
        {
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Report"), "Report1.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return View("Index");
            }
           // List<SResult> cm = new List<SResult>();
            using (MedicalDBContext dc = new MedicalDBContext())
            {
                //cm = dc.SResults.ToList();
            }
            //ReportDataSource rd = new ReportDataSource("MyMVCTrainingDataSet", cm);
            //lr.DataSources.Add(rd);
            string reportType = id;
            string mimeType;
            string encoding;
            string fileNameExtension;



            string deviceInfo =

            "<DeviceInfo>" +
            "  <OutputFormat>" + id + "</OutputFormat>" +
            "  <PageWidth>8.5in</PageWidth>" +
            "  <PageHeight>11in</PageHeight>" +
            "  <MarginTop>0.5in</MarginTop>" +
            "  <MarginLeft>1in</MarginLeft>" +
            "  <MarginRight>1in</MarginRight>" +
            "  <MarginBottom>0.5in</MarginBottom>" +
            "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = lr.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);

 
            return File(renderedBytes, mimeType);
       

        }


   


    }
}