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

        [HttpGet]
        public ActionResult DodajProjekt()
        {
            if (Session["ID"] != null)
            {
                ViewBag.kategoriaa = new SelectList(db.kategoria, "id_kategoria", "nazwa_kategorii"); 
                return View();
            }
            else
            {
                ViewBag.Message = "Zaloguj się aby utworzyć projekt";
                return RedirectToAction("Loguj", "konto");             
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DodajProjekt(Projekty dane)
        {
            if (ModelState.IsValid)
            {
       
                dane.ListaKategorii = db.kategoria.ToList();
                projekt nowy_projekt = new projekt();
                pozycja_kategorii nowa_pozycja = new pozycja_kategorii();
                nowy_projekt.nazwa_projektu = dane.Projekt.nazwa_projektu ;
                nowy_projekt.id_uzytkownik = Int32.Parse(Session["id"].ToString());
                nowy_projekt.poziom_ukonczenia =  dane.Projekt.poziom_ukonczenia;
                nowy_projekt.wstep = dane.Projekt.wstep;

                db.projekt.Add(nowy_projekt);
                db.SaveChanges();

                int jj = 0;
                foreach(var item in dane.ID_kat)
                {
                    System.Diagnostics.Debug.WriteLine(dane.ID_kat[jj].ToString());
                    nowa_pozycja.id_kategoria = dane.ID_kat[jj];
                    nowa_pozycja.id_projekt = nowy_projekt.id_projekt;
                    db.pozycja_kategorii.Add(nowa_pozycja);
                    db.SaveChanges();
                    ++jj;
                }
                /*
                int ii = 0;
                foreach(var item in dane.kategorie)
                {
                    nowa_pozycja.id_kategoria = dane.kategorie[ii].id_kategoria;
                    nowa_pozycja.id_projekt = nowy_projekt.id_projekt;
                    db.pozycja_kategorii.Add(nowa_pozycja);
                    db.SaveChanges();
                    ++ii;
                }
                */
                return RedirectToAction("DodajProjekt", "Projekty"); 
            }
            return View(dane);
        }

        [HttpGet]
        public ActionResult Projekty(string kategoria, string szukaj)
        {
            var projekty = db.projekt.ToList();
            var pozycje_kategorii = new List<pozycja_kategorii>();
            var lista_nazw = new List<string>();
            
            var lista =  from k in db.kategoria
                         orderby k.nazwa_kategorii
                         select k.nazwa_kategorii;

            lista_nazw.AddRange(lista.Distinct());
            ViewBag.kategoria = new SelectList(lista_nazw);

            if ((!String.IsNullOrEmpty(kategoria)) && (String.IsNullOrEmpty(szukaj)))
            {
                projekty = new List<projekt>();
                var kategorie = db.kategoria.Where(k => k.nazwa_kategorii.Contains(kategoria)).ToList();
                
                foreach (var item in kategorie)
                {
                    var id = db.pozycja_kategorii.Where(p => p.id_kategoria.Equals(item.id_kategoria)).ToList();
                    pozycje_kategorii.AddRange(id.Distinct());
                }

                foreach (var item in pozycje_kategorii)
                {
                    var id = db.projekt.Where(p => p.id_projekt.Equals(item.id_projekt)).ToList();
                    projekty.AddRange(id.Distinct());
                }
            }

            else if ((!String.IsNullOrEmpty(kategoria)) && (!String.IsNullOrEmpty(szukaj)))
            {
                projekty = new List<projekt>();
                var kategorie = db.kategoria.Where(k => k.nazwa_kategorii.Contains(kategoria)).ToList();

                foreach (var item in kategorie)
                {
                    var id = db.pozycja_kategorii.Where(p => p.id_kategoria.Equals(item.id_kategoria)).ToList();
                    pozycje_kategorii.AddRange(id.Distinct());
                }

                foreach (var item in pozycje_kategorii)
                {
                    var id = db.projekt.Where(p => p.id_projekt.Equals(item.id_projekt) && p.nazwa_projektu.Contains(szukaj)).ToList();
                    projekty.AddRange(id.Distinct());
                }
                //projekty = projekty.Where(p => p.nazwa_projektu.Contains(szukaj)).ToList(); 
            }

            else if ((String.IsNullOrEmpty(kategoria)) && (!String.IsNullOrEmpty(szukaj)))
                projekty = db.projekt.Where(p => p.nazwa_projektu.Contains(szukaj)).ToList(); 
            
            return View(projekty);
        }

        [HttpGet]
        public ActionResult Wyswietl(int id)
        {
            if (Session["ID"] != null)
            {
                ViewBag.Title = "Projekt";
                Projekty model = new Projekty();
                projekt dane = db.projekt.FirstOrDefault(d => d.id_projekt.Equals(id));
                model.Projekt = new Projekt();
                model.Uzytkownik = new Uzytkownik();
                model.Komentarz = new Komentarz();
                model.ListaKomentarzy = new List<komentarz>();
                model.ListaKomentarzy = db.komentarz.Where(k => k.id_projekt == id).ToList();
                model.ListaKategorii = new List<kategoria>();
                model.ListaPozycjiKategorii = new List<pozycja_kategorii>();

                var ids = db.pozycja_kategorii.Where(pk => pk.id_projekt.Equals(id)).ToList();
                model.ListaPozycjiKategorii = ids;
                foreach (var item in model.ListaPozycjiKategorii)
                {
                    var name = db.kategoria.Where(k => k.id_kategoria.Equals(item.id_kategoria));
                    model.ListaKategorii.AddRange(name.Distinct());
                }

                model.Projekt.id_projekt = dane.id_projekt;
                model.Projekt.id_uzytkownik = dane.id_uzytkownik;
                model.Projekt.nazwa_projektu = dane.nazwa_projektu;
                model.Projekt.poziom_ukonczenia = dane.poziom_ukonczenia;
                model.Projekt.wstep = dane.wstep;
                
                /*
                model.Projekt.zakonczenie = dane.zakonczenie;
                model.Projekt.rozwiniecie = dane.rozwiniecie;
                model.Projekt.uwagi_problemy = dane.uwagi_problemy;
                */
                
                uzytkownik user = db.uzytkownik.FirstOrDefault(u => u.id_uzytkownik.Equals(model.Projekt.id_uzytkownik));
                model.Uzytkownik.imie = user.imie;
                model.Uzytkownik.nazwisko = user.nazwisko;
                model.Uzytkownik.miejscowosc = user.miejscowosc;
                model.Uzytkownik.uprawnienia = user.uprawnienia.ToString();
                model.Uzytkownik.email = user.email;
                model.Uzytkownik.data_urodzenia = user.data_urodzenia;
                model.Uzytkownik.haslo = user.haslo;
                model.Uzytkownik.wyswietlana_nazwa = user.wyswietlana_nazwa;
                return View(model);
            }
            else
            {
                ViewBag.Title = "Projekt";
                Projekty model = new Projekty();
                projekt dane = db.projekt.FirstOrDefault(d => d.id_projekt.Equals(id));
                model.Projekt = new Projekt();
                model.Uzytkownik = new Uzytkownik();
                model.Komentarz = new Komentarz();
                model.ListaKomentarzy = new List<komentarz>();
                model.ListaKomentarzy = db.komentarz.Where(k => k.id_projekt == id).ToList();

                model.ListaKategorii = new List<kategoria>();
                model.ListaPozycjiKategorii = new List<pozycja_kategorii>();

                var ids = db.pozycja_kategorii.Where(pk => pk.id_projekt.Equals(id)).ToList(); 
                model.ListaPozycjiKategorii = ids;
               
                foreach(var item in model.ListaPozycjiKategorii)
                {
                    var name = db.kategoria.Where(k => k.id_kategoria.Equals(item.id_kategoria));
                    model.ListaKategorii.AddRange(name.Distinct());
                }

                model.Projekt.id_projekt = dane.id_projekt;
                model.Projekt.id_uzytkownik = dane.id_uzytkownik;
                model.Projekt.nazwa_projektu = dane.nazwa_projektu;
                model.Projekt.poziom_ukonczenia = dane.poziom_ukonczenia;
                model.Projekt.wstep = dane.wstep;
                /*
                model.Projekt.zakonczenie = dane.zakonczenie;
                model.Projekt.rozwiniecie = dane.rozwiniecie;
                model.Projekt.uwagi_problemy = dane.uwagi_problemy;
                */
                uzytkownik user = db.uzytkownik.FirstOrDefault(u => u.id_uzytkownik.Equals(model.Projekt.id_uzytkownik));
                model.Uzytkownik.imie = user.imie;
                model.Uzytkownik.nazwisko = user.nazwisko;
                model.Uzytkownik.miejscowosc = user.miejscowosc;
                model.Uzytkownik.uprawnienia = user.uprawnienia.ToString();
                model.Uzytkownik.email = user.email;
                model.Uzytkownik.data_urodzenia = user.data_urodzenia;
                model.Uzytkownik.haslo = user.haslo;
                model.Uzytkownik.wyswietlana_nazwa = user.wyswietlana_nazwa;
                return View("WyswietlB", model);
            }
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Wyswietl(Projekty dane)
        {
            if (ModelState.IsValid)
            {
                komentarz koment = new komentarz();
                koment.id_projekt = dane.Projekt.id_projekt;
                koment.id_uzytkownik = Int32.Parse(Session["ID"].ToString());
                koment.tresc_komentarza = dane.Komentarz.tresc_komentarza;
                db.komentarz.Add(koment);
                db.SaveChanges();
                return RedirectToAction("Wyswietl");
            }
            return View(dane);
        }
    }
}
