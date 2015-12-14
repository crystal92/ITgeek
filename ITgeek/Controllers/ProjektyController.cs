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
    public class ProjektyController : Controller
    {
        private itgeekEntities4 db = new itgeekEntities4();

        public ProjektyController()
        {

        }

        public ActionResult DodajProjekt()
        {
            if (Session["ID"] != null)
                return View();
            else
            {
                ViewBag.Message = "Zaloguj się aby utworzyć projekt";
                return RedirectToAction("Loguj", "konto");             
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DodajProjekt(Projekt dane)
        {
            if (ModelState.IsValid)
            {
                projekt nowy_projekt = new projekt();
                nowy_projekt.nazwa_projektu = dane.nazwa_projektu ;
                nowy_projekt.id_uzytkownik = Int32.Parse(Session["id"].ToString());
                nowy_projekt.poziom_ukonczenia =  dane.poziom_ukonczenia;
                nowy_projekt.wstep = dane.wstep;
                db.projekt.Add(nowy_projekt);
                db.SaveChanges();
            }
            return View(dane);
        }

        [HttpGet]
        public ActionResult Projekty()
        {
            ViewBag.Title = "Projekty";
            return View(db.projekt.ToList());
        }

        
        [HttpGet]
        public ActionResult Wyswietl(int id)
        {
            
            ViewBag.Title = "Projekt";
            Projekty model = new Projekty();
            projekt dane = db.projekt.FirstOrDefault(d => d.id_projekt.Equals(id));
            model.Projekt = new Projekt();
            model.Uzytkownik = new Uzytkownik();
            model.Projekt.id_projekt = dane.id_projekt;
            model.Projekt.id_uzytkownik = dane.id_uzytkownik;
            model.Projekt.nazwa_projektu = dane.nazwa_projektu;
            model.Projekt.poziom_ukonczenia = dane.poziom_ukonczenia;
            model.Projekt.wstep = dane.wstep;

            uzytkownik user = db.uzytkownik.FirstOrDefault(u => u.id_uzytkownik.Equals(model.Projekt.id_uzytkownik));
            System.Diagnostics.Debug.Print(user.wyswietlana_nazwa);
            model.Uzytkownik.wyswietlana_nazwa = user.wyswietlana_nazwa;
            return View(model);
        }
    }
}
