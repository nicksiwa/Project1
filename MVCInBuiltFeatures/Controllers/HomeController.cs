using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCInBuiltFeatures.Controllers
{



    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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









        private MultiSelectList GetCountries(string[] selectedValues)
        {




            List<SelectListItem> listItems = new List<SelectListItem>();
            listItems.Add(new SelectListItem
            {
                Text = "ยาเม็ด",
                Value = "ยาเม็ด"
            });


            return new MultiSelectList(listItems, "ID", "Name", selectedValues);

        }

        public ActionResult MultiSelectCountry()
        {

            ViewBag.Countrieslist = GetCountries(null);

            return View();

        }



      


        [HttpPost]

        public ActionResult MultiSelectCountry(FormCollection form)
        {

            ViewBag.YouSelected = form["Countries"];

            string selectedValues = form["Countries"];

            ViewBag.Countrieslist = GetCountries(selectedValues.Split(','));

            return View();

        }




    }



}