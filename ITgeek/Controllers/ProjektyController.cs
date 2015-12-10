using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ITgeek;
using ITgeek.Models;

namespace ITgeek.Controllers
{
   /*
    public class ExampleClass
    {
        // This attributes allows your HTML Content to be sent up
        [AllowHtml]
        public string HtmlContent { get; set; }

        public ExampleClass()
        {

        }
    }
    */


    public class ProjektyController : Controller
    {
        private itgeekEntities4 db = new itgeekEntities4();
        
        
       /* 
        // GET: /Projekty/
        public ActionResult Index()
        {
            //var projekt = db.projekt.Include(p => p.uzytkownik);
            return View();//projekt.ToList());
        }
        // An action that will accept your Html Content
        */
        //
        // This attributes allows your HTML Content to be sent up
       
        public ProjektyController()
        {

        }

        public ActionResult Index()//ProjektyController model)
        {
            System.Diagnostics.Debug.WriteLine("index");
            
            if (Session["ID"] != null)
                return View();
            else
            {
                ViewBag.Message = "Zaloguj się aby utworzyć projekt";
                return RedirectToAction("Loguj", "konto");             
            }
            
            //return View();
        }
        // POST: /Projekty/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(DodajProjektViewModel dane)
        {

            System.Diagnostics.Debug.WriteLine("create");

            if (ModelState.IsValid)
            {
               
                projekt nowy_projekt = new projekt();
                nowy_projekt.nazwa_projektu = dane.nazwa_projektu ;
                nowy_projekt.id_uzytkownik = Int32.Parse(Session["id"].ToString());
                nowy_projekt.poziom_ukonczenia =  dane.poziom_ukonczenia;
                nowy_projekt.wstep = dane.wstep;


              

                System.Diagnostics.Debug.WriteLine(nowy_projekt.wstep);

                db.projekt.Add(nowy_projekt);
                db.SaveChanges();
                
            }

           // ViewBag.id_uzytkownik = new SelectList(db.uzytkownik, "id_uzytkownik", "imie", nowyprojekt.id_uzytkownik);
            return View(dane);
        }

       
    }
}
