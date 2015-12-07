using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;


using ITgeek.Models;

namespace ITgeek.Controllers
{
    public class HomeController : Controller
    {

        private itgeekEntities4 db = new itgeekEntities4();

        public ActionResult Index(uzytkownik u)
        {
            ViewBag.Title = "Strona Główna";
            ViewBag.Message = "Krótki opis strony głównej";

            
            return View(db.uzytkownik.ToList());
            
        }

        public ActionResult Strona1()
        {
            ViewBag.Title = "Strona 1";
            ViewBag.Message = "Krótki opis strony nr 1";

            return View();
        }

        public ActionResult Strona2()
        {
            ViewBag.Title = "Strona 2";
            ViewBag.Message = "Krótki opis strony nr 2";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Title = "Kontakt";
            ViewBag.Message = "Krótki opis strony kontakt";

            return View();
        }

        public ActionResult wyloguj()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }

        
    }
}