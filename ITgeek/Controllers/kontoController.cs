using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ITgeek;
using Microsoft.AspNet.Identity;
using ITgeek.Models;
using System.Web.Routing;
using System.Web.Security;


namespace ITgeek.Controllers
{
    public class kontoController : Controller
    {
        private itgeekEntities4 db = new itgeekEntities4();


        public ActionResult Loguj()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Loguj(uzytkownik u)
        {

            if (ModelState.IsValid)
            {
                var v = db.uzytkownik.Where(a => a.email.Equals(u.email) && a.haslo.Equals(u.haslo)).FirstOrDefault();
                if (v != null)
                {

                    Session["id"] = v.id_uzytkownik.ToString();
                    Session["wyswietlana_nazwa"] = v.wyswietlana_nazwa.ToString();


                    return RedirectToAction("Profil", new { id = Int32.Parse(Session["id"].ToString()) });

                }
                else
                    return View();
            }
            return View(u);
        }




        // GET: /konto/Rejestracja
        public ActionResult Rejestracja()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rejestracja(uzytkownik u)
        {

            if (ModelState.IsValid)
            {
                var v = db.uzytkownik.Where(m => m.email.Equals(u.email)).FirstOrDefault();
                if (v == null)
                {

                    db.uzytkownik.Add(u);
                    db.SaveChanges();

                    ModelState.Clear();
                    ViewBag.kolor = null;
                    u = null;
                    ViewBag.Message = "Rejestracja przebiegła pomyslnie!";

                }
                else
                {

                    u = null;
                    ViewBag.kolor = 0xff;
                    ViewBag.Message = "Podane konto już istnieje!";

                }

            }

            return View(u);
        }

        [HttpGet]
        public ActionResult Profil(int id)
        {
            uzytkownik user = db.uzytkownik.FirstOrDefault(u => u.id_uzytkownik.Equals(id));
            Projekty model = new Projekty();
            model.Uzytkownik = new Uzytkownik();
            model.Uzytkownik.id_uzytkownik = user.id_uzytkownik;
            model.Uzytkownik.imie = user.imie;


            model.Uzytkownik.miejscowosc = user.miejscowosc;
            model.Uzytkownik.email = user.email;
            model.Uzytkownik.wyswietlana_nazwa = user.wyswietlana_nazwa;

            model.ListaProjektow = new List<projekt>();
            model.ListaProjektow = db.projekt.Where(k => k.id_uzytkownik == id).ToList();


            return View(model);
        }


        public ActionResult Edycja()
        {
            int id = Int32.Parse(Session["id"].ToString());
            uzytkownik user = db.uzytkownik.FirstOrDefault(u => u.id_uzytkownik.Equals(id));
            Uzytkownik model = new Uzytkownik();
            model.id_uzytkownik = user.id_uzytkownik;
            model.imie = user.imie;
            model.nazwisko = user.nazwisko;
            model.data_urodzenia = user.data_urodzenia;
            model.miejscowosc = user.miejscowosc;
            model.email = user.email;
            model.wyswietlana_nazwa = user.wyswietlana_nazwa;
            model.haslo = user.haslo;
            model.uprawnienia = user.uprawnienia.ToString();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edycja(Uzytkownik profiluzytkownika)
        {
            if (ModelState.IsValid)
            {
                int id = Int32.Parse(Session["id"].ToString());
                uzytkownik user = db.uzytkownik.FirstOrDefault(u => u.id_uzytkownik.Equals(id));
                user.imie = profiluzytkownika.imie;
                user.nazwisko = profiluzytkownika.nazwisko;
                user.data_urodzenia = profiluzytkownika.data_urodzenia;
                user.miejscowosc = profiluzytkownika.miejscowosc;
                user.email = profiluzytkownika.email;
                user.wyswietlana_nazwa = profiluzytkownika.wyswietlana_nazwa;
                user.haslo = profiluzytkownika.haslo;
                user.uprawnienia = Int32.Parse(profiluzytkownika.uprawnienia);
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                Session["wyswietlana_nazwa"] = user.wyswietlana_nazwa.ToString();
                return RedirectToAction("PoZalogowaniu", "konto");
            }
            return View(profiluzytkownika);
        }


        [HttpPost]
        public JsonResult czy_istnieje(string email)
        {


            var user = Membership.GetUser(email);

            return Json(user == null);
        }


        /*




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "wyswietlana_nazwa,e_mail,haslo")] uzytkownik uzytkownik)
        {

            if (ModelState.IsValid)
            {

                db.uzytkownik.Add(uzytkownik);
                db.SaveChanges();
                return RedirectToAction("Index");

            }


            return View(uzytkownik);
        }





        // GET: /konto/
        public ActionResult Index()
        {
            return View(db.uzytkownik.ToList());
        }

        // GET: /konto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            uzytkownik uzytkownik = db.uzytkownik.Find(id);
            if (uzytkownik == null)
            {
                return HttpNotFound();
            }
            return View(uzytkownik);
        }

        // GET: /konto/Create
        public ActionResult Create()
        {
            return View();
        }
/*
        // POST: /konto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see

Implementing Basic CRUD Functionality
go.microsoft.com/f...
.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id_uzytkownik,imie,nazwisko,data_urodzenia,miejscowosc,wyswietlana_nazwa,e_mail,haslo,uprawnienia")] uzytkownik uzytkownik)
        {
            if (ModelState.IsValid)
            {
                db.uzytkownik.Add(uzytkownik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(uzytkownik);
        }

        // GET: /konto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            uzytkownik uzytkownik = db.uzytkownik.Find(id);
            if (uzytkownik == null)
            {
                return HttpNotFound();
            }
            return View(uzytkownik);
        }

        // POST: /konto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see

Implementing Basic CRUD Functionality
go.microsoft.com/f...
.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id_uzytkownik,imie,nazwisko,data_urodzenia,miejscowosc,wyswietlana_nazwa,e_mail,haslo,uprawnienia")] uzytkownik uzytkownik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(uzytkownik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(uzytkownik);
        }

        // GET: /konto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            uzytkownik uzytkownik = db.uzytkownik.Find(id);
            if (uzytkownik == null)
            {
                return HttpNotFound();
            }
            return View(uzytkownik);
        }

        // POST: /konto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            uzytkownik uzytkownik = db.uzytkownik.Find(id);
            db.uzytkownik.Remove(uzytkownik);
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
         * */
    }
}