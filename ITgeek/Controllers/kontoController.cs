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

namespace ITgeek.Controllers
{
    public class kontoController : Controller
    {
        private itgeekEntities3 db = new itgeekEntities3();

        // GET: /konto/Rejestracja
        public ActionResult Rejestracja()
        {
            return View();
        }

/*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rejestracja(uzytkownik model)
        {

            if (ModelState.IsValid)
            {
                using(kontoController dc= new kontoController){
                    dc.Rejestracja();
                    dc.Rejestracja.add(RejestracjaViewModel model);
                
                }

            }
            return View();
        }
        */

        /*
        // POST: /konto/Rejestracja
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Rejestracja(RejestracjaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser() { UserName = model.UserName };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    //AddErrors(result);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        */

        

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
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
        */
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
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
    }
}
